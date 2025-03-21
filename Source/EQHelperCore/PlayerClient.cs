using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Timers;

namespace EQHelperCore
{
    public class PlayerClient
    {
        public bool Enabled = false;
        public string Name { get; set; }
        public string ComputerName { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }

        private NetworkStream ClientStream;

        private TcpClient ConnectClient;
        private Thread thread;

        private int delayTimedCommand = 0;
        private bool isConnected = false;
        private bool timedKeyIsRunning = false;
        private string timedKeyCommand = "";

        private System.Timers.Timer keyTimer;

        public string Connect()
        {
            if (ComputerName != null)
            {
                string computerIpAddress = IpAddress; //Global.GetIpAddressByHostName(ComputerName);

                if (computerIpAddress != "")
                    IpAddress = computerIpAddress;
            }

            try
            {
                //ConnectClient = new TcpClient();
                ConnectClient = new TcpClient(IpAddress, Port);
                ClientStream = ConnectClient.GetStream();

                //if (!ConnectClient.ConnectAsync(IpAddress, Port).Wait(1000))
                //{
                //    return "Failed to Connect";
                //}
                //else
                //{
                //    ConnectClient = new TcpClient(IpAddress, Port);
                //    ClientStream = ConnectClient.GetStream();
                //}
                
                isConnected = true;

                return "Connected";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "Failed to Connect";

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // if sending a real command, delay the timed command by 8 seconds
            if (delayTimedCommand > 0)
            {
                Thread.Sleep(delayTimedCommand);
                delayTimedCommand = 0;
            }

            SendMessage(timedKeyCommand);
        }

        public void StartTimedCommand(PlayerClientKeybind playerClientKeybinds)
        {
            //Thread timedThread = new Thread(() => SendTimedMessage(playerClientKeybinds));
            //timedThread.Start();

            timedKeyIsRunning = true;
            timedKeyCommand = playerClientKeybinds.CommandToSend;

            //send the command once initially as soon as the timed keybinding is hit, this way it doesn't need to wait the interval before starting up
            SendMessage(timedKeyCommand);

            keyTimer = new System.Timers.Timer();
            keyTimer.Interval = playerClientKeybinds.TimedWaitTime;
            keyTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            keyTimer.Enabled = true;
        }

        public void StopTimedCommand()
        {
            //Thread timedThread = new Thread(() => SendTimedMessage(playerClientKeybinds));
            //timedThread.Start();
            timedKeyIsRunning = false;
            timedKeyCommand = "";

            keyTimer.Enabled = false;
            keyTimer.Dispose();
        }


        public void Send(string message)
        {
            if (isConnected)
            {
                StopCurrentCommand();

                delayTimedCommand = 8000; // add an 8 second delay to any timed commands to give this one priority

                if (timedKeyIsRunning) // if timed command is already running, add a 1.5 second delay to the beginning in case spell is casting
                    thread = new Thread(() => SendMessage(message, 1500));
                else
                    thread = new Thread(() => SendMessage(message));

                thread.Start();
            }
        }

        private void StopCurrentCommand()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }

        private void SendMessage(string message, int delaySendTime = 0)
        {
            if (delaySendTime > 0)
                Thread.Sleep(delaySendTime);

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            ClientStream.Write(data, 0, data.Length);
        }

        public void Close()
        {
            if (ClientStream != null)
                ClientStream.Close();

            if (ConnectClient != null)
                ConnectClient.Close();
        }

        //private void SendTimedMessage(PlayerClientKeybind playerClientKeybinds)
        //{
        //    if (isConnected)
        //    {
        //        timedKeyIsRunning = playerClientKeybinds.IsTimedTurnedOn;

        //        while (playerClientKeybinds.IsTimedTurnedOn == true)
        //        {
        //            if (delayTimedCommand > 0)
        //            {
        //                Thread.Sleep(delayTimedCommand);
        //                delayTimedCommand = 0;
        //            }

        //            SendMessage(playerClientKeybinds.CommandToSend);
        //            Thread.Sleep(playerClientKeybinds.TimedWaitTime);
        //        }
        //        timedKeyIsRunning = false;
        //    }
        //}

        //private void Debug()
        //{
        //    Invoke(new Action<int>(UpdateProgress), percentComplete);
        //}


    }

}
