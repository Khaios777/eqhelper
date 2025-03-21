using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using EQHelperCore;
using System.Threading;

namespace EQHelperClient
{
    public class ClientListen
    {
        public bool isListening = false;
        TcpListener server;
        SendingKeystrokes sendingKeys;
        Thread t1;
        Thread t2;

        public ClientListen(string stopCastKey, string stopMacroKey, bool EQ2Enabled)
        {
            sendingKeys = new SendingKeystrokes(stopCastKey, stopMacroKey, EQ2Enabled);
        }

        public void StopListen()
        {
            isListening = false;
            server.Stop();
        }

        public string StartListen(string IpAddressStr, int Port)
        {
            isListening = true;

            t1 = new Thread(() => ListenCommands(IpAddressStr, Port));
            t1.Start();

            return "Listening...";
        }

        private void StopCurrentCommand(Thread thread)
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }

        private void ListenCommands(string IpAddressStr, int Port)
        {
            Console.WriteLine("START LISTEN");

            server = null;

            try
            {
                IPAddress localAddr = IPAddress.Parse(IpAddressStr);

                server = new TcpListener(localAddr, Port);

                server.Start();

                byte[] bytes = new byte[1025];
                string data = null;

                // Enter the listening loop.
                while (isListening)
                {

                    data = null;
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    Int32 i = default(Int32);

                    // Loop to receive all the data sent by the client.
                    i = stream.Read(bytes, 0, bytes.Length);
                    while ((i != 0 && isListening))
                    {

                        // Translate data bytes to ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);


                        //LblDebug.Text = "Received: " + data;
                         
                        if (!data.StartsWith("/timed ")) // if not a timed command, give it priority and stop the current command
                        {
                            StopCurrentCommand(t2); // if any commands are still running abort the thread
                        }
                        else if (data == "RESTART PROGRAM")
                        {
                            System.Diagnostics.Process.Start(Application.ExecutablePath);
                            Application.Exit();
                        }

                        Console.WriteLine(data);
                        
                        
                        t2 = new Thread(() => sendingKeys.SendAutoITCommand(data));
                        t2.Start();

                        
                        // Process the data sent by the client.
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        i = stream.Read(bytes, 0, bytes.Length);

                    }

                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                server.Stop();
            }
        }
        }
}
