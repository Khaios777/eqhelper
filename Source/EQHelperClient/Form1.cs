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
using System.Threading;

namespace EQHelperClient
{
    public partial class Form1 : Form
    {
        GlobalSettings globalSettings = new GlobalSettings();
        ClientListen clientListen;
        //LogFileReader logFileReader;

        public Form1()
        {
            InitializeComponent();


            Console.SetOut(new ConsoleWriter(LblDebug));

            this.Height = 125;
            //this.TopMost = true;

            LblNetworkInfo.Text = globalSettings.ipAddress + ":" + globalSettings.port.ToString();

            if (globalSettings.autoListen) // auto click the listen button
                BtnListen_Click(null, null);
        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            clientListen = new ClientListen(globalSettings.stopCastKey, globalSettings.stopMacroKey, globalSettings.EQ2Enabled);

            BtnListen.Text = clientListen.StartListen(globalSettings.ipAddress, globalSettings.port);

            BtnListen.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close client listener
            if (clientListen != null)
                clientListen.StopListen();

            clientListen = null;


            // close log file reader
            //if (logFileReader != null)
            //    logFileReader.Stop();

            //logFileReader = null;

        }

        private void ChkDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDebugMode.Checked)
            {
                LblDebug.Visible = true;
                this.TopMost = true;
                this.Height = 250;
            }
            else
            {
                this.TopMost = false;
                this.Height = 125;
            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

    }
}
