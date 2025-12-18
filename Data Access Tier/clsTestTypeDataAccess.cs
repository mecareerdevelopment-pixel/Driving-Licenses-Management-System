using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataAccessTier
{
    public static class clsTestTypeDataAccess
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable AllTestTypes = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT * FROM TestTypes;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            try
            {
                Connection.Open();

                SqlDataReader R = Command.ExecuteReader();
                AllTestTypes.Load(R);        // it automatically closes the reader.

                return AllTestTypes;
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

        public static bool Find(int ID, ref string title, ref string desc, ref double Fees)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM TestTypes WHERE testtypeid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    title = R["Testtypetitle"].ToString();
                    desc = R["TestTypeDescription"].ToString();
                    Fees = Convert.ToDouble(R["testtypefees"]);
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
                if (R!= null)
                    R.Close();

                Connection.Close();
            }

            return false;
        }

        public static bool Update(int ID, string Title, string Description, double Fees)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"Update testTypes Set testtypetitle = @t, testtypedescription = @d , testtypefees  = @f WHERE testtypeid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);
            Command.Parameters.AddWithValue("@t", Title);
            Command.Parameters.AddWithValue("@d", Description);
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
