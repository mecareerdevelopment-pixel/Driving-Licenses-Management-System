using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTier
{
    public class clsContactInfo
    {

        public clsContactInfo()
        {

        }

        public clsContactInfo(string P, string E, string A, int CID)
        {
            Phone = P;
            Email = E;
            Address = A;
            CountryID = CID;
        }

        public string Phone
        { get; set; }

        public string Email
        { get; set; }

        public string Address
        { get; set; }

        public int CountryID
        { get; set; }

        public string CountryName
        { 
            get
            {
                return DataAccessTier.clsPersonDataAccess.GetCountryName(this.CountryID);
            }
        }
    }
}
