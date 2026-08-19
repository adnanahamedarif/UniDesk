using System;
using System.Windows.Forms;

namespace UniDesk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // <--- THIS ATTRIBUTE IS REQUIRED
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login()); 
        }
    }
}