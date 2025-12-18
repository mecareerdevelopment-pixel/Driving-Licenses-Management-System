using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsApplicationTypeDataAccess
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable AllApplicationTypes = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT * FROM ApplicationTypes;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            try
            {
                Connection.Open();

                SqlDataReader R = Command.ExecuteReader();
                AllApplicationTypes.Load(R);        // it automatically closes the reader.
                return AllApplicationTypes;
            }

            catch
            {

            }

            finally
            {
                Connection.Close();
            }

            return null;
        }

        public static bool Find(int ID, ref string Title, ref double Fees)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM applicationTypes WHERE applicationtypeid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    Title = R["applicationtypetitle"].ToString();
                    Fees = Convert.ToDouble(R["applicationfees"]);
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
                if (R != null)
                    R.Close();

                Connection.Close();
            }

            return false;
        }

        public static bool Update(int ID, string Title, double Fees)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"Update applicationTypes Set applicationtypetitle = @t, applicationfees  = @f WHERE applicationtypeid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);
            Command.Parameters.AddWithValue("@t", Title);
            Command.Parameters.AddWithValue("@f", Fees);

            try
            {
                Connection.Open();

                return Convert.ToBoolean(Command.ExecuteNonQuery());

            }

            catch
            {

            }

            finally
            {
                Connection.Close();
            }

            return false;
        }
    }

}
