using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCylinder
{
    public partial class FormCylinder : Form
    {

        public int radius;
        public int height;

        public FormCylinder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radius = Int16.Parse(radiusTextBox.Text);
            height = Int16.Parse(heightTextBox.Text);

            this.Close();
        }
    }
}
