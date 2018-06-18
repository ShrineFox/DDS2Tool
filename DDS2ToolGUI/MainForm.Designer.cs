namespace DDS2ToolGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnRepack = new System.Windows.Forms.Button();
            this.lblUsage = new System.Windows.Forms.Label();
            this.lblUsage2 = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnExtract
            // 
            this.btnExtract.AllowDrop = true;
            this.btnExtract.Location = new System.Drawing.Point(12, 42);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(149, 155);
            this.btnExtract.TabIndex = 0;
            this.btnExtract.Text = "Drag Bustups to Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExtractDragDrop);
            this.btnExtract.DragEnter += new System.Windows.Forms.DragEventHandler(this.ExtractDragEnter);
            // 
            // btnRepack
            // 
            this.btnRepack.AllowDrop = true;
            this.btnRepack.Location = new System.Drawing.Point(167, 42);
            this.btnRepack.Name = "btnRepack";
            this.btnRepack.Size = new System.Drawing.Size(149, 155);
            this.btnRepack.TabIndex = 1;
            this.btnRepack.Text = "Drag Folders to Repack";
            this.btnRepack.UseVisualStyleBackColor = true;
            this.btnRepack.DragDrop += new System.Windows.Forms.DragEventHandler(this.RepackDragDrop);
            this.btnRepack.DragEnter += new System.Windows.Forms.DragEventHandler(this.RepackDragEnter);
            // 
            // lblUsage
            // 
            this.lblUsage.AutoSize = true;
            this.lblUsage.Location = new System.Drawing.Point(13, 13);
            this.lblUsage.Name = "lblUsage";
            this.lblUsage.Size = new System.Drawing.Size(261, 13);
            this.lblUsage.TabIndex = 2;
            this.lblUsage.Text = "Drag a .bin from the ps3.cpk/bustup folder to unpack.";
            // 
            // lblUsage2
            // 
            this.lblUsage2.AutoSize = true;
            this.lblUsage2.Location = new System.Drawing.Point(13, 26);
            this.lblUsage2.Name = "lblUsage2";
            this.lblUsage2.Size = new System.Drawing.Size(291, 13);
            this.lblUsage2.TabIndex = 3;
            this.lblUsage2.Text = "Or, drag a folder containing DDS to convert to a bustup .bin.";
            // 
            // githubLink
            // 
            this.githubLink.ActiveLinkColor = System.Drawing.Color.DarkOrange;
            this.githubLink.AutoSize = true;
            this.githubLink.LinkColor = System.Drawing.Color.DodgerBlue;
            this.githubLink.Location = new System.Drawing.Point(226, 200);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(92, 13);
            this.githubLink.TabIndex = 4;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "shrinefox.github.io";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 222);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.lblUsage2);
            this.Controls.Add(this.lblUsage);
            this.Controls.Add(this.btnRepack);
            this.Controls.Add(this.btnExtract);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(346, 261);
            this.MinimumSize = new System.Drawing.Size(346, 261);
            this.Name = "MainForm";
            this.Text = "DDS2 Tool GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnRepack;
        private System.Windows.Forms.Label lblUsage;
        private System.Windows.Forms.Label lblUsage2;
        private System.Windows.Forms.LinkLabel githubLink;
    }
}

