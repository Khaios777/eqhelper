using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace EQHelperCore
{
    public class TcpSender
    {
        NetworkStream ClientStream;

        TcpClient ConnectClient;


        public string Connect(String server, int Port)
        {
            try
            {
                ConnectClient = new TcpClient(server, Port);
                ClientStream = ConnectClient.GetStream();

                return "Connected";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "Failed to Connect";

        }
        //Connect

        public void Send(string Message)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(Message);

            ClientStream.Write(data, 0, data.Length);
        }

        public void Close()
        {
            ClientStream.Close();
            ConnectClient.Close();
        }

    }
}
