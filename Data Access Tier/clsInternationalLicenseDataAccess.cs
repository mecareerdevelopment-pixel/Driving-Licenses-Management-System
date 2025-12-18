using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsInternationalLicenseDataAccess
    {
        public static void DeactivateLastIssuedLicenseIfExists(int DriverID)
        {
            string CommandText = "Update Internationallicenses Set Isactive = 0 Where DriverID = @did and isactive = 1";

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@did", DriverID);

            try
            {
                Connection.Open();

                Command.ExecuteNonQuery();
            }

            catch
            { }

            finally
            {
                Connection.Close();
            }
        }

        public static int GetActiveAndNonExpiredInternationalLicenseID(int DriverID)
        {
            string CommandText = "SELECT InternationalLicenseID FROM InternationalLicenses WHERE DriverID = @DriverID AND (IsActive = 1) AND (GETDATE() < ExpirationDate);";

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();

                object InternationalLicenseID = Command.ExecuteScalar();

                if (InternationalLicenseID != null)
                    return Convert.ToInt32(InternationalLicenseID);
            }

            catch
            {
                return -1;
            }

            finally
            {
                Connection.Close();
            }

            return -1;
        }

        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            DataTable AllLicenses = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select internationallicenseid As [Lic. ID] , ApplicationID As[App. ID], issuedusinglocallicenseid As[Local Lic. ID] , FORMAT(IssueDate, 'dd-MMM-yyyy') as [Issue Date], FORMAT(ExpirationDate, 'dd-MMM-yyyy') as [Expiration Date], isactive As [Is Active] from InternationalLicenses inner join drivers on drivers.DriverID = internationalLicenses.DriverID WHERE drivers.PersonID = @id ORDER BY isactive desc, [Lic. ID] DESC;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader R = Command.ExecuteReader();
                AllLicenses = new DataTable();
                AllLicenses.Load(R);        // it automatically closes the reader.
            }

            catch
            {
            }

            finally
            {
                Connection.Close();

            }

            return AllLicenses;
        }

        public static DataTable GetAll()
        {
            DataTable AllLicenses = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select internationallicenseid As [International License ID] , ApplicationID As[Application ID], driverid as [Driver ID], issuedusinglocallicenseid As[Local License ID] , FORMAT(IssueDate, 'dd-MMM-yyyy') as [Issue Date], FORMAT(ExpirationDate, 'dd-MMM-yyyy') as [Expiration Date], isactive As [Is Active] from InternationalLicenses order by isactive desc, internationallicenseid DESC;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            try
            {
                Connection.Open();

                SqlDataReader R = Command.ExecuteReader();
                AllLicenses = new DataTable();
                AllLicenses.Load(R);        // it automatically closes the reader.
            }

            catch
            {
            }

            finally
            {
                Connection.Close();

            }

            return AllLicenses;
        }

        public static int AddNew(int ApplicationID, int DriverID, int LocalLicenseID, int CommitingUserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO InternationalLicenses
                                    VALUES (@AppID, @DID, @LLID, @issueDate, @expDate, 1,@User);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@AppID", ApplicationID);
            Command.Parameters.AddWithValue("@DID", DriverID);
            Command.Parameters.AddWithValue("@LLID", LocalLicenseID);
            Command.Parameters.AddWithValue("@issueDate", DateTime.Today);
            Command.Parameters.AddWithValue("@expDate", DateTime.Today.AddYears(1));
            Command.Parameters.AddWithValue("@User", CommitingUserID);


            try
            {
                Connection.Open();

                object NewInternationalLicenseID = Command.ExecuteScalar();

                if (NewInternationalLicenseID != null && NewInternationalLicenseID != DBNull.Value)
                {
                    return Convert.ToInt32(NewInternationalLicenseID);
                }
            }

            catch
            {

            }

            finally
            {
                Connection.Close();
            }

            return -1;
        }

        public static bool Find(ref int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int LocalLicenseID, ref DateTime IssuingDate, ref DateTime ExpirationDate, ref bool IsActive,  ref int CreatedByUserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM internationallicenses WHERE internationallicenseid = @internationallicenseid";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@internationallicenseid", InternationalLicenseID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    ApplicationID = Convert.ToInt32(R["ApplicationID"]);
                    DriverID = Convert.ToInt32(R["DriverID"]);
                    LocalLicenseID = Convert.ToByte(R["IssuedUsingLocalLicenseID"]);
                    IssuingDate = (DateTime)R["IssueDate"];
                    ExpirationDate = (DateTime)R["ExpirationDate"];
                    IsActive = Convert.ToBoolean(R["IsActive"]);         
                    CreatedByUserID = Convert.ToInt32(R["CreatedByUserID"]);

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

    }
}
