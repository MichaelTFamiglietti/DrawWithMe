using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DrawWithMe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string file = "";
            if (args.Count() > 0)
                file = args[0];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormDrawWithMe(file));
        }
    }
}
