using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;
using SharpConfig;
using System.IO;
using EQHelperCore;
using System.Threading;
using System.Net;

namespace EQHelperServer
{
    

    public partial class Form1 : Form
    {
        List<PlayerClient> playerClients = new List<PlayerClient>(); // list of players containing network information such as ip address, port, etc.
        List<PlayerClientKeybind> playerClientKeybinds = new List<PlayerClientKeybind>(); // list of keybindings & commands and which player they belong to
        //CharacterSettings characterSettings = new CharacterSettings();
        //MainSettings.Character characterSettings = new MainSettings.Character()
        MainSettings mainSettings = new MainSettings();
        //AudioNotification audioNotification = new AudioNotification();
        ServerSendingKeys serverSendingKeys;

        GlobalKeyboardHook _globalKeyboardHook;
        KeyboardHook keyboardHook;
        bool Connected = false;
        

        public Form1()  
        {
            InitializeComponent();

            mainSettings.ReadAllCharacterSettingsFiles(ref playerClients, ref playerClientKeybinds, false);
            FillTimedKeybindSection();

            // this is used for the server PC to toggle a timed command (i use it for cleric legs)
            //serverSendingKeys = new ServerSendingKeys(mainSettings.serverSendingKeyCommand);

            SetupKeyboardHooks();

            if (mainSettings.windowAlwaysOnTop)
                this.TopMost = true;

            this.Opacity = 0.8;

            LblDebug.Text = "";

            // if auto connect is enabled in the global settings, connect to all clients automatically
            if (mainSettings.autoConnect)
                BtnConnect_Click(null, null);

        }

        public void SetupKeyboardHooks()
        {
            keyboardHook = new KeyboardHook(true);
            keyboardHook.KeyUp += Kh_KeyUp;
        }

        private void Kh_KeyUp(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            //Console.WriteLine("The Key: " + key);

            int keyCode = (int)key;
            string keyValue = keyCode.ToString();

            //Console.WriteLine(keyCode);
            //Console.WriteLine(keyValue);

            //if (keyCode == 220) //  the "\" key above enter, toggles an auto key press for my computer only
            //{
            //    if (Environment.MachineName.ToLower() == "dave-laptop" || Environment.MachineName.ToLower() == "dave-pc")
            //        serverSendingKeys.Toggle();
            //}

            if (mainSettings.numpadKeysOnly)
            {
                if (keyCode < 96 || keyCode > 111) // dont intercept keypresses for anything other than the numpad
                {
                    return;
                }
            }
            



            if (Alt)
            {
               keyValue = "A" + keyValue; // add modifier for alt
            }

            if (keyValue == "A107")
            {
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Dave\Desktop\EQHelper\Binary\EQHelperServer\AllOut.wav");
                //player.Play();
            }

            // activate Splashtop windows
            if (Ctrl && Shift)
            {
                string computerName = "";
                switch(keyCode)
                {
                    case 112:
                        computerName = "John-PC - Splashtop Personal";
                        break;
                    case 113:
                        computerName = "Dave-Laptop - Splashtop Personal";
                        break;
                    case 114:
                        computerName = "John2-PC - Splashtop Personal";
                        break;
                    case 115:
                        computerName = "DaveLaptop - Splashtop Personal";
                        break;
                }

                if (computerName != "")
                {
                    Thread winThread = new Thread(() => SetWindowActive(computerName));
                    winThread.Start();
                }

                
            }
            

            //Console.WriteLine(keyValue);
                
                // look in the list and find if this key exists (bound to something)
                //PlayerClientKeybind p1 = playerClientKeybinds.Find(item => item.KeyValue.Equals(keyValue));
                List<PlayerClientKeybind> foundClientKeybinds = playerClientKeybinds.FindAll(item => item.KeyValue.Equals(keyValue));

                if (foundClientKeybinds != null) // if any keys found, send to client
                {
                    if (foundClientKeybinds.Count == 1) // if key is only bound to one client
                    {
                        PlayerClientKeybind p1 = foundClientKeybinds[0];

                        if (p1.IsTimedKeybinding)
                        {
                            p1.ToggleTimedKeybind();
                        }
                        else if (p1.SendToAllClients)
                        {
                            int numClientsSentTo = 0; // this is used to keep track of how many people it's sent the command to. will add a delay to each command so it doesn't send all at the same time and disconnect user

                            foreach (PlayerClient playerClient in playerClients)
                            {
                                if (playerClient.Enabled)
                                {
                                    string commandToSend = p1.CommandToSend;
                                    if (numClientsSentTo > 0)
                                        commandToSend = "/wait " + Convert.ToString(numClientsSentTo * 400) + "|" + p1.CommandToSend; //append a 400 millisecond wait time to beginning


                                    playerClient.Send(commandToSend);
                                    numClientsSentTo += 1;
                                }

                            }
                            //numClientsSentTo = 0;
                        }
                        else
                            p1.PlayerClientRef.Send(p1.CommandToSend);
                    }
                    else if (foundClientKeybinds.Count > 1) // bound to multiple clients, does not support timed keybindings or global keybindings 
                    {

                        int numClientsSentTo = 0;

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
                    
                }
                else
                {
                    //Console.WriteLine("Key not bound.");
                }

        }

       
        public void FillTimedKeybindSection()
        {
            int startingX = 0;
            int startingY = 0;

            foreach (PlayerClientKeybind playerClientKeybind in playerClientKeybinds)
            {
                if (playerClientKeybind.IsTimedKeybinding)
                {
                    CheckBox chkTimedKeybinding = new CheckBox();
                    chkTimedKeybinding.Text = playerClientKeybind.TimedLabelName;
                    //chkTimedKeybinding.Enabled = false;
                    //chkTimedKeybinding.AutoCheck = false;
                    chkTimedKeybinding.Location = new Point(startingX, startingY);
                    chkTimedKeybinding.Width = 250;
                    //chkTimedKeybinding.back

                    chkTimedKeybinding.CheckedChanged += new EventHandler(CheckChangedEvent);

                    playerClientKeybind.TimedCheckbox = chkTimedKeybinding;

                    PnlTimedKeybinds.Controls.Add(chkTimedKeybinding);

                    PnlTimedKeybinds.Height += 20;

                    this.Height += 10;

                    startingY = startingY + 20;
                }
            }
        }
        

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!Connected)
                ConnectClients();
            else
                DisconnectClients();
        }

