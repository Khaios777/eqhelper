using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EQHelperCore;
using SharpConfig;

namespace EQHelperServer
{
    public partial class Config : Form
    {
        MainSettings.Character characterSettings;

        string characterSettingsFolder = Global.characterSettingsFolder;
        string fullClientCommand = "";

        public Config()
        {
            

            InitializeComponent();
            Global.LoadCharacterDropdown(DdlCharacter);

            this.Opacity = 0.8;

            if (DdlCharacter.Items.Count > 1)
                DdlCharacter.SelectedIndex = 1;
        }

        private void LoadCharacterSettings()
        {
            string characterSettingsFile = characterSettingsFolder + DdlCharacter.SelectedItem.ToString() + "\\Settings.ini";
            characterSettings = new MainSettings.Character(DdlCharacter.SelectedItem.ToString()); // initialize new settings class with character selected

            Configuration config = Configuration.LoadFromFile(characterSettingsFile);

            Section settingKeyBindings = config["Keybindings"];

            LstKeybinds.Items.Clear();
            TxtEditCommand.Text = "";
            TxtFullCommand.Text = "";
            TxtSelectedKeybind.Text = "";

            foreach (Setting setting in settingKeyBindings)
            {
                string str = setting.Name + " = " + setting.StringValue;
                LstKeybinds.Items.Add(str);
            }


        }

        private void BtnAddCharacter_Click(object sender, EventArgs e)
        {
            string settingsPath = characterSettingsFolder + TxtAddCharacter.Text;

            Directory.CreateDirectory(settingsPath); // create folder for new character
            characterSettings.CreateDefaultIniFile();
            //CreateDefaultIniFile(settingsPath); // create the default ini file in newly created folder

            TxtAddCharacter.Text = "";
            Global.LoadCharacterDropdown(DdlCharacter);
        }


        private void TxtKeybindLeftCommand_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            TxtKeybindLeftCommand.Text = e.KeyValue.ToString();
            UpdateFullCommand();
        }

        private void TxtKeybindLeftCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtKeybindRightCommand_KeyDown(object sender, KeyEventArgs e)
        {

            e.Handled = true;
            
            TxtKeybindRightCommand.Text = "";

            if (e.Alt)
            {
                TxtKeybindRightCommand.Text += "!";
            }

            if (e.Shift)
            {
                TxtKeybindRightCommand.Text += "+";
            }

            if (e.Control)
            {
                TxtKeybindRightCommand.Text += "^";
            }

            TxtKeybindRightCommand.Text += (char)(e.KeyValue);
        }

        private void TxtKeybindRightCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            //TxtKeybindRightCommand.Text = e.KeyChar.ToString();
        }


        private void DdlCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCharacterSettings();

            GbxCharacterSettings.Visible = true;
        }

        private void BtnClearCommand_Click(object sender, EventArgs e)
        {
            TxtKeybindLeftCommand.Text = "";
            TxtKeybindRightCommand.Text = "";
            TxtClientWait.Text = "";
            TxtFullCommand.Text = "";
            fullClientCommand = "";
        }

        private void BtnAddCommand_Click(object sender, EventArgs e)
        {
            characterSettings.AddKeybinding(TxtKeybindLeftCommand.Text, fullClientCommand); // add new keybinding to ini file
            LstKeybinds.Items.Add(TxtKeybindLeftCommand.Text + " = " + fullClientCommand); // add keybinding to listbox in config UI
        }

        private void BtnAddClientCommand_Click(object sender, EventArgs e)
        {
            if (fullClientCommand != "")
                fullClientCommand = fullClientCommand + "|";

            fullClientCommand = fullClientCommand + TxtKeybindRightCommand.Text;
            UpdateFullCommand();
        }
        private void BtnAddClientWait_Click(object sender, EventArgs e)
        {
            if (fullClientCommand != "")
                fullClientCommand = fullClientCommand + "|";

            fullClientCommand = fullClientCommand + "/wait " + TxtClientWait.Text;
            UpdateFullCommand();
        }

        private void UpdateFullCommand()
        {
            TxtFullCommand.Text = TxtKeybindLeftCommand.Text + " = " + fullClientCommand;
        }

        private void TxtKeybindRightCommand_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadCharacter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Config_Load(object sender, EventArgs e)
        {

        }

        private void LstKeybinds_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = LstKeybinds.SelectedItem.ToString();

            if (val.Contains("="))
                val = val.Split('=')[0].ToString().Trim();

            string keyValue = val;
            string keybindText = "";
            //string characterName = keybind.PlayerClientRef.Name;
            //str = keybind.CommandToSend 

            //str +=

            if (keyValue.StartsWith("A"))
            {
                keybindText += "ALT + ";
                keyValue = keyValue.Split('A')[1];
            }

            if (keyValue.StartsWith("*"))
            {
                keybindText += "(ALL) ";
                keyValue = keyValue.Split('*')[1];
            }
            
            int val2 = Int16.Parse(keyValue);

            keybindText += ((Keys)val2).ToString();

            TxtSelectedKeybind.Text = keybindText;

        }

        private void BtnEditKeybind_Click(object sender, EventArgs e)
        {
            TxtMacroTime.Text = "0";

            string val = LstKeybinds.SelectedItem.ToString();

            if (val.Contains("="))
                val = val.Split('=')[1].ToString().Trim();

            string[] commands = val.Split('|');

            foreach (string command in commands)
            {
                TxtEditCommand.Text += command + Environment.NewLine;
                UpdateTotalMacroTime(command);
            }
        }

        private void BtnFinishEdit_Click(object sender, EventArgs e)
        {
            string keyCode = LstKeybinds.SelectedItem.ToString();

            if (keyCode.Contains("="))
                keyCode = keyCode.Split('=')[0].ToString().Trim();

            string fullCommand = TxtEditCommand.Text.Replace(Environment.NewLine, "|");

            characterSettings.EditCharacterSetting("Keybindings", keyCode, fullCommand);

            LoadCharacterSettings();
        }
        
        private void UpdateTotalMacroTime(string command)
        {
            if (command.StartsWith("/wait"))
            {
                int milliseconds = Convert.ToInt32(command.Replace("/wait", "").Trim()); // get everything after the /wait command
                TxtMacroTime.Text = (int.Parse(TxtMacroTime.Text) + milliseconds).ToString();
            }
        }

    }
}
