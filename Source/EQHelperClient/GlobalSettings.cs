using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using EQHelperCore;
using System.Threading;
using SharpConfig;

namespace EQHelperClient
{
    public class GlobalSettings
    {
        private string globalSettingsFolder = AppDomain.CurrentDomain.BaseDirectory + "GlobalSettings\\";

        public string ipAddress { get; set; }
        public int port { get; set; }
        public bool autoListen { get; set; }

        public string stopCastKey = "";
        public string stopMacroKey = "";
        public bool EQ2Enabled = false;

        public GlobalSettings()
        {
            LoadGlobalSettings();
            LoadAutomaticSettings();
        }

        private void LoadGlobalSettings()
        {
            if (Directory.Exists(globalSettingsFolder))
            {

                Configuration config = Configuration.LoadFromFile(globalSettingsFolder + "\\Settings.ini");
                Section sectionGlobalSettings = config["GlobalSettings"]; // get [GlobalSettings] section in .ini file

                //ipAddress = Global.GetIpAddressByHostName(Environment.MachineName); // sectionGlobalSettings["ipAddress"].StringValue;
                //port = sectionGlobalSettings["port"].IntValue;
                //autoListen = sectionGlobalSettings["autoListen"].BoolValue;
                stopCastKey = sectionGlobalSettings["stopCastKey"].StringValue;
                stopMacroKey = sectionGlobalSettings["stopMacroKey"].StringValue;
                EQ2Enabled = sectionGlobalSettings["eq2enabled"].BoolValue;
            }
        }

        //testing this
        private void LoadAutomaticSettings()
        {
            ipAddress = Global.GetIpAddressByHostName(Environment.MachineName);
            port = 13000 + Convert.ToInt32(ipAddress.Split('.').Last()); // to randomize the ports for different clients, take the last numbers of ip address
            autoListen = true;
        }

    }
}
