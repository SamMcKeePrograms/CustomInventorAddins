using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace washer
{
    public partial class WasherForm : Form
    {

        public double OD;
        public double ID;
        public double thickness;
        public bool canCreateWasher = false;

        private int ID_COLUMN_INDEX = 1;
        private int OD_COLUMN_INDEX = 2;
        private int THICKNESS_COLUMN_INDEX = 3; 

        public WasherForm()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            Double ODEntered = Double.Parse(ODTxtBox.Text);
            Double IDEntered = Double.Parse(IDTxtBox.Text);
            Double thicknessEntered = Double.Parse(thicknessTxtBox.Text);
            MessageBox.Show("ODEntered: " + ODEntered.ToString());
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open("C:\\Users\\Mckee\\Documents\\Coding\\C#\\washer\\ExcelFiles\\Test.xlsx", 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet sheet = (Excel.Worksheet)app.ActiveWorkbook.Sheets[1];
            Excel.Range range = sheet.UsedRange;
            object misValue = System.Reflection.Missing.Value;

            for (int i=2; i<=range.Rows.Count; i++)
            {
                double tempID = range.Cells[i, ID_COLUMN_INDEX].Value2;
                double tempOD = range.Cells[i, OD_COLUMN_INDEX].Value2;
                double tempThickness = range.Cells[i, THICKNESS_COLUMN_INDEX].Value2;
                // MessageBox.Show("tempID: " + tempID.ToString());
                // MessageBox.Show("tempOD: " + tempOD.ToString());
                // MessageBox.Show("tempThickness: " + tempThickness.ToString());
                if (tempID != IDEntered && tempOD != ODEntered && tempThickness != thicknessEntered)
                {
                    canCreateWasher = true;
                    ID = IDEntered;
                    OD = ODEntered;
                    thickness = thicknessEntered;
                } else
                {
                    MessageBox.Show("CANT CREATE WASHER");
                    canCreateWasher = false;
                    i = range.Rows.Count + 1; 
                }
            }
            // MessageBox.Show(range.Rows.Count.ToString());
            if (range.Rows.Count == 1)
            {
                ID = IDEntered;
                OD = ODEntered;
                thickness = thicknessEntered;
                canCreateWasher = true;
            }

            if (canCreateWasher)
            {
                MessageBox.Show("Can create washer");
                range.Cells[range.Rows.Count + 1, ID_COLUMN_INDEX].Value2 = IDEntered;
                range.Cells[range.Rows.Count+1, OD_COLUMN_INDEX].Value2 = ODEntered;
                range.Cells[range.Rows.Count + 1, THICKNESS_COLUMN_INDEX].Value2 = thicknessEntered;
            } 

            wb.SaveAs("C:\\Users\\Mckee\\Documents\\Coding\\C#\\washer\\ExcelFiles\\Test.xlsx");
            wb.Close(true, misValue, misValue);
            app.Quit();

            releaseObject(sheet);
            releaseObject(wb);
            releaseObject(app);
            
            Close();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            } catch (Exception e)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + e.ToString());
            } finally
            {
                GC.Collect();
            }
        }
    }
}
