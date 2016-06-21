namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.Enroll = new System.Windows.Forms.Button();
            this.Unenroll = new System.Windows.Forms.Button();
            this.PrintList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Enroll
            // 
            this.Enroll.Location = new System.Drawing.Point(99, 43);
            this.Enroll.Name = "Enroll";
            this.Enroll.Size = new System.Drawing.Size(75, 23);
            this.Enroll.TabIndex = 0;
            this.Enroll.Text = "Enroll";
            this.Enroll.UseVisualStyleBackColor = true;
            this.Enroll.Click += new System.EventHandler(this.button1_Click);
            // 
            // Unenroll
            // 
            this.Unenroll.Location = new System.Drawing.Point(99, 107);
            this.Unenroll.Name = "Unenroll";
            this.Unenroll.Size = new System.Drawing.Size(75, 23);
            this.Unenroll.TabIndex = 1;
            this.Unenroll.Text = "Unenroll";
            this.Unenroll.UseVisualStyleBackColor = true;
            // 
            // PrintList
            // 
            this.PrintList.Location = new System.Drawing.Point(99, 193);
            this.PrintList.Name = "PrintList";
            this.PrintList.Size = new System.Drawing.Size(75, 23);
            this.PrintList.TabIndex = 2;
            this.PrintList.Text = "Print List";
            this.PrintList.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.PrintList);
            this.Controls.Add(this.Unenroll);
            this.Controls.Add(this.Enroll);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Enroll;
        private System.Windows.Forms.Button Unenroll;
        private System.Windows.Forms.Button PrintList;
    }
}

