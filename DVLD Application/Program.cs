using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Application
{
    internal static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            Application.Run(new frmLogin());        // executing this line ends either by user close the form from 'x' rightmost above or when login succeeded 

            while (clsGlobalSettings.CurrentLoggedInUserID != -1)        // a user logged in successfully
            {
                Application.Run(new frmMain());


                // reach here after closing the main form 


                if (clsGlobalSettings.CurrentLoggedInUserID != -1)       // true if close the main form without making signout
                    return;



                // reach here if signout has been done
                Application.Run(new frmLogin());
            }
        }
    }
}
