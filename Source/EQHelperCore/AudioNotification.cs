using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Media;


namespace EQHelperCore
{
    public class AudioNotification
    {
        public bool Enabled = false;

        public string IpAddress { get; set; }
        public int Port { get; set; }

        private NetworkStream ClientStream;
        private TcpListener server;
        private TcpClient ConnectClient;

        private Thread thread;

        private bool IsConnected = false;
        public bool isListening = false;

        SoundPlayer soundPlayer = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "AudioAlert.wav");

        public AudioNotification()
        {
            //if (Environment.MachineName.ToLower() == "dave-pc")
            //    IpAddress = Global.GetIpAddressByHostName("Dave-Laptop");
            //else

            ///IpAddress = Global.GetIpAddressByHostName("DAVE-PC");
            
            //Port = 13300;

            //PlayAudioSound();

            //System.Windows.Forms.MessageBox.Show(IpAddress);
        }

        public void SendAudioNotification(string message)
        {
            if (!IsConnected)
            {
                try
                {
                    ConnectClient = new TcpClient(IpAddress, Port);
                    ClientStream = ConnectClient.GetStream();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            thread = new Thread(() => SendMessage(message));
            thread.Start();
        }

        public string ListenAudioNotification()
        {
            isListening = true;

            thread = new Thread(() => ListenCommands());
            thread.Start();

            return "Listening...";
        }

        private void ListenCommands()
        {
            Console.WriteLine("START LISTEN");
            

            server = null;

            try
            {
                IPAddress localAddr = IPAddress.Parse(IpAddress);

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
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        if (data == "Alert")
                        {
                            PlayAudioSound();
                        }

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        stream.Write(msg, 0, msg.Length);
                        i = stream.Read(bytes, 0, bytes.Length);

                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                server.Stop();
            }
        }

        private void PlayAudioSound()
        {
            //System.Windows.Forms.MessageBox.Show("AUDIO TEST");


            soundPlayer.Play();

        }

        private void SendMessage(string message)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            ClientStream.Write(data, 0, data.Length);

            Console.WriteLine("Audio Alert Sent.");
        }

        public void Close()
        {
            isListening = false;
            IsConnected = false;

            ClientStream.Close();
            ConnectClient.Close();
        }


    }

}
