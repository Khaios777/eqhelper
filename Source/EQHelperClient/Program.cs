using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQHelperClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //AppDomain.CurrentDomain.UnhandledException +=
            //(sender, args) => HandleUnhandledException(args.ExceptionObject as Exception);
            //Application.ThreadException +=
            //    (sender, args) => HandleUnhandledException(args.Exception);
        }

        static void HandleUnhandledException(Exception e)
        {
            MessageBox.Show(e.Message);
            MessageBox.Show(e.StackTrace);
            // show report sender and close the app or whatever
        }
    }
}
