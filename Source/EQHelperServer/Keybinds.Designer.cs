namespace EQHelperServer
{
    partial class Keybinds
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
            this.LstKeybinds = new System.Windows.Forms.ListBox();
            this.LblDuplicate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstKeybinds
            // 
            this.LstKeybinds.FormattingEnabled = true;
            this.LstKeybinds.Location = new System.Drawing.Point(0, 0);
            this.LstKeybinds.Name = "LstKeybinds";
            this.LstKeybinds.Size = new System.Drawing.Size(291, 173);
            this.LstKeybinds.TabIndex = 0;
            this.LstKeybinds.SelectedIndexChanged += new System.EventHandler(this.LstKeybinds_SelectedIndexChanged);
            // 
            // LblDuplicate
            // 
            this.LblDuplicate.AutoSize = true;
            this.LblDuplicate.Location = new System.Drawing.Point(125, 188);
            this.LblDuplicate.Name = "LblDuplicate";
            this.LblDuplicate.Size = new System.Drawing.Size(35, 13);
            this.LblDuplicate.TabIndex = 1;
            this.LblDuplicate.Text = "label1";
            // 
            // Keybinds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 265);
            this.Controls.Add(this.LblDuplicate);
            this.Controls.Add(this.LstKeybinds);
            this.Name = "Keybinds";
            this.Text = "Keybinds";
            this.Load += new System.EventHandler(this.Keybinds_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstKeybinds;
        private System.Windows.Forms.Label LblDuplicate;
    }
}