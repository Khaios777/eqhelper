using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EQHelperCore
{
    public class Global
    {
        static public string characterSettingsFolder = AppDomain.CurrentDomain.BaseDirectory + "CharacterSettings\\";
        static public void LoadCharacterDropdown(ComboBox DdlCharacter, bool AddAll = false)
        {
            // use seperate character settings folder for gaming laptop
            if (Environment.MachineName.ToLower() == "dave-laptop")
                characterSettingsFolder = AppDomain.CurrentDomain.BaseDirectory + "CharacterSettingsLaptop\\";

            DdlCharacter.Items.Clear();

            if (AddAll)
            {
                DdlCharacter.Items.Add("All");
                DdlCharacter.SelectedItem = "All";
            }
                



            string[] subDirectories = Directory.GetDirectories(characterSettingsFolder); // gets each subdirectory in settings folder (1 for each player)

            foreach (string subDirectory in subDirectories)
            {
                string name = subDirectory.Split('\\').Last();
                DdlCharacter.Items.Add(name);
            }
        }

        static public string GetIpAddressByHostName(string hostName)
        {
            IPHostEntry host = Dns.GetHostEntry(hostName);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "";
        }

    }
}
