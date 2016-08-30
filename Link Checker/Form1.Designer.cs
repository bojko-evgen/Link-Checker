namespace Link_Checker
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
            this.LinksList = new System.Windows.Forms.ListBox();
            this.InputTextbox = new System.Windows.Forms.TextBox();
            this.InfoHelper = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LinksList
            // 
            this.LinksList.AllowDrop = true;
            this.LinksList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinksList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LinksList.FormattingEnabled = true;
            this.LinksList.Location = new System.Drawing.Point(12, 51);
            this.LinksList.Name = "LinksList";
            this.LinksList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LinksList.Size = new System.Drawing.Size(260, 197);
            this.LinksList.TabIndex = 1;
            this.LinksList.DoubleClick += new System.EventHandler(this.LinksList_DoubleClick);
            this.LinksList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LinksList_KeyDown);
            // 
            // InputTextbox
            // 
            this.InputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextbox.Location = new System.Drawing.Point(12, 12);
            this.InputTextbox.Name = "InputTextbox";
            this.InputTextbox.Size = new System.Drawing.Size(260, 20);
            this.InputTextbox.TabIndex = 0;
            this.InputTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputTextbox_KeyDown);
            // 
            // InfoHelper
            // 
            this.InfoHelper.AutoSize = true;
            this.InfoHelper.Location = new System.Drawing.Point(13, 34);
            this.InfoHelper.Name = "InfoHelper";
            this.InfoHelper.Size = new System.Drawing.Size(0, 13);
            this.InfoHelper.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.InfoHelper);
            this.Controls.Add(this.InputTextbox);
            this.Controls.Add(this.LinksList);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Link checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LinksList;
        private System.Windows.Forms.TextBox InputTextbox;
        private System.Windows.Forms.Label InfoHelper;
    }
}

