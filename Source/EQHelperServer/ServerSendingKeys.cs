using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Threading;

namespace EQHelperServer
{
    public class ServerSendingKeys
    {

        string keyCommand = "";
        int waitTime = 0;

        public ServerSendingKeys(string command)
        {
            string[] commands = command.Split('|');

            if (commands.Length > 0)
            {
                keyCommand = commands[0].ToString();
                waitTime = Convert.ToInt32(commands[1].Replace("/wait ",""));
            }
        }


        AutoItX3 autoIt = new AutoItX3();
        bool active = false;
        public void Toggle()
        {
            if (active)
                active = false;
            else
                active = true;


            if (active)
            {
                Thread tempThread = new Thread(() => SendKeyCommand());
                tempThread.Start();
            }

        }

        public void SendKeyCommand()
        {
            

            while (active)
            {
                autoIt.Send(keyCommand);
                Thread.Sleep(waitTime);
            }
        }

    }
}
