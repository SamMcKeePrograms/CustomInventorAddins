namespace Inventor_Form_1
{
    partial class FormRectangular
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createCylinderButton = new System.Windows.Forms.Button();
            this.Radius = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createCylinderButton
            // 
            this.createCylinderButton.Location = new System.Drawing.Point(105, 185);
            this.createCylinderButton.Name = "createCylinderButton";
            this.createCylinderButton.Size = new System.Drawing.Size(143, 23);
            this.createCylinderButton.TabIndex = 0;
            this.createCylinderButton.Text = "Create";
            this.createCylinderButton.UseVisualStyleBackColor = true;
            this.createCylinderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Radius
            // 
            this.Radius.AutoSize = true;
            this.Radius.Location = new System.Drawing.Point(102, 103);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(35, 13);
            this.Radius.TabIndex = 1;
            this.Radius.Text = "Width";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Height";
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point(148, 100);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.Size = new System.Drawing.Size(100, 20);
            this.radiusTextBox.TabIndex = 3;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(148, 155);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Length";
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(148, 129);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.lengthTextBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 268);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.radiusTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Radius);
            this.Controls.Add(this.createCylinderButton);
            this.Name = "Form1";
            this.Text = "Create Rectangular Prism";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createCylinderButton;
        private System.Windows.Forms.Label Radius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lengthTextBox;
    }
}

