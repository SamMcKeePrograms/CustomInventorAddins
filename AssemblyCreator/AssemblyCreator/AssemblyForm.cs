using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyCreator
{
    public partial class AssemblyForm : Form
    {
        public double width;
        public double height;
        public double length;

        private double CM_TO_INCH = 0.393701;
        public double WALL_THICKNESS = .25;

        public AssemblyForm()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            width = Double.Parse(widthTxtBox.Text);
            height = Double.Parse(heightTxtBox.Text);
            length = Double.Parse(lengthTxtBox.Text);

            Close();
        }

    }
}
