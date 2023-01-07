using System;
using System.Runtime.InteropServices;
using Inventor;
using Microsoft.Win32;
using Inventor_Form_1;
using FormCylinder;
using AssemblyCreator;
using washer;
using System.Diagnostics;
using System.Collections.Generic;


namespace InventorAddIn_UWP_v1
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [GuidAttribute("f68fd93a-3324-43ec-8b9d-9ec93f49f114")]
    public class StandardAddInServer : Inventor.ApplicationAddInServer
    {

        // Inventor application object.
        private Inventor.Application m_inventorApplication;
        private ButtonDefinition createRectBtn;
        private ButtonDefinition createCylinderBtn;
        private ButtonDefinition createAssemblyBtn;
        private ButtonDefinition createWasherBtn;

        private CommandCategory slotCmdCategory;

        private String partDirectory = "C:\\Users\\Mckee\\Documents\\Coding\\C#\\InventorAddIn_UWP_v1\\AssemblyParts\\";

        public StandardAddInServer()
        {
        }

        #region ApplicationAddInServer Members

        public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            // This method is called by Inventor when it loads the addin.
            // The AddInSiteObject provides access to the Inventor Application object.
            // The FirstTime flag indicates if the addin is loaded for the first time.

            GuidAttribute addInCLSID;
            addInCLSID = (GuidAttribute)GuidAttribute.GetCustomAttribute(typeof(StandardAddInServer), typeof(GuidAttribute));
            string addInCLSIDString;
            addInCLSIDString = "{" + addInCLSID.Value + "}";

            // Initialize AddIn members.
            m_inventorApplication = addInSiteObject.Application;
            createRectBtn = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition("Create Rectangular Prism", "createRectBtn", CommandTypesEnum.kEditMaskCmdType);
            createRectBtn.OnExecute += createRectBtn_OnExecute;

            createCylinderBtn = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition("Create Cylinder", "createCylinderBtn", CommandTypesEnum.kEditMaskCmdType);
            createCylinderBtn.OnExecute += createCylinderBtn_OnExecute;

            createAssemblyBtn = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition("Create Assembly", "createAssemblyBtn", CommandTypesEnum.kEditMaskCmdType);
            createAssemblyBtn.OnExecute += createAssemblyBtn_OnExecute;

            createWasherBtn = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition("Create Assembly", "createWasherBtn", CommandTypesEnum.kEditMaskCmdType);
            createWasherBtn.OnExecute += createWasherBtn_OnExecute;

            slotCmdCategory = m_inventorApplication.CommandManager.CommandCategories.Add("Slot", "Autodesk:YourAddIn:ShowTextCmd", GetAddInId());

            if (firstTime)
            {
                CreateRibbonPanel(GetAddInId(), addInSiteObject.Application);
            }

            // TODO: Add ApplicationAddInServer.Activate implementation.
            // e.g. event initialization, command creation etc.
        }

        private void createCylinderBtn_OnExecute(NameValueMap Context)
        {
            FormCylinder.FormCylinder form = new FormCylinder.FormCylinder();
            form.ShowDialog();

            CreateCylinder(form.radius, form.height);
        }

        private void createRectBtn_OnExecute(NameValueMap Context)
        {
            FormRectangular form = new FormRectangular();
            form.ShowDialog();

            CreateRectangularPrism(form.width, form.length, form.height);

        }

        private void createAssemblyBtn_OnExecute(NameValueMap Context)
        {
            AssemblyForm form = new AssemblyForm();
            form.ShowDialog();

            PartDocument partDoc = createRectangularPrism2("wall1", form.width, form.height, form.WALL_THICKNESS);

            CreateAssembly(partDoc);
        }

        private void createWasherBtn_OnExecute(NameValueMap Context)
        {
            WasherForm form = new WasherForm();
            form.ShowDialog();

            show("ID: " + form.ID.ToString());
            show("OD: " + form.OD.ToString());
            show("thickness: " + form.thickness.ToString());

            createWasher(form.ID, form.OD, form.thickness);
        }

        private void createWasher(double ID, double OD, double thickness)
        {
            try
            {
                PartDocument partDocument = (PartDocument)m_inventorApplication.ActiveDocument;
                PartComponentDefinition partComponentDefinition = partDocument.ComponentDefinition;
                PlanarSketch planarSketch = partComponentDefinition.Sketches.Add(partComponentDefinition.WorkPlanes[3]);

                Transaction createRectangularPrism = m_inventorApplication.TransactionManager.StartTransaction(m_inventorApplication.ActiveDocument, "Create circle sketch.");
                TransientGeometry transientGeometry = m_inventorApplication.TransientGeometry;
                planarSketch.SketchCircles.AddByCenterRadius(transientGeometry.CreatePoint2d(0, 0), ID); // Inner circle
                planarSketch.SketchCircles.AddByCenterRadius(transientGeometry.CreatePoint2d(0, 0), OD); // Outer circle

                Profile profile = planarSketch.Profiles.AddForSolid();
                ExtrudeDefinition extrudeDefinition = partComponentDefinition.Features.ExtrudeFeatures.CreateExtrudeDefinition(profile, PartFeatureOperationEnum.kJoinOperation);

                extrudeDefinition.SetDistanceExtent(thickness, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);

                ExtrudeFeature extrude = partComponentDefinition.Features.ExtrudeFeatures.Add(extrudeDefinition);


            }
            catch (Exception e)
            {
                show(e.ToString());
            }
        }

        private PartDocument createRectangularPrism2(String name, double width, double height, double thickness)
        {
            String filepath = partDirectory + name;

            PartDocument partDoc = (PartDocument) m_inventorApplication.Documents.Add(DocumentTypeEnum.kPartDocumentObject, "C:\\Users\\Public\\Documents\\Autodesk\\Inventor 2019\\Templates\\Standard.ipt", false);

            try
            {
                PartDocument partDocument = (PartDocument)m_inventorApplication.ActiveDocument;
                PartComponentDefinition partComponentDefinition = partDocument.ComponentDefinition;
                PlanarSketch planarSketch = partComponentDefinition.Sketches.Add(partComponentDefinition.WorkPlanes[3]);

                SketchLine[] lines = new SketchLine[4];

                TransientGeometry transientGeometry = m_inventorApplication.TransientGeometry;

                Transaction createRectangularPrism = m_inventorApplication.TransactionManager.StartTransaction(m_inventorApplication.ActiveDocument, "Create circle sketch.");

                SketchEntitiesEnumerator rectangle = planarSketch.SketchLines.AddAsTwoPointCenteredRectangle(transientGeometry.CreatePoint2d(0, 0), transientGeometry.CreatePoint2d(width, height));

                Profile profile = planarSketch.Profiles.AddForSolid();
                ExtrudeDefinition extrudeDefinition = partComponentDefinition.Features.ExtrudeFeatures.CreateExtrudeDefinition(profile, PartFeatureOperationEnum.kJoinOperation);

                extrudeDefinition.SetDistanceExtent(thickness, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);

                ExtrudeFeature extrude = partComponentDefinition.Features.ExtrudeFeatures.Add(extrudeDefinition);

                createRectangularPrism.End();
                planarSketch.ExitEdit();

                
            }
            catch (Exception e)
            {
                show(e.ToString());
            }


            return partDoc;
        }

        private void CreateAssembly(PartDocument partDocument)
        {
            AssemblyDocument assemblyDocument = (AssemblyDocument)m_inventorApplication.ActiveDocument;

            Matrix positionMatrix = m_inventorApplication.TransientGeometry.CreateMatrix();
            //ComponentOccurrence wall1 = assemblyDocument.ComponentDefinition.Occurrences.Add("C:\\Users\\Mckee\\Documents\\Coding\\C#\\InventorAddIn_UWP_v1\\AssemblyParts\\Wall.ipt", positionMatrix);
            ComponentDefinition partDocComponentDefinition = (ComponentDefinition)partDocument.ComponentDefinition;
            ComponentOccurrence wall1 = assemblyDocument.ComponentDefinition.Occurrences.AddByComponentDefinition(partDocComponentDefinition, positionMatrix);

            Vector translationVector = m_inventorApplication.TransientGeometry.CreateVector(2, 0, -1);
            positionMatrix.SetTranslation(translationVector);

            ComponentOccurrence wall2 = assemblyDocument.ComponentDefinition.Occurrences.AddByComponentDefinition(wall1.Definition, positionMatrix);
            ComponentOccurrence wall3 = assemblyDocument.ComponentDefinition.Occurrences.AddByComponentDefinition(wall1.Definition, positionMatrix);

            AssemblyComponentDefinition axisDef = (AssemblyComponentDefinition)assemblyDocument.ComponentDefinition;

            List<Face> wall1_faces = new List<Face>();
            List<Face> wall2_faces = new List<Face>();
            List<Face> wall3_faces = new List<Face>();

            if ((object)wall1 == null)
            {
                show("Wall1 is null");
            } else
            {
                show("Wall1 is not null");
            }

            try
            {
                foreach (Face face in wall1.SurfaceBodies)
                {
                    show(face.SurfaceType.ToString());
                    if (face.SurfaceType == SurfaceTypeEnum.kPlaneSurface)
                    {
                        wall1_faces.Add(face);
                    }
                }

                foreach (Face face in wall2.SurfaceBodies)
                {
                    if (face.SurfaceType == SurfaceTypeEnum.kPlaneSurface)
                    {
                        wall2_faces.Add(face);
                    }
                }

                foreach (Face face in wall3.SurfaceBodies)
                {
                    if (face.SurfaceType == SurfaceTypeEnum.kPlaneSurface)
                    {
                        wall3_faces.Add(face);
                    }
                }
            } catch (Exception e)
            {
                show(e.ToString());
            }
            show(wall1_faces.Count.ToString());
            axisDef.Constraints.AddMateConstraint(wall1_faces[5], wall2_faces[0], 0, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            axisDef.Constraints.AddMateConstraint(wall1_faces[0], wall2_faces[5], -.635, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            axisDef.Constraints.AddMateConstraint(wall1_faces[3], wall2_faces[1], 0, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            axisDef.Constraints.AddMateConstraint(wall1_faces[1], wall2_faces[3], 0, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            
            axisDef.Constraints.AddMateConstraint(wall1_faces[5], wall3_faces[0], 0, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            axisDef.Constraints.AddMateConstraint(wall1_faces[1], wall3_faces[4], -.635, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            axisDef.Constraints.AddMateConstraint(wall1_faces[0], wall3_faces[3], 0, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            axisDef.Constraints.AddMateConstraint(wall1_faces[2], wall3_faces[1], 0, InferredTypeEnum.kNoInference, InferredTypeEnum.kNoInference);
            


        }

        private void CreateCylinder(int radius, int height)
        {
            try
            {
                PartDocument partDocument = (PartDocument)m_inventorApplication.ActiveDocument;
                PartComponentDefinition partComponentDefinition = partDocument.ComponentDefinition;
                PlanarSketch planarSketch = partComponentDefinition.Sketches.Add(partComponentDefinition.WorkPlanes[3]);

                Transaction createRectangularPrism = m_inventorApplication.TransactionManager.StartTransaction(m_inventorApplication.ActiveDocument, "Create circle sketch.");

                TransientGeometry transientGeometry = m_inventorApplication.TransientGeometry;
                planarSketch.SketchCircles.AddByCenterRadius(transientGeometry.CreatePoint2d(0, 0), radius);

                Profile profile = planarSketch.Profiles.AddForSolid();
                ExtrudeDefinition extrudeDefinition = partComponentDefinition.Features.ExtrudeFeatures.CreateExtrudeDefinition(profile, PartFeatureOperationEnum.kJoinOperation);

                extrudeDefinition.SetDistanceExtent(height, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);

                ExtrudeFeature extrude = partComponentDefinition.Features.ExtrudeFeatures.Add(extrudeDefinition);


            } catch (Exception e)
            {
                show(e.ToString());
            }
        }


        private void CreateRectangularPrism(int width, int length, int height)
        {
            try
            {

                PartDocument partDocument = (PartDocument)m_inventorApplication.ActiveDocument;
                PartComponentDefinition partComponentDefinition = partDocument.ComponentDefinition;
                PlanarSketch planarSketch = partComponentDefinition.Sketches.Add(partComponentDefinition.WorkPlanes[3]);

                SketchLine[] lines = new SketchLine[4];

                TransientGeometry transientGeometry = m_inventorApplication.TransientGeometry;

                Transaction createRectangularPrism = m_inventorApplication.TransactionManager.StartTransaction(m_inventorApplication.ActiveDocument, "Create circle sketch.");

                SketchEntitiesEnumerator rectangle = planarSketch.SketchLines.AddAsTwoPointCenteredRectangle(transientGeometry.CreatePoint2d(0, 0), transientGeometry.CreatePoint2d(width, length));

                Profile profile = planarSketch.Profiles.AddForSolid();
                ExtrudeDefinition extrudeDefinition = partComponentDefinition.Features.ExtrudeFeatures.CreateExtrudeDefinition(profile, PartFeatureOperationEnum.kJoinOperation);

                extrudeDefinition.SetDistanceExtent(height, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);

                ExtrudeFeature extrude = partComponentDefinition.Features.ExtrudeFeatures.Add(extrudeDefinition);

                createRectangularPrism.End();
                planarSketch.ExitEdit();
            } catch (Exception e)
            {
                show(e.ToString());
            }
            
        }

        public void show(String message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }

        public void Deactivate()
        {
            // This method is called by Inventor when the AddIn is unloaded.
            // The AddIn will be unloaded either manually by the user or
            // when the Inventor session is terminated

            // TODO: Add ApplicationAddInServer.Deactivate implementation

            // Release objects.
            m_inventorApplication = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ExecuteCommand(int commandID)
        {
            // Note:this method is now obsolete, you should use the 
            // ControlDefinition functionality for implementing commands.
        }

        public object Automation
        {
            // This property is provided to allow the AddIn to expose an API 
            // of its own to other programs. Typically, this  would be done by
            // implementing the AddIn's API interface in a class and returning 
            // that class object through this property.

            get
            {
                // TODO: Add ApplicationAddInServer.Automation getter implementation
                return null;
            }
        }

        private string GetAddInId()
        {
            var id = (GuidAttribute)System.Attribute.GetCustomAttribute(typeof(StandardAddInServer), typeof(GuidAttribute));
            return "{" + id.Value + "}";
        }

        private void CreateRibbonPanel(string addinId, Application application)
        {
            if (addinId is null) throw new ArgumentNullException(nameof(addinId));
            if (application == null) throw new ArgumentNullException(nameof(application));

            var ribbons = application.UserInterfaceManager.Ribbons;
            var ribbonName = "Part";
            var idMyOwnTab = "id_Tab_MyOwnTab";
            var idMyOwnPanel = "id_Tab_MyOwnPanel";
            RibbonTab ribbonTab;

            if (!RibbonTabExists(application.UserInterfaceManager, ribbonName, idMyOwnTab))
            {
                ribbonTab = ribbons[ribbonName].RibbonTabs.Add("Custom Tools", idMyOwnTab, addinId);
            }
            else
            {
                ribbonTab = ribbons[ribbonName].RibbonTabs[idMyOwnTab];
            }

            if (RibbonPanelExists(application.UserInterfaceManager, ribbonName, idMyOwnTab, idMyOwnPanel)) return;

            var panel = ribbonTab.RibbonPanels.Add("Create", idMyOwnPanel, addinId, "", false);

            // slotCmdCategory.Add(createRectBtn);
            // panel.CommandControls.AddButton(createRectBtn);

            // slotCmdCategory.Add(createCylinderBtn);
            // panel.CommandControls.AddButton(createCylinderBtn);

            // slotCmdCategory.Add(createAssemblyBtn);
            // panel.CommandControls.AddButton(createAssemblyBtn);

            slotCmdCategory.Add(createWasherBtn);
            panel.CommandControls.AddButton(createWasherBtn);
        }

        private static bool RibbonTabExists(UserInterfaceManager userInterfaceManager, string ribbonName, string tabName)
        {
            var ribbons = userInterfaceManager.Ribbons;
            foreach (RibbonTab tab in ribbons[ribbonName].RibbonTabs)
            {
                if (tab.InternalName == tabName) return true;
            }

            return false;
        }

        private static bool RibbonPanelExists(UserInterfaceManager userInterfaceManager, string ribbonName, string tabName, string panelName)
        {
            var ribbons = userInterfaceManager.Ribbons;
            var ribbonTabAnnotate = ribbons[ribbonName].RibbonTabs[tabName];
            foreach (RibbonPanel ribbonPanel in ribbonTabAnnotate.RibbonPanels)
            {
                if (ribbonPanel.InternalName == panelName) return true;
            }

            return false;
        }
        #endregion

    }
}
