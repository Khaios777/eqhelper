using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using SharpConfig;
using EQHelperCore;

namespace EQHelperServer
{
    public class MainSettings
    {
        public List<Character> characterList = new List<Character>();
        static string characterSettingsFolder = AppDomain.CurrentDomain.BaseDirectory + "CharacterSettings\\";
        string globalSettingsFile = AppDomain.CurrentDomain.BaseDirectory + "GlobalSettings\\Settings.ini";
        public bool autoConnect = false;
        public bool windowAlwaysOnTop = true;
        public bool numpadKeysOnly = true;
        public string serverSendingKeyCommand = "";

        public MainSettings()
        {
            // use seperate character settings folder for gaming laptop
            if (Environment.MachineName.ToLower() == "dave-laptop")
                characterSettingsFolder = AppDomain.CurrentDomain.BaseDirectory + "CharacterSettingsLaptop\\";

            if (Directory.Exists(characterSettingsFolder))
            {
                string[] subDirectories = Directory.GetDirectories(characterSettingsFolder); // gets each subdirectory in settings folder (1 for each player)

                foreach (string subDirectory in subDirectories)
                {
                    string name = subDirectory.Split('\\').Last();
                    Character character = new Character(name);

                    characterList.Add(character);
                }
            }

            // read settings file in globalsettings folder
            if (File.Exists(globalSettingsFile))
            {

                    Configuration config = Configuration.LoadFromFile(globalSettingsFile);
                    Section settingGlobalSettings = config["GlobalSettings"]; // get [GlobalSettings] in .ini file

                    autoConnect = settingGlobalSettings["autoConnect"].BoolValue;
                    windowAlwaysOnTop = settingGlobalSettings["windowAlwaysOnTop"].BoolValue;
                    numpadKeysOnly = settingGlobalSettings["numpadKeysOnly"].BoolValue;
                    serverSendingKeyCommand = settingGlobalSettings["serverSendingKeyCommand"].StringValue;
            }
        }

        public void ReadAllCharacterSettingsFiles(ref List<PlayerClient> playerClients, ref List<PlayerClientKeybind> playerClientKeybinds, bool refreshKeybindsOnly = false)
        {
            foreach (Character character in characterList)
            {
                character.LoadCharacterSettingsFile(ref playerClients, ref playerClientKeybinds, refreshKeybindsOnly);
                Console.WriteLine("Loaded: " + character.characterName);
            }

        }


        public class Character
        {
            public string characterName = "";
            public string settingsFolder = "";
            public string settingsFilePath = "";

            public Character(string charName)
            {
                characterName = charName;
                settingsFolder = characterSettingsFolder + charName;
                settingsFilePath = settingsFolder + "\\Settings.ini";
            }

            public void CreateDefaultIniFile()
            {
                Configuration config = new Configuration();

                // GlobalSettings
                Section sectionGlobalSettings = new Section("GlobalSettings");
                Setting enabled = new Setting("enabled", "1");

                sectionGlobalSettings.Add(enabled);

                // NetworkSettings
                Section sectionNetworkSettings = new Section("NetworkSettings");
                Setting computerName = new Setting("computerName", "John-PC");
                Setting ipAddress = new Setting("ipAddress", "192.168.1.1");
                Setting port = new Setting("port", "13000");

                sectionNetworkSettings.Add(computerName);
                sectionNetworkSettings.Add(ipAddress);
                sectionNetworkSettings.Add(port);

                // Keybindings
                Section sectionKeybindings = new Section("Keybindings");

                // TimedKeybindings
                Section sectionTimedKeybindings = new Section("TimedKeybindings");


                // Add all sections to config
                config.Add(sectionGlobalSettings);
                config.Add(sectionNetworkSettings);
                config.Add(sectionKeybindings);
                config.Add(sectionTimedKeybindings);

                config.SaveToFile(settingsFilePath);
            }

