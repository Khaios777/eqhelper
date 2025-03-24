using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using AutoItX3Lib;

namespace EQHelperCore
{
    public class SendingKeystrokes
    {
        AutoItX3 AutoIt = new AutoItX3();
        string stopCastKey = "";
        string stopMacroKey = "";
        bool EQ2Enabled = false;


        public SendingKeystrokes(string _stopCastKey, string _stopMacroKey, bool _EQ2Enabled)
        {
            stopCastKey = _stopCastKey;
            stopMacroKey = _stopMacroKey;
            EQ2Enabled = _EQ2Enabled;
        }

        public void SendAutoITCommand(string fullCommand)
        {
            int numLoops = 1;
            try
            {
                fullCommand = fullCommand.ToLower();

                //Console.WriteLine("Executing Command: " + fullCommand);

                if (EQ2Enabled)
                {
                    // activate EQ window if minimized
                    if (AutoIt.WinActive("[CLASS:EQ2ApplicationClass]") == 0)
                    {
                        AutoIt.WinActivate("[CLASS:EQ2ApplicationClass]");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    // activate EQ window if minimized
                    if (AutoIt.WinActive("[CLASS:_EverQuestwndclass]") == 0)
                    {
                        AutoIt.WinActivate("[CLASS:_EverQuestwndclass]");
                        Thread.Sleep(1000);
                    }
                }


                if (AutoIt.WinActive("[CLASS:_EverQuestwndclass]") == 1 || AutoIt.WinActive("[CLASS:EQ2ApplicationClass]") == 1) // make sure window is active before sending commands
                {
                    if (fullCommand.StartsWith("/timed "))
                        fullCommand = fullCommand.Replace("/timed ", "");
                    else if (fullCommand.Contains("/nostop "))
                        fullCommand = fullCommand.Replace("/nostop ", "");
                    else if (fullCommand.StartsWith("/loop "))
                    {
                        string firstCommand = fullCommand.Substring(0, fullCommand.IndexOf('|'));
                        numLoops = Convert.ToInt32(firstCommand.Replace("/loop", "").Trim()); // get everything after the /wait command
                        fullCommand = fullCommand.Replace(firstCommand, "");
                        
                        //StopCast2();
                    }
                    else
                        StopCast2();

                    for (int i = 0; i < numLoops; i++)
                    {
                        if (fullCommand.Contains("|")) // | only used for sending multiple commands
                        {
                            string[] commands = fullCommand.Split('|');

                            foreach (string command in commands)
                            {
                                ExecuteCommand(command);
                                //Console.WriteLine("Part of Command: " + command);
                            }
                        }
                        else // only 1 command sent
                        {
                            ExecuteCommand(fullCommand);
                            //Console.WriteLine("Full Command: " + fullCommand);
                        }
                    }
                    

                }



            }
            catch (Exception ex)
            {

            }

        }

        public void ExecuteCommand(string command)
        {
            if (command.StartsWith("/wait"))
            {
                int milliseconds = Convert.ToInt32(command.Replace("/wait", "").Trim()); // get everything after the /wait command
                Thread.Sleep(milliseconds);
            }
            else if (command.StartsWith("/zoomin"))
            {
                AutoIt.MouseWheel("up", 10);
            }
            else if (command.StartsWith("/zoomout"))
            {
                AutoIt.MouseWheel("down", 10);
            }
            else
            {
                AutoIt.Send(command);
            }


            //return "";
        }

        public void StopCast2()
        {
            if (stopCastKey == "")
                return;

            AutoIt.Send(stopCastKey);
            Thread.Sleep(300);

            if (stopMacroKey != "")
                AutoIt.Send(stopMacroKey);
        }

    }

}