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

namespace EQHelperServer
{
    public partial class Keybinds : Form
    {
        List<PlayerClient> playerClients; 
        List<PlayerClientKeybind> playerClientKeybinds;
        MainSettings mainSettings;

        public Keybinds(List<PlayerClient> _playerClients, List<PlayerClientKeybind> _playerClientKeybinds, MainSettings _mainSettings)
        {
            InitializeComponent();

            playerClients = _playerClients;
            playerClientKeybinds = _playerClientKeybinds;
            mainSettings = _mainSettings;

            //this.Opacity = 0.8;
        }

        private void Keybinds_Load(object sender, EventArgs e)
        {
            

            List<string> keybindTexts = new List<string>();

            foreach (PlayerClientKeybind keybind in playerClientKeybinds)
            {
                string str = "";
                string keyValue = keybind.KeyValue;
                string keybindText = "";
                string characterName = keybind.PlayerClientRef.Name;
                //str = keybind.CommandToSend 

                //str +=

                if (keyValue.StartsWith("A"))
                {
                    keybindText += "ALT + ";
                    keyValue = keyValue.Split('A')[1];
                }
                else if (keybind.SendToAllClients)
                {
                    characterName = "ALL";
                }

                int val = Int16.Parse(keyValue);

                keybindText += ((Keys)val).ToString();


                str = characterName + " - " + keybindText + " = " + keybind.CommandToSend;

                LstKeybinds.Items.Add(str);

                keybindTexts.Add(keybindText);
            }


            LblDuplicate.Text = "";

            var duplicateKeys = keybindTexts.GroupBy(x => x).Where(group => group.Count() > 1).Select(group => group.Key);

            string[] arr = duplicateKeys.ToArray();

            if (arr.Length > 0)
            {
                LblDuplicate.Text = "DUPLICATE KEYS FOUND" + Environment.NewLine;
            }

            foreach (string s in arr)
            {
                LblDuplicate.Text += s + Environment.NewLine;
            }


        }

        private void LstKeybinds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
