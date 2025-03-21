namespace EQHelperClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnListen = new System.Windows.Forms.Button();
            this.LblNetworkInfo = new System.Windows.Forms.Label();
            this.LblDebug = new System.Windows.Forms.Label();
            this.ChkDebugMode = new System.Windows.Forms.CheckBox();
            this.BtnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnListen
            // 
            this.BtnListen.Location = new System.Drawing.Point(12, 12);
            this.BtnListen.Name = "BtnListen";
            this.BtnListen.Size = new System.Drawing.Size(126, 23);
            this.BtnListen.TabIndex = 0;
            this.BtnListen.Text = "Listen";
            this.BtnListen.UseVisualStyleBackColor = true;
            this.BtnListen.Click += new System.EventHandler(this.BtnListen_Click);
            // 
            // LblNetworkInfo
            // 
            this.LblNetworkInfo.Location = new System.Drawing.Point(12, 73);
            this.LblNetworkInfo.Name = "LblNetworkInfo";
            this.LblNetworkInfo.Size = new System.Drawing.Size(126, 16);
            this.LblNetworkInfo.TabIndex = 1;
            this.LblNetworkInfo.Text = "Info";
            this.LblNetworkInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDebug
            // 
            this.LblDebug.AutoSize = true;
            this.LblDebug.Location = new System.Drawing.Point(55, 130);
            this.LblDebug.Name = "LblDebug";
            this.LblDebug.Size = new System.Drawing.Size(39, 13);
            this.LblDebug.TabIndex = 2;
            this.LblDebug.Text = "Debug";
            // 
            // ChkDebugMode
            // 
            this.ChkDebugMode.AutoSize = true;
            this.ChkDebugMode.Location = new System.Drawing.Point(30, 96);
            this.ChkDebugMode.Name = "ChkDebugMode";
            this.ChkDebugMode.Size = new System.Drawing.Size(88, 17);
            this.ChkDebugMode.TabIndex = 3;
            this.ChkDebugMode.Text = "Debug Mode";
            this.ChkDebugMode.UseVisualStyleBackColor = true;
            this.ChkDebugMode.CheckedChanged += new System.EventHandler(this.ChkDebugMode_CheckedChanged);
            // 
            // BtnRestart
            // 
            this.BtnRestart.Location = new System.Drawing.Point(12, 41);
            this.BtnRestart.Name = "BtnRestart";
            this.BtnRestart.Size = new System.Drawing.Size(126, 23);
            this.BtnRestart.TabIndex = 4;
            this.BtnRestart.Text = "Restart";
            this.BtnRestart.UseVisualStyleBackColor = true;
            this.BtnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 159);
            this.Controls.Add(this.BtnRestart);
            this.Controls.Add(this.ChkDebugMode);
            this.Controls.Add(this.LblDebug);
            this.Controls.Add(this.LblNetworkInfo);
            this.Controls.Add(this.BtnListen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EQHelper Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnListen;
        private System.Windows.Forms.Label LblNetworkInfo;
        private System.Windows.Forms.Label LblDebug;
        private System.Windows.Forms.CheckBox ChkDebugMode;
        private System.Windows.Forms.Button BtnRestart;
    }
}

