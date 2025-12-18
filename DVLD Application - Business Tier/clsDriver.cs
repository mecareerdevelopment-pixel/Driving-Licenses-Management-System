using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class clsDriver
    {
        public static int GetDriverIDWithPersonID(int PID)
        {
            return clsDriverDataAccess.GetDriverIDWithPersonID(PID);
        }

        public static int AddNewDriverAndGetID(int PersonID, int UserIDCreatedDriver)
        {
            return clsDriverDataAccess.AddNewDriverAndGetID(PersonID, UserIDCreatedDriver);
        }

        public static DataTable GetAll()
        {
            return clsDriverDataAccess.GetAll();
        }

        public static int GetPersonID(int DriverID)
        {
            return clsDriverDataAccess.GetPersonID(DriverID);
        }

    }
}
