using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Application
{
    internal static class clsGlobalSettings
    {
        static public int CurrentLoggedInUserID = -1;

        static public BusinessLogicTier.clsUser CurrentLoggedInUser
        {
            get
            {
                return BusinessLogicTier.clsUser.FindByUserID(CurrentLoggedInUserID);
            }
        }

        public static string keyPath = @"HKEY_CURRENT_USER\Software\DVLD";

    }
}
