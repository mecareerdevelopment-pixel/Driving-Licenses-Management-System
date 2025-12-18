using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;

namespace Data_Access_Tier
{
    public static class clsLicenseDetentionDataAccess
    {
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable AllDetainedLicenses = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select * from detainedlicensesinfo order by [is released] asc, [D. id] DESC;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            try
            {
                Connection.Open();

                SqlDataReader R = Command.ExecuteReader();
                AllDetainedLicenses.Load(R);        // it automatically closes the reader.
            }

            catch
            {
            }

            finally
            {
                Connection.Close();

            }

            return AllDetainedLicenses;
        }


        public static bool Find(ref int DetainID, ref int LicenseID, ref bool IsReleased, ref int DetainedByUserID, ref int ReleaseApplicationID, ref float FineFees, ref DateTime DetainDate, ref DateTime ReleaseDate, ref int ReleasedByUserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM DetainedLicenses WHERE licenseid = @id and isreleased = 0";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader R = Command.ExecuteReader();

                if (R.Read())
                {
                    DetainID = Convert.ToInt32(R["DetainID"]);
                    IsReleased = Convert.ToBoolean(R["IsReleased"]);
                    DetainedByUserID = Convert.ToInt32(R["CreatedByUserID"]);
                    ReleaseApplicationID = R["ReleaseApplicationID"] == DBNull.Value ? -1 : Convert.ToInt32(R["ReleaseApplicationID"]);
                    FineFees = Convert.ToSingle(R["FineFees"]);
                    DetainDate = (DateTime)R["DetainDate"];
                    ReleaseDate = R["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)R["ReleaseDate"];
                    ReleasedByUserID = R["ReleasedByUserID"] == DBNull.Value ? -1 : Convert.ToInt32(R["ReleasedByUserID"]);

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
                Connection.Close();
            }

            return false;
        }


        public static bool ReleaseLicense(int LicenseID, int ReleasingUserID, int ReleaseDetainedLicenseApplicationID)      // returns false if entered and licne is already released
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE DetainedLicenses
                                    SET isreleased = 1, ReleaseDate = GETDATE(), REleasedByUserID = @user, ReleaseApplicationID = @appID
                                    WHERE DetainedLicenses.LicenseID = @LID AND DetainedLicenses.IsReleased = 0;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@user", ReleasingUserID);
            Command.Parameters.AddWithValue("@appID", ReleaseDetainedLicenseApplicationID);
            Command.Parameters.AddWithValue("@LID", LicenseID);

            

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
