using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EQHelperCore;
using EQHelperServer;
using System.Threading;

namespace EQHelperServer
{
    public partial class Extra : Form
    {
        List<PlayerClient> playerClients; 
        List<PlayerClientKeybind> playerClientKeybinds;
        MainSettings mainSettings;

        public Extra(List<PlayerClient> _playerClients, List<PlayerClientKeybind> _playerClientKeybinds, MainSettings _mainSettings)
        {
            InitializeComponent();
            


            playerClients = _playerClients;
            playerClientKeybinds = _playerClientKeybinds;
            mainSettings = _mainSettings;

            FillEnabledSection();
            FillButtonSection();

            Global.LoadCharacterDropdown(DdlCharacter, true);

            this.Opacity = 0.8;


        }

        private void SendCommand(string command, int wait = 0)
        {
            
            if (DdlCharacter.Text == "All")
            {

                int numClientsSentTo = 0; // this is used to keep track of how many people it's sent the command to. will add a delay to each command so it doesn't send all at the same time and disconnect user

                foreach (PlayerClient playerClient in playerClients)
                {
                    if (playerClient.Enabled)
                    {
                        //string commandToSend = p1.CommandToSend;
                        if (numClientsSentTo > 0)
                            command = "/wait " + Convert.ToString(numClientsSentTo * 400) + "|" + command; //append a 700 millisecond wait time to beginning

                        playerClient.Send(command);
                        numClientsSentTo += 1;
                    }

                }

            }
            else // send command only to that character
            {
                PlayerClient playerClient = playerClients.Find(item => item.Name.Equals(DdlCharacter.Text));

                playerClient.Send(command);
            }
        }

        private void BtnAcceptInvite_Click(object sender, EventArgs e)
        {
            SendCommand("^i");
        }

        private void BtnAutoRun_Click(object sender, EventArgs e)
        {
            SendCommand("r");
        }

        private void BtnBackUp_Click(object sender, EventArgs e)
        {
            SendCommand("{s down}|/wait 1000|{s up}");
        }

        private void BtnResetCamera_Click(object sender, EventArgs e)
        {
            SendCommand("{HOME}");
        }

        private void BtnLookUp_Click(object sender, EventArgs e)
        {
            SendCommand("{PGUP down}|/wait 200|{PGUP up}");
        }

        private void BtnLookDown_Click(object sender, EventArgs e)
        {
            SendCommand("{PGDN down}|/wait 200|{PGDN up}");
        }


        private void BtnPick_Click(object sender, EventArgs e)
        {
            SendCommand("/pick|/wait 1000|{ENTER}");
        }

        private void BtnSay_Click(object sender, EventArgs e)
        {
            SendCommand("{ENTER}|/wait 1000|" + TxtSayCommand.Text + "|/wait 1000|{ENTER}", 200);
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            SendCommand("/zoomin");
        }
        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            SendCommand("/zoomout");
        }

        public void FillEnabledSection()
        {
            int startingX = 0;
            int startingY = 0;

            foreach (PlayerClient playerClient in playerClients)
            {
                CheckBox chkEnabled = new CheckBox();
                chkEnabled.Text = playerClient.Name;
                chkEnabled.Checked = playerClient.Enabled;

                //chkTimedKeybinding.Enabled = false;
                //chkEnabled.AutoCheck = false;
                chkEnabled.Location = new Point(startingX, startingY);
                chkEnabled.Width = 250;
                chkEnabled.CheckedChanged += (sender, e) => ToggleUserEnable(chkEnabled, playerClient);
                //chkTimedKeybinding.back

                //playerClientKeybind.TimedCheckbox = chkEnabled;

                PnlEnabledUsers.Controls.Add(chkEnabled);

                startingY = startingY + 20;
                
            }
        }

        public void FillButtonSection()
        {
            int startingX = 0;
            int startingY = 0;

            int startingY1 = 0;
            int startingY2 = 0;
            int startingY3 = 0;

            List<string> buttonsAdded = new List<string>();

            List<PlayerClientKeybind> sortedKeybinds = playerClientKeybinds.OrderBy(k=>k.ButtonLabelText).ToList();

            foreach (PlayerClientKeybind playerClientKeybind in sortedKeybinds)
            {
                if (playerClientKeybind.ButtonLabelText + "" != "")
                {
                    string buttonText = playerClientKeybind.ButtonLabelText;
                    // dont add duplicate buttons if they are bound to multiple characters
                    if (!buttonsAdded.Contains(buttonText))
                    {
                        buttonsAdded.Add(buttonText);
                        Panel pnl = PnlButtons;
                        Button btnKeybinding = new Button();

                        if (buttonText.StartsWith("A-"))
                        {
                            pnl = PnlButtons;
                            buttonText = buttonText.Split('-').Last();
                            startingY = startingY1;
                            startingY1 = startingY1 + 30;
                        }
                        else if (buttonText.StartsWith("B-"))
                        {
                            pnl = PnlButtons2;
                            buttonText = buttonText.Split('-').Last();
                            startingY = startingY2;
                            startingY2 = startingY2 + 30;
                        }
                        else if (buttonText.StartsWith("C-"))
                        {
                            pnl = PnlButtons3;
                            buttonText = buttonText.Split('-').Last();
                            startingY = startingY3;
                            startingY3 = startingY3 + 30;
                        }
                        else
                        {

                        }

                        btnKeybinding.Text = buttonText;
                        btnKeybinding.Width = 100;
                        btnKeybinding.Click += new EventHandler(ButtonClickEvent);
                        btnKeybinding.Location = new Point(startingX, startingY);
                        btnKeybinding.Tag = playerClientKeybind.KeyValue + "=" + playerClientKeybind.CommandToSend;

                        pnl.Controls.Add(btnKeybinding);

                        pnl.Height += 20;

                        this.Height += 10;

                        
                    }
                    
                }
            }
        }

        private void ButtonClickEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string keyValue = btn.Tag.ToString().Split('=')[0].ToString().Trim();
            string command = btn.Tag.ToString().Split('=')[1].ToString().Trim();

            int numClientsSentTo = 0;

            List<PlayerClientKeybind> foundClientKeybinds = playerClientKeybinds.FindAll(item => item.KeyValue.Equals(keyValue));

            foreach (PlayerClientKeybind p1 in foundClientKeybinds)
            {
                if (p1.PlayerClientRef.Enabled)
                {
                    string commandToSend = p1.CommandToSend;
                    if (numClientsSentTo > 0)
                        commandToSend = "/wait " + Convert.ToString(numClientsSentTo * 400) + "|" + p1.CommandToSend; //append a 400 millisecond wait time to beginning


                    p1.PlayerClientRef.Send(commandToSend);
                    numClientsSentTo += 1;
                }
            }

        }


        private void ToggleUserEnable(CheckBox chk, PlayerClient playerClient)
        {
            if (chk.Checked)
            {
                playerClient.Enabled = true;
            }
            else
            {
                playerClient.Enabled = false;
            }


            MainSettings.Character character = mainSettings.characterList.Find(item => item.characterName.Equals(chk.Text));

            character.EditCharacterSetting("GlobalSettings", "enabled", chk.Checked);

        }

        private void Extra_Load(object sender, EventArgs e)
        {

        }

        
    }
}
