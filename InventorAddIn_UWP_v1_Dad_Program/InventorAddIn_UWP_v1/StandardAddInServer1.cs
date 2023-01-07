using System;
using System.Runtime.InteropServices;
using Inventor;
using Microsoft.Win32;
using Inventor_Form_1;
using System.Diagnostics;


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
        private ButtonDefinition btn;

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
            btn = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition("Create Cylinder", "btn", CommandTypesEnum.kEditMaskCmdType);
            btn.OnExecute += Btn_OnExecute;

            if (firstTime)
            {
                CreateRibbonPanel(GetAddInId(), addInSiteObject.Application);
            }
            
            // TODO: Add ApplicationAddInServer.Activate implementation.
            // e.g. event initialization, command creation etc.
        }

        private void CreateNewPartDoc()
        {
            
        }

        private void Btn_OnExecute(NameValueMap Context)
        {                      
            Form1 form = new Form1();
            form.ShowDialog();


            Document inventordoc = m_inventorApplication.Documents.Add(Inventor.DocumentTypeEnum.kPartDocumentObject, "C:\\Users\\Public\\Documents\\Autodesk\\Inventor 2019\\Templates\\Standard.ipt", true);
            


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

        private void CreateRibbonPanel1(string addinId, Application application)
        {
            if (addinId is null) throw new ArgumentNullException(nameof(addinId));
            if (application == null) throw new ArgumentNullException(nameof(application));

            var ribbons = application.UserInterfaceManager.Ribbons;
            var ribbonName = "ZeroDoc";
            var idMyOwnTab = "id_Tab_MyOwnTab";
            var idMyOwnPanel = "id_Tab_MyOwnPanel";
            RibbonTab ribbonTab;

            if (!RibbonTabExists(application.UserInterfaceManager, ribbonName, idMyOwnTab))
            {
                ribbonTab = ribbons[ribbonName].RibbonTabs.Add("NoUseForAName", idMyOwnTab, addinId);
            }
            else
            {
                ribbonTab = ribbons[ribbonName].RibbonTabs[idMyOwnTab];
            }

            if (RibbonPanelExists(application.UserInterfaceManager, ribbonName, idMyOwnTab, idMyOwnPanel)) return;

            var panel = ribbonTab.RibbonPanels.Add("MyPanel", idMyOwnPanel, addinId, "", false);

            var buttonDescription = GetShowTextButton(addinId, application);
            panel.CommandControls.AddButton(buttonDescription);
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

            var buttonDescription = GetShowTextButton(addinId, application);
            panel.CommandControls.AddButton(buttonDescription);
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

        private ButtonDefinition GetShowTextButton(string addinId, Application application)
        {
            CommandCategory slotCmdCategory = application.CommandManager.CommandCategories.Add("Slot", "Autodesk:YourAddIn:ShowTextCmd", addinId);
            
            slotCmdCategory.Add(btn);
            
            return btn;
        }
        #endregion

    }
}
