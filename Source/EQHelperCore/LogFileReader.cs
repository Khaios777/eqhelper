using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace EQHelperCore
{
    public class LogFileReader
    {


        string logFilePath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Everquest F2P\\Logs\\eqlog_Faedynn_phinigel.txt";

        //AudioNotification audioNotification = new AudioNotification();

        //string logFilePath = "C:\\Temp\\Logs\\test.txt";


        bool reading = false;
        bool showNotifications = false;
        Thread thread;

        public void Start()
        {
            

            // read the last 3 lines
            // if text found, 

            reading = true;

            if (File.Exists(logFilePath))
            {
                thread = new Thread(() => ReadLog());
                thread.Start();
            }
            else
            {
                Console.WriteLine("EQ LOG FILE NOT FOUND");
            }
            
        }

        public void Stop()
        {
            reading = false;
        }

        private void ReadLog()
        {
            var wh = new AutoResetEvent(false);
            var fsw = new FileSystemWatcher(".");
            fsw.Filter = logFilePath;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();

            var fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var sr = new StreamReader(fs))
            {
                var s = "";
                while (true)
                {
                    s = sr.ReadLine();
                    if (s != null)
                    {
                        if (showNotifications)
                        {
                            Console.WriteLine(s);
                            //ParseLine(s);
                        }
                            
                    }
                    else
                    {
                        // at this point, the whole file has been read. now start showing notifications
                        showNotifications = true;
                        wh.WaitOne(1000);
                    }
                        
                    if (!reading)
                        break;
                }
            }

            wh.Close();
        }
          
    }
}
