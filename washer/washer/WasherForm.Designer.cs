namespace washer
{
    partial class WasherForm
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
            this.ODLbl = new System.Windows.Forms.Label();
            this.IDLbl = new System.Windows.Forms.Label();
            this.thicknessLbl = new System.Windows.Forms.Label();
            this.ODTxtBox = new System.Windows.Forms.TextBox();
            this.IDTxtBox = new System.Windows.Forms.TextBox();
            this.thicknessTxtBox = new System.Windows.Forms.TextBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ODLbl
            // 
            this.ODLbl.AutoSize = true;
            this.ODLbl.Location = new System.Drawing.Point(12, 9);
            this.ODLbl.Name = "ODLbl";
            this.ODLbl.Size = new System.Drawing.Size(23, 13);
            this.ODLbl.TabIndex = 0;
            this.ODLbl.Text = "OD";
            // 
            // IDLbl
            // 
            this.IDLbl.AutoSize = true;
            this.IDLbl.Location = new System.Drawing.Point(12, 31);
            this.IDLbl.Name = "IDLbl";
            this.IDLbl.Size = new System.Drawing.Size(18, 13);
            this.IDLbl.TabIndex = 1;
            this.IDLbl.Text = "ID";
            // 
            // thicknessLbl
            // 
            this.thicknessLbl.AutoSize = true;
            this.thicknessLbl.Location = new System.Drawing.Point(12, 53);
            this.thicknessLbl.Name = "thicknessLbl";
            this.thicknessLbl.Size = new System.Drawing.Size(56, 13);
            this.thicknessLbl.TabIndex = 2;
            this.thicknessLbl.Text = "Thickness";
            // 
            // ODTxtBox
            // 
            this.ODTxtBox.Location = new System.Drawing.Point(65, 9);
            this.ODTxtBox.Name = "ODTxtBox";
            this.ODTxtBox.Size = new System.Drawing.Size(100, 20);
            this.ODTxtBox.TabIndex = 3;
            // 
            // IDTxtBox
            // 
            this.IDTxtBox.Location = new System.Drawing.Point(65, 30);
            this.IDTxtBox.Name = "IDTxtBox";
            this.IDTxtBox.Size = new System.Drawing.Size(100, 20);
            this.IDTxtBox.TabIndex = 4;
            // 
            // thicknessTxtBox
            // 
            this.thicknessTxtBox.Location = new System.Drawing.Point(65, 50);
            this.thicknessTxtBox.Name = "thicknessTxtBox";
            this.thicknessTxtBox.Size = new System.Drawing.Size(100, 20);
            this.thicknessTxtBox.TabIndex = 5;
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(12, 76);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(153, 23);
            this.createBtn.TabIndex = 6;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 107);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.thicknessTxtBox);
            this.Controls.Add(this.IDTxtBox);
            this.Controls.Add(this.ODTxtBox);
            this.Controls.Add(this.thicknessLbl);
            this.Controls.Add(this.IDLbl);
            this.Controls.Add(this.ODLbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ODLbl;
        private System.Windows.Forms.Label IDLbl;
        private System.Windows.Forms.Label thicknessLbl;
        private System.Windows.Forms.TextBox ODTxtBox;
        private System.Windows.Forms.TextBox IDTxtBox;
        private System.Windows.Forms.TextBox thicknessTxtBox;
        private System.Windows.Forms.Button createBtn;
    }
}