            public void LoadCharacterSettingsFile(ref List<PlayerClient> playerClients, ref List<PlayerClientKeybind> playerClientKeybinds, bool refreshKeybindsOnly = false)
            {
                if (Directory.Exists(settingsFolder))
                {
                    //string[] subDirectories = Directory.GetDirectories(settingsFolder); // gets each subdirectory in settings folder (1 for each player)


                    Configuration config = Configuration.LoadFromFile(settingsFilePath);
                    Section settingGlobalSettings = config["GlobalSettings"]; // get [GlobalSettings] in .ini file
                    Section sectionNetworkSettings = config["NetworkSettings"]; // get [NetworkSettings] in .ini file
                    Section settingKeybindings = config["Keybindings"]; // get [Keybindings] in .ini file
                    Section settingTimedKeybindings = config["TimedKeybindings"];
                    Section settingButtonKeybindings = config["ButtonKeybindings"];

                    PlayerClient playerClient = new PlayerClient();

                    if (!refreshKeybindsOnly)
                    {
                        playerClient.Name = settingsFolder.Split('\\').Last(); //sets name to folder name in settings folder

                        // extract the [GlobalSettings] portion
                        playerClient.Enabled = settingGlobalSettings["enabled"].BoolValue;


                        // extract the [NetworkSettings] portion
                        playerClient.ComputerName = sectionNetworkSettings["computerName"].StringValue;
                        playerClient.IpAddress = sectionNetworkSettings["ipAddress"].StringValue;

                        //playerClient.Port = sectionNetworkSettings["port"].IntValue;
                        playerClient.Port = 13000 + Convert.ToInt32(playerClient.IpAddress.Split('.').Last()); // testing this

                        playerClients.Add(playerClient);

                        // extract the [Keybindings] portion
                        // sets up the list of keybindings and commands and which players each one belongs to
                        // so for example numpad 3 sends letter a to player 2
                    }

                    if (playerClient.Enabled)
                    {
                        foreach (Setting setting in settingKeybindings)
                        {
                            PlayerClientKeybind clientKeybinds = new PlayerClientKeybind();
                            clientKeybinds.KeyValue = setting.Name.Replace("*", ""); // if command starts with *, send to all clients
                            clientKeybinds.CommandToSend = setting.StringValue;
                            clientKeybinds.PlayerClientRef = playerClient;

                            if (setting.Comment.HasValue)
                            {
                                if (setting.Comment.Value.Value.ToLower().Contains("spell"))
                                    clientKeybinds.IsSpell = true;
                            }

                            if (setting.Name.StartsWith("*"))
                                clientKeybinds.SendToAllClients = true;

                            playerClientKeybinds.Add(clientKeybinds);
                        }

                        // TimedKeybindings
                        foreach (Setting setting in settingTimedKeybindings)
                        {
                            PlayerClientKeybind clientKeybinds = new PlayerClientKeybind();
                            clientKeybinds.KeyValue = setting.Name.Replace("*", ""); // if command starts with *, send to all clients

                            string[] strSplit = setting.StringValue.Split('|');




                            clientKeybinds.PlayerClientRef = playerClient;

                            if (setting.Name.StartsWith("*"))
                                clientKeybinds.SendToAllClients = true;

                            clientKeybinds.IsTimedKeybinding = true;
                            clientKeybinds.TimedLabelName = strSplit[0].ToString();
                            clientKeybinds.CommandToSend = strSplit[1];
                            clientKeybinds.TimedWaitTime = Convert.ToInt32(strSplit[2].Replace("/wait", "").Trim());

                            playerClientKeybinds.Add(clientKeybinds);
                        }

                        // ButtonKeybindings
                        foreach (Setting setting in settingButtonKeybindings)
                        {
                            PlayerClientKeybind clientKeybinds = new PlayerClientKeybind();
                            clientKeybinds.KeyValue = setting.Name.Replace("*", ""); // if command starts with *, send to all clients

                            int charIndex = setting.StringValue.IndexOf("|");
                            //string[] strSplit = setting.StringValue.Split('|');

                            clientKeybinds.PlayerClientRef = playerClient;

                            if (setting.Name.StartsWith("*"))
                                clientKeybinds.SendToAllClients = true;

                            clientKeybinds.ButtonLabelText = setting.StringValue.Substring(0, charIndex);
                            clientKeybinds.CommandToSend = setting.StringValue.Substring(charIndex, setting.StringValue.Length - charIndex);
  
                            playerClientKeybinds.Add(clientKeybinds);
                        }

                    }




                }
                else
                {
                    //MsgBox("Settings directory not found.");
                }
            }

            public void AddKeybinding(string serverKeybind, string clientKeybind)
            {
                Configuration config = Configuration.LoadFromFile(settingsFilePath);

                Section sectionKeybindings = config["Keybindings"];
                Setting setting = new Setting(serverKeybind, clientKeybind);

                sectionKeybindings.Add(setting);

                config.SaveToFile(settingsFilePath);
            }

            public void EditCharacterSetting(string sectionName, string settingName, object value)
            {
                //                characterList[0].settingsFilePath

                //Character character = characterList[0] //.Find(item => item.characterName.Equals(characterName));

                Configuration config = Configuration.LoadFromFile(settingsFilePath);

                Section section = config[sectionName];
                Setting setting = section[settingName];

                setting.SetValue(value);

                config.SaveToFile(settingsFilePath);
            }

        }



        public class Global
        {
            public string test2 { get; set; }
        }
    }
}