        private void CheckChangedEvent(object sender, EventArgs e)
        {
            //MessageBox.Show("TEST");
        }
        
        private void ConnectClients()
        {
            Connected = true;
            BtnConnect.Text = "Disconnect";
            LblConnectStatus.Text = "";

            foreach (PlayerClient playerClient in playerClients)
            {
                if (playerClient.Enabled)
                {
                    string connectStatus = playerClient.Connect();
                    LblConnectStatus.Text += playerClient.Name + ": " + connectStatus + "\n";
                }
            }
        }

        private void DisconnectClients()
        {
            if (Connected)
            {
                foreach (PlayerClient playerClient in playerClients)
                {
                    if (playerClient != null)
                    {
                        if (playerClient.Enabled)
                            playerClient.Close();
                    }
                }
            }

            Connected = false;
            BtnConnect.Text = "Connect";
            LblConnectStatus.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectClients();
        }

        public void MsgBox(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg);
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            DisconnectClients();

            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void BtnRestartClients_Click(object sender, EventArgs e)
        {
            foreach (PlayerClient playerClient in playerClients)
            {
                if (playerClient.Enabled)
                {
                    playerClient.Send("RESTART PROGRAM");
                }
            }
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            Config FrmConfig = new Config();
            FrmConfig.Show();
        }

        private void BtnExtra_Click(object sender, EventArgs e)
        {
            Extra FrmExtra = new Extra(playerClients, playerClientKeybinds, mainSettings);
            FrmExtra.Show();
        }

        private void ChkDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDebug.Checked)
            {
                Console.SetOut(new ConsoleWriter(LblDebug));
                this.Width = 1000;
                this.Height = 500;
            }
        }

        private void BtnKeybinds_Click(object sender, EventArgs e)
        {
            Keybinds FrmKeybinds = new Keybinds(playerClients, playerClientKeybinds, mainSettings);
            FrmKeybinds.Show();
        }

        private void SetWindowActive(string computerName)
        {
            AutoItX3 AutoIt = new AutoItX3();

            if (AutoIt.WinActive(computerName) == 0)
            {
                AutoIt.Sleep(250);
                AutoIt.WinActivate(computerName);
                return;
            }
        }

    }
}