namespace EQHelperServer
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
            this.BtnConnect = new System.Windows.Forms.Button();
            this.LblConnectStatus = new System.Windows.Forms.Label();
            this.BtnConfig = new System.Windows.Forms.Button();
            this.BtnRestartServer = new System.Windows.Forms.Button();
            this.BtnExtra = new System.Windows.Forms.Button();
            this.PnlTimedKeybinds = new System.Windows.Forms.Panel();
            this.LblDebug = new System.Windows.Forms.Label();
            this.ChkDebug = new System.Windows.Forms.CheckBox();
            this.BtnRestartClients = new System.Windows.Forms.Button();
            this.BtnKeybinds = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(12, 12);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // LblConnectStatus
            // 
            this.LblConnectStatus.AutoSize = true;
            this.LblConnectStatus.Location = new System.Drawing.Point(9, 50);
            this.LblConnectStatus.Name = "LblConnectStatus";
            this.LblConnectStatus.Size = new System.Drawing.Size(37, 13);
            this.LblConnectStatus.TabIndex = 2;
            this.LblConnectStatus.Text = "Status";
            // 
            // BtnConfig
            // 
            this.BtnConfig.Location = new System.Drawing.Point(93, 13);
            this.BtnConfig.Name = "BtnConfig";
            this.BtnConfig.Size = new System.Drawing.Size(85, 22);
            this.BtnConfig.TabIndex = 3;
            this.BtnConfig.Text = "Edit Keybinds";
            this.BtnConfig.UseVisualStyleBackColor = true;
            this.BtnConfig.Click += new System.EventHandler(this.BtnConfig_Click);
            // 
            // BtnRestartServer
            // 
            this.BtnRestartServer.Location = new System.Drawing.Point(94, 97);
            this.BtnRestartServer.Name = "BtnRestartServer";
            this.BtnRestartServer.Size = new System.Drawing.Size(84, 23);
            this.BtnRestartServer.TabIndex = 4;
            this.BtnRestartServer.Text = "Restart Server";
            this.BtnRestartServer.UseVisualStyleBackColor = true;
            this.BtnRestartServer.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // BtnExtra
            // 
            this.BtnExtra.Location = new System.Drawing.Point(94, 69);
            this.BtnExtra.Name = "BtnExtra";
            this.BtnExtra.Size = new System.Drawing.Size(84, 22);
            this.BtnExtra.TabIndex = 5;
            this.BtnExtra.Text = "Extras";
            this.BtnExtra.UseVisualStyleBackColor = true;
            this.BtnExtra.Click += new System.EventHandler(this.BtnExtra_Click);
            // 
            // PnlTimedKeybinds
            // 
            this.PnlTimedKeybinds.Location = new System.Drawing.Point(16, 138);
            this.PnlTimedKeybinds.Name = "PnlTimedKeybinds";
            this.PnlTimedKeybinds.Size = new System.Drawing.Size(136, 58);
            this.PnlTimedKeybinds.TabIndex = 6;
            // 
            // LblDebug
            // 
            this.LblDebug.AutoSize = true;
            this.LblDebug.Location = new System.Drawing.Point(153, 224);
            this.LblDebug.Name = "LblDebug";
            this.LblDebug.Size = new System.Drawing.Size(39, 13);
            this.LblDebug.TabIndex = 0;
            this.LblDebug.Text = "Debug";
            // 
            // ChkDebug
            // 
            this.ChkDebug.AutoSize = true;
            this.ChkDebug.Location = new System.Drawing.Point(170, 204);
            this.ChkDebug.Name = "ChkDebug";
            this.ChkDebug.Size = new System.Drawing.Size(58, 17);
            this.ChkDebug.TabIndex = 7;
            this.ChkDebug.Text = "Debug";
            this.ChkDebug.UseVisualStyleBackColor = true;
            this.ChkDebug.CheckedChanged += new System.EventHandler(this.ChkDebug_CheckedChanged);
            // 
            // BtnRestartClients
            // 
            this.BtnRestartClients.Location = new System.Drawing.Point(12, 204);
            this.BtnRestartClients.Name = "BtnRestartClients";
            this.BtnRestartClients.Size = new System.Drawing.Size(30, 22);
            this.BtnRestartClients.TabIndex = 8;
            this.BtnRestartClients.Text = "Restart Clients ";
            this.BtnRestartClients.UseVisualStyleBackColor = true;
            this.BtnRestartClients.Visible = false;
            this.BtnRestartClients.Click += new System.EventHandler(this.BtnRestartClients_Click);
            // 
            // BtnKeybinds
            // 
            this.BtnKeybinds.Location = new System.Drawing.Point(94, 41);
            this.BtnKeybinds.Name = "BtnKeybinds";
            this.BtnKeybinds.Size = new System.Drawing.Size(84, 22);
            this.BtnKeybinds.TabIndex = 9;
            this.BtnKeybinds.Text = "View Keybinds";
            this.BtnKeybinds.UseVisualStyleBackColor = true;
            this.BtnKeybinds.Click += new System.EventHandler(this.BtnKeybinds_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 238);
            this.Controls.Add(this.BtnKeybinds);
            this.Controls.Add(this.BtnRestartClients);
            this.Controls.Add(this.ChkDebug);
            this.Controls.Add(this.LblDebug);
            this.Controls.Add(this.PnlTimedKeybinds);
            this.Controls.Add(this.BtnExtra);
            this.Controls.Add(this.BtnRestartServer);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.BtnConfig);
            this.Controls.Add(this.LblConnectStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EQHelper Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label LblConnectStatus;
        private System.Windows.Forms.Button BtnConfig;
        private System.Windows.Forms.Button BtnRestartServer;
        private System.Windows.Forms.Button BtnExtra;
        private System.Windows.Forms.Panel PnlTimedKeybinds;
        private System.Windows.Forms.Label LblDebug;
        private System.Windows.Forms.CheckBox ChkDebug;
        private System.Windows.Forms.Button BtnRestartClients;
        private System.Windows.Forms.Button BtnKeybinds;
    }
}

