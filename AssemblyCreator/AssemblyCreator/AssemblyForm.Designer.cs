namespace AssemblyCreator
{
    partial class AssemblyForm
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
            this.createBtn = new System.Windows.Forms.Button();
            this.widthLbl = new System.Windows.Forms.Label();
            this.widthTxtBox = new System.Windows.Forms.TextBox();
            this.heightLbl = new System.Windows.Forms.Label();
            this.heightTxtBox = new System.Windows.Forms.TextBox();
            this.lengthLbl = new System.Windows.Forms.Label();
            this.lengthTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(9, 81);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(139, 23);
            this.createBtn.TabIndex = 0;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // widthLbl
            // 
            this.widthLbl.AutoSize = true;
            this.widthLbl.Location = new System.Drawing.Point(6, 7);
            this.widthLbl.Name = "widthLbl";
            this.widthLbl.Size = new System.Drawing.Size(35, 13);
            this.widthLbl.TabIndex = 1;
            this.widthLbl.Text = "Width";
            // 
            // widthTxtBox
            // 
            this.widthTxtBox.Location = new System.Drawing.Point(48, 4);
            this.widthTxtBox.Name = "widthTxtBox";
            this.widthTxtBox.Size = new System.Drawing.Size(100, 20);
            this.widthTxtBox.TabIndex = 2;
            // 
            // heightLbl
            // 
            this.heightLbl.AutoSize = true;
            this.heightLbl.Location = new System.Drawing.Point(6, 32);
            this.heightLbl.Name = "heightLbl";
            this.heightLbl.Size = new System.Drawing.Size(38, 13);
            this.heightLbl.TabIndex = 3;
            this.heightLbl.Text = "Height";
            // 
            // heightTxtBox
            // 
            this.heightTxtBox.Location = new System.Drawing.Point(47, 29);
            this.heightTxtBox.Name = "heightTxtBox";
            this.heightTxtBox.Size = new System.Drawing.Size(100, 20);
            this.heightTxtBox.TabIndex = 4;
            // 
            // lengthLbl
            // 
            this.lengthLbl.AutoSize = true;
            this.lengthLbl.Location = new System.Drawing.Point(6, 58);
            this.lengthLbl.Name = "lengthLbl";
            this.lengthLbl.Size = new System.Drawing.Size(40, 13);
            this.lengthLbl.TabIndex = 5;
            this.lengthLbl.Text = "Length";
            // 
            // lengthTxtBox
            // 
            this.lengthTxtBox.Location = new System.Drawing.Point(47, 55);
            this.lengthTxtBox.Name = "lengthTxtBox";
            this.lengthTxtBox.Size = new System.Drawing.Size(100, 20);
            this.lengthTxtBox.TabIndex = 6;
            // 
            // AssemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(153, 110);
            this.Controls.Add(this.lengthTxtBox);
            this.Controls.Add(this.lengthLbl);
            this.Controls.Add(this.heightTxtBox);
            this.Controls.Add(this.heightLbl);
            this.Controls.Add(this.widthTxtBox);
            this.Controls.Add(this.widthLbl);
            this.Controls.Add(this.createBtn);
            this.Name = "AssemblyForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Label widthLbl;
        private System.Windows.Forms.TextBox widthTxtBox;
        private System.Windows.Forms.Label heightLbl;
        private System.Windows.Forms.TextBox heightTxtBox;
        private System.Windows.Forms.Label lengthLbl;
        private System.Windows.Forms.TextBox lengthTxtBox;
    }
}

