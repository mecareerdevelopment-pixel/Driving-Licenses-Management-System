using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsLicenseClassDataAccess
    {

        
        public static DataTable GetLicenseClassesList()
        {
            DataTable ClassesList = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT ClassName FROM LicenseClasses;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();

                Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    ClassesList = new DataTable();
                    ClassesList.Load(Reader);
                }
            }

            catch
            {

            }

            finally
            {
                if (Reader != null)
                    Reader.Close();

                Connection.Close();
            }

            return ClassesList;
        }

        public static bool Find(int ID, ref string Name, ref string Description, ref int MinimumAllowedAge, ref byte ValidityLength, ref double Fees)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"select * from licenseclasses where LicenseClassID=@id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    Name = R["classname"].ToString();
                    Description = R["classdescription"].ToString();
                    MinimumAllowedAge = Convert.ToInt32(R["MinimumAllowedAge"]);
                    ValidityLength = Convert.ToByte(R["defaultvaliditylength"]);
                    Fees = Convert.ToDouble(R["classfees"]);
                    return true;
                }

                else
                {
                    return false;
                }

            }

            catch
            {

            }

            finally
            {
                R.Close();
                Connection.Close();
            }

            return false;
        }
    }
}
