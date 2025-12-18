using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLogicTier
{
    public enum enmTestTypes
    {
        Vision = 1, Written, Street
    }

    public class clsTestType
    {
     
        public clsTestType(int ID, string Title, string Description, double Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }
        
        public int ID
        {
            get; set;
        }

        public string Title
        { get; set; }

        public string Description
        { get; set; }

        public double Fees
        { get; set; }


        public static DataTable GetAll()
        {
            return DataAccessTier.clsTestTypeDataAccess.GetAllTestTypes();
        }

        public static clsTestType Find(int ID)
        {
            string T = "", D = "";
            double F = 0.0;

            if (DataAccessTier.clsTestTypeDataAccess.Find(ID, ref T, ref D, ref F))
                return new clsTestType(ID, T, D, F);

            return null;
        }

        public bool Save()
        {
            return DataAccessTier.clsTestTypeDataAccess.Update(this.ID, this.Title, this.Description, this.Fees);
        }

    }
}
