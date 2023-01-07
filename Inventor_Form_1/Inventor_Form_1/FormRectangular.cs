using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventor_Form_1
{
    public partial class FormRectangular : Form
    {
        public int width;
        public int height;
        public int length;

        public FormRectangular()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            width = Int16.Parse(radiusTextBox.Text);
            length = Int16.Parse(lengthTextBox.Text);
            height = Int16.Parse(heightTextBox.Text);

            this.Close();

        }
    }
}
