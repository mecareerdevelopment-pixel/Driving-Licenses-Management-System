using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class clsLicenseClass
    {
        public int ID
        { get; set; }

        public string Name
        { get; set; }

        public string Description
        { get; set; }

        public int MinimumAllowedAge
        { get; set; }

        public byte ValidityLength
        { get; set; }

        public double Fees
        { get; set; }


        public clsLicenseClass()
        {

        }

        public clsLicenseClass(int ID, string Name, string Description, int MinimumAllowedAge, byte ValidityLength, double Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.ValidityLength = ValidityLength;
            this.Fees = Fees;
        }

        public static DataTable GetLicenseClassesList()
        {
            return clsLicenseClassDataAccess.GetLicenseClassesList();
        }


        public static clsLicenseClass Find(int ID)
        {

            string Name = ""; string Description =""; int MinimumAllowedAge=0; byte ValidityLength=0; double Fees=0;


            if (clsLicenseClassDataAccess.Find(ID, ref Name, ref Description, ref MinimumAllowedAge, ref ValidityLength, ref Fees))
            {
                return new clsLicenseClass(ID, Name, Description, MinimumAllowedAge, ValidityLength, Fees);
            }

            return null;
        }

    }
}
