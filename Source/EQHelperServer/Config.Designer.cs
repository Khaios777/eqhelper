namespace EQHelperServer
{
    partial class Config
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
            this.GbxCharacterSettings = new System.Windows.Forms.GroupBox();
            this.BtnFinishEdit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtEditCommand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtSelectedKeybind = new System.Windows.Forms.TextBox();
            this.BtnEditKeybind = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnAddClientCommand = new System.Windows.Forms.Button();
            this.BtnClearCommand = new System.Windows.Forms.Button();
            this.BtnAddClientWait = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtFullCommand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtClientWait = new System.Windows.Forms.TextBox();
            this.LstKeybinds = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtKeybindRightCommand = new System.Windows.Forms.TextBox();
            this.TxtKeybindLeftCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddCommand = new System.Windows.Forms.Button();
            this.DdlCharacter = new System.Windows.Forms.ComboBox();
            this.TxtAddCharacter = new System.Windows.Forms.TextBox();
            this.BtnAddCharacter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TxtMacroTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GbxCharacterSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbxCharacterSettings
            // 
            this.GbxCharacterSettings.Controls.Add(this.label10);
            this.GbxCharacterSettings.Controls.Add(this.TxtMacroTime);
            this.GbxCharacterSettings.Controls.Add(this.BtnFinishEdit);
            this.GbxCharacterSettings.Controls.Add(this.label9);
            this.GbxCharacterSettings.Controls.Add(this.TxtEditCommand);
            this.GbxCharacterSettings.Controls.Add(this.label7);
            this.GbxCharacterSettings.Controls.Add(this.TxtSelectedKeybind);
            this.GbxCharacterSettings.Controls.Add(this.BtnEditKeybind);
            this.GbxCharacterSettings.Controls.Add(this.label8);
            this.GbxCharacterSettings.Controls.Add(this.BtnAddClientCommand);
            this.GbxCharacterSettings.Controls.Add(this.BtnClearCommand);
            this.GbxCharacterSettings.Controls.Add(this.BtnAddClientWait);
            this.GbxCharacterSettings.Controls.Add(this.label6);
            this.GbxCharacterSettings.Controls.Add(this.TxtFullCommand);
            this.GbxCharacterSettings.Controls.Add(this.label5);
            this.GbxCharacterSettings.Controls.Add(this.TxtClientWait);
            this.GbxCharacterSettings.Controls.Add(this.LstKeybinds);
            this.GbxCharacterSettings.Controls.Add(this.label4);
            this.GbxCharacterSettings.Controls.Add(this.TxtKeybindRightCommand);
            this.GbxCharacterSettings.Controls.Add(this.TxtKeybindLeftCommand);
            this.GbxCharacterSettings.Controls.Add(this.label1);
            this.GbxCharacterSettings.Location = new System.Drawing.Point(12, 57);
            this.GbxCharacterSettings.Name = "GbxCharacterSettings";
            this.GbxCharacterSettings.Size = new System.Drawing.Size(538, 447);
            this.GbxCharacterSettings.TabIndex = 2;
            this.GbxCharacterSettings.TabStop = false;
            this.GbxCharacterSettings.Text = "Character Settings (Make sure Numlock is on)";
            this.GbxCharacterSettings.Visible = false;
            // 
            // BtnFinishEdit
            // 
            this.BtnFinishEdit.Location = new System.Drawing.Point(415, 409);
            this.BtnFinishEdit.Name = "BtnFinishEdit";
            this.BtnFinishEdit.Size = new System.Drawing.Size(117, 23);
            this.BtnFinishEdit.TabIndex = 21;
            this.BtnFinishEdit.Text = "Save Changes";
            this.BtnFinishEdit.UseVisualStyleBackColor = true;
            this.BtnFinishEdit.Click += new System.EventHandler(this.BtnFinishEdit_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(355, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 26);
            this.label9.TabIndex = 19;
            this.label9.Text = "Edit \r\nCommand";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtEditCommand
            // 
            this.TxtEditCommand.Location = new System.Drawing.Point(415, 19);
            this.TxtEditCommand.Multiline = true;
            this.TxtEditCommand.Name = "TxtEditCommand";
            this.TxtEditCommand.Size = new System.Drawing.Size(117, 384);
            this.TxtEditCommand.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Keybind";
            // 
            // TxtSelectedKeybind
            // 
            this.TxtSelectedKeybind.Enabled = false;
            this.TxtSelectedKeybind.Location = new System.Drawing.Point(289, 265);
            this.TxtSelectedKeybind.Name = "TxtSelectedKeybind";
            this.TxtSelectedKeybind.Size = new System.Drawing.Size(91, 20);
            this.TxtSelectedKeybind.TabIndex = 16;
            // 
            // BtnEditKeybind
            // 
            this.BtnEditKeybind.Location = new System.Drawing.Point(289, 297);
            this.BtnEditKeybind.Name = "BtnEditKeybind";
            this.BtnEditKeybind.Size = new System.Drawing.Size(75, 23);
            this.BtnEditKeybind.TabIndex = 15;
            this.BtnEditKeybind.Text = "Edit";
            this.BtnEditKeybind.UseVisualStyleBackColor = true;
            this.BtnEditKeybind.Click += new System.EventHandler(this.BtnEditKeybind_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(116, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Keybinds";
            // 
            // BtnAddClientCommand
            // 
            this.BtnAddClientCommand.Location = new System.Drawing.Point(127, 92);
            this.BtnAddClientCommand.Name = "BtnAddClientCommand";
            this.BtnAddClientCommand.Size = new System.Drawing.Size(26, 23);
            this.BtnAddClientCommand.TabIndex = 12;
            this.BtnAddClientCommand.Text = "+";
            this.BtnAddClientCommand.UseVisualStyleBackColor = true;
            this.BtnAddClientCommand.Click += new System.EventHandler(this.BtnAddClientCommand_Click);
            // 
            // BtnClearCommand
            // 
            this.BtnClearCommand.Location = new System.Drawing.Point(170, 145);
            this.BtnClearCommand.Name = "BtnClearCommand";
            this.BtnClearCommand.Size = new System.Drawing.Size(75, 23);
            this.BtnClearCommand.TabIndex = 11;
            this.BtnClearCommand.Text = "Clear";
            this.BtnClearCommand.UseVisualStyleBackColor = true;
            this.BtnClearCommand.Click += new System.EventHandler(this.BtnClearCommand_Click);
            // 
            // BtnAddClientWait
            // 
            this.BtnAddClientWait.Location = new System.Drawing.Point(219, 92);
            this.BtnAddClientWait.Name = "BtnAddClientWait";
            this.BtnAddClientWait.Size = new System.Drawing.Size(26, 23);
            this.BtnAddClientWait.TabIndex = 8;
            this.BtnAddClientWait.Text = "+";
            this.BtnAddClientWait.UseVisualStyleBackColor = true;
            this.BtnAddClientWait.Click += new System.EventHandler(this.BtnAddClientWait_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Full Command";
            // 
            // TxtFullCommand
            // 
            this.TxtFullCommand.Enabled = false;
            this.TxtFullCommand.Location = new System.Drawing.Point(16, 147);
            this.TxtFullCommand.Name = "TxtFullCommand";
            this.TxtFullCommand.Size = new System.Drawing.Size(148, 20);
            this.TxtFullCommand.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Wait";
            // 
            // TxtClientWait
            // 
            this.TxtClientWait.Location = new System.Drawing.Point(175, 94);
            this.TxtClientWait.Name = "TxtClientWait";
            this.TxtClientWait.Size = new System.Drawing.Size(38, 20);
            this.TxtClientWait.TabIndex = 7;
            // 
            // LstKeybinds
            // 
            this.LstKeybinds.FormattingEnabled = true;
            this.LstKeybinds.Location = new System.Drawing.Point(20, 265);
            this.LstKeybinds.Name = "LstKeybinds";
            this.LstKeybinds.Size = new System.Drawing.Size(263, 95);
            this.LstKeybinds.TabIndex = 6;
            this.LstKeybinds.SelectedIndexChanged += new System.EventHandler(this.LstKeybinds_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Client Command";
            // 
            // TxtKeybindRightCommand
            // 
            this.TxtKeybindRightCommand.Location = new System.Drawing.Point(21, 92);
            this.TxtKeybindRightCommand.Name = "TxtKeybindRightCommand";
            this.TxtKeybindRightCommand.Size = new System.Drawing.Size(100, 20);
            this.TxtKeybindRightCommand.TabIndex = 3;
            this.TxtKeybindRightCommand.TextChanged += new System.EventHandler(this.TxtKeybindRightCommand_TextChanged);
            this.TxtKeybindRightCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeybindRightCommand_KeyDown);
            this.TxtKeybindRightCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeybindRightCommand_KeyPress);
            // 
            // TxtKeybindLeftCommand
            // 
            this.TxtKeybindLeftCommand.Location = new System.Drawing.Point(20, 50);
            this.TxtKeybindLeftCommand.Name = "TxtKeybindLeftCommand";
            this.TxtKeybindLeftCommand.Size = new System.Drawing.Size(100, 20);
            this.TxtKeybindLeftCommand.TabIndex = 2;
            this.TxtKeybindLeftCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeybindLeftCommand_KeyDown);
            this.TxtKeybindLeftCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeybindLeftCommand_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Command";
            // 
            // BtnAddCommand
            // 
            this.BtnAddCommand.Location = new System.Drawing.Point(38, 64);
            this.BtnAddCommand.Name = "BtnAddCommand";
            this.BtnAddCommand.Size = new System.Drawing.Size(75, 23);
            this.BtnAddCommand.TabIndex = 1;
            this.BtnAddCommand.Text = "Add";
            this.BtnAddCommand.UseVisualStyleBackColor = true;
            this.BtnAddCommand.Click += new System.EventHandler(this.BtnAddCommand_Click);
            // 
            // DdlCharacter
            // 
            this.DdlCharacter.FormattingEnabled = true;
            this.DdlCharacter.Location = new System.Drawing.Point(12, 26);
            this.DdlCharacter.Name = "DdlCharacter";
            this.DdlCharacter.Size = new System.Drawing.Size(121, 21);
            this.DdlCharacter.TabIndex = 3;
            this.DdlCharacter.SelectedIndexChanged += new System.EventHandler(this.DdlCharacter_SelectedIndexChanged);
            // 
            // TxtAddCharacter
            // 
            this.TxtAddCharacter.Location = new System.Drawing.Point(38, 38);
            this.TxtAddCharacter.Name = "TxtAddCharacter";
            this.TxtAddCharacter.Size = new System.Drawing.Size(77, 20);
            this.TxtAddCharacter.TabIndex = 4;
            // 
            // BtnAddCharacter
            // 
            this.BtnAddCharacter.Location = new System.Drawing.Point(121, 36);
            this.BtnAddCharacter.Name = "BtnAddCharacter";
            this.BtnAddCharacter.Size = new System.Drawing.Size(26, 23);
            this.BtnAddCharacter.TabIndex = 5;
            this.BtnAddCharacter.Text = "+";
            this.BtnAddCharacter.UseVisualStyleBackColor = true;
            this.BtnAddCharacter.Click += new System.EventHandler(this.BtnAddCharacter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add Character";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Character";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtAddCharacter);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.BtnAddCommand);
            this.groupBox2.Controls.Add(this.BtnAddCharacter);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(167, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(71, 39);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(119, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(91, 20);
            this.textBox2.TabIndex = 20;
            // 
            // TxtMacroTime
            // 
            this.TxtMacroTime.Enabled = false;
            this.TxtMacroTime.Location = new System.Drawing.Point(305, 411);
            this.TxtMacroTime.Name = "TxtMacroTime";
            this.TxtMacroTime.Size = new System.Drawing.Size(100, 20);
            this.TxtMacroTime.TabIndex = 22;
            this.TxtMacroTime.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Total Macro Time:";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DdlCharacter);
            this.Controls.Add(this.GbxCharacterSettings);
            this.Name = "Config";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.GbxCharacterSettings.ResumeLayout(false);
            this.GbxCharacterSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxCharacterSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DdlCharacter;
        private System.Windows.Forms.TextBox TxtAddCharacter;
        private System.Windows.Forms.Button BtnAddCharacter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtKeybindLeftCommand;
        private System.Windows.Forms.Button BtnAddCommand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtKeybindRightCommand;
        private System.Windows.Forms.ListBox LstKeybinds;
        private System.Windows.Forms.Button BtnAddClientWait;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtFullCommand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtClientWait;
        private System.Windows.Forms.Button BtnClearCommand;
        private System.Windows.Forms.Button BtnAddClientCommand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtSelectedKeybind;
        private System.Windows.Forms.Button BtnEditKeybind;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnFinishEdit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtEditCommand;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtMacroTime;
    }
}