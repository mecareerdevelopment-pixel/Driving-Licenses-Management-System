using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLogicTier
{
    public class clsApplicationType
    {
        public clsApplicationType(int id, string title, double Fees)
        {
            ID = id;
            Title = title;
            this.Fees = Fees;
        }

        public int ID
        {
            get; set;
        }

        public string Title
        { get; set; }

        public double Fees
        { get; set; }


        public static DataTable GetAll()
        {
            return DataAccessTier.clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int ID)
        {
            string T = "";
            double F = 0;

            if (DataAccessTier.clsApplicationTypeDataAccess.Find(ID, ref T, ref F))
                return new clsApplicationType(ID, T, F);

            return null;
        }

        public bool Save()
        {
            return DataAccessTier.clsApplicationTypeDataAccess.Update(this.ID, this.Title, this.Fees);
        }
    }
}
