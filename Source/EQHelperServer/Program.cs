using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQHelperServer
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

            //var kh = new KeyboardHook(true);

            

            AppDomain.CurrentDomain.UnhandledException +=
            (sender, args) => HandleUnhandledException(args.ExceptionObject as Exception);
            Application.ThreadException +=
                (sender, args) => HandleUnhandledException(args.Exception);


            Application.Run(new Form1());

        }

        static void HandleUnhandledException(Exception e)
        {
            MessageBox.Show(e.Message + Environment.NewLine + e.InnerException + Environment.NewLine + e.StackTrace + Environment.NewLine);
            //restart the app if it crashes
            //System.Diagnostics.Process.Start(Application.ExecutablePath);
            //Application.Exit();
        }
    }
}
