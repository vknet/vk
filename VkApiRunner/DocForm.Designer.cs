namespace VkApiRunner
{
    partial class DocForm
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
            this.lbTypes = new System.Windows.Forms.ListBox();
            this.lbMethods = new System.Windows.Forms.ListBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbTypes
            // 
            this.lbTypes.FormattingEnabled = true;
            this.lbTypes.Location = new System.Drawing.Point(12, 22);
            this.lbTypes.Name = "lbTypes";
            this.lbTypes.Size = new System.Drawing.Size(278, 173);
            this.lbTypes.TabIndex = 0;
            // 
            // lbMethods
            // 
            this.lbMethods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMethods.FormattingEnabled = true;
            this.lbMethods.Location = new System.Drawing.Point(13, 217);
            this.lbMethods.Name = "lbMethods";
            this.lbMethods.Size = new System.Drawing.Size(277, 160);
            this.lbMethods.TabIndex = 1;
            // 
            // txtDoc
            // 
            this.txtDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoc.Location = new System.Drawing.Point(297, 22);
            this.txtDoc.Multiline = true;
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(364, 355);
            this.txtDoc.TabIndex = 2;
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 399);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.lbMethods);
            this.Controls.Add(this.lbTypes);
            this.Name = "DocForm";
            this.Text = "DocForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTypes;
        private System.Windows.Forms.ListBox lbMethods;
        private System.Windows.Forms.TextBox txtDoc;
    }
}