using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Access_Tier
{

    public static class clsLocalLicenseDataAccess
    {
        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            DataTable AllLicenses = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select LicenseID As [Lic. ID] , ApplicationID As[App. ID], ClassName As[Class Name] , FORMAT(IssueDate, 'dd-MMM-yyyy') as [Issue Date], FORMAT(ExpirationDate, 'dd-MMM-yyyy') as [Expiration Date], isactive As [Is Active] from Licenses inner join LicenseClasses on Licenses.LicenseClass = LicenseClasses.LicenseClassID inner join drivers on drivers.DriverID = Licenses.DriverID WHERE drivers.PersonID = @id ORDER BY isactive desc, [Lic. ID] Desc;";

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

        public static bool Find(ref int ID, ref int ApplicationID, ref int DriverID, ref byte LicenseClassID, ref DateTime IssuingDate, ref DateTime ExpirationDate, ref string Notes, ref double PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM licenses WHERE licenseid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    ApplicationID = Convert.ToInt32(R["ApplicationID"]);
                    DriverID = Convert.ToInt32(R["DriverID"]);
                    LicenseClassID = Convert.ToByte(R["LicenseClass"]);
                    IssuingDate = (DateTime)R["IssueDate"];
                    ExpirationDate = (DateTime)R["ExpirationDate"];
                    PaidFees = Convert.ToDouble(R["PaidFees"]);
                    Notes = (R["Notes"] == DBNull.Value ? "" : R["Notes"].ToString());
                    IsActive = Convert.ToBoolean(R["IsActive"]);
                    IssueReason = Convert.ToByte(R["IssueReason"]);
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


        public static int AddNew(int ApplicationID, int DriverID, byte LicenseClassID, DateTime IssuingDate, DateTime ExpirationDate, string Notes, double PaidFees, bool IsActive, byte IssueReason, int CommitingUserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO Licenses
                                    VALUES (@appid, @did, @lcid ,@idt, @edt, @Notes, @fees, @active, @reason, @user);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@appid", ApplicationID);
            Command.Parameters.AddWithValue("@did", DriverID);
            Command.Parameters.AddWithValue("@lcid", LicenseClassID);
            Command.Parameters.AddWithValue("@idt", IssuingDate);
            Command.Parameters.AddWithValue("@edt", ExpirationDate);
            
            if (Notes == "")
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);

            else
                Command.Parameters.AddWithValue("@Notes", Notes);

            Command.Parameters.AddWithValue("@fees", PaidFees);
            Command.Parameters.AddWithValue("@active", IsActive);
            Command.Parameters.AddWithValue("@reason", IssueReason);
            Command.Parameters.AddWithValue("@user", CommitingUserID);


            try
            {
                Connection.Open();

                object NewID = Command.ExecuteScalar();

                if (NewID != DBNull.Value)
                {
                    return Convert.ToInt32(NewID);
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

        public static int GetLicenseIDWhichIssuedDueToApplicationID(int AppID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT LicenseID FROM Licenses WHERE Applicationid = @appid";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@appid", AppID);

            try
            {
                Connection.Open();

                object LicenseID = Command.ExecuteScalar();

                return (LicenseID == null ? -1 : Convert.ToInt32(LicenseID));
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


        public static bool IsExpired(int LocalDrivingLicenseID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT found=1 FROM Licenses WHERE Licenses.licenseid = @LID AND GETDATE() <= licenses.ExpirationDate";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@LID", LocalDrivingLicenseID);

            try
            {
                Connection.Open();

                return (Command.ExecuteScalar() == null);
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

        public static bool DoesLicenseWithIDExist(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT 1 FROM Licenses WHERE Licenses.LicenseID = @param1;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@param1", ID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                return (Result != null);
            }

            catch
            {
                return false;
            }

            finally
            {
                Connection.Close();
            }
        }

        public static bool DeactiveLicense(int LocalLicenseID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"Update Licenses SET IsActive = 0 WHERE LicenseID = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", LocalLicenseID);

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


        public static int DetainLicense(int LicenseID, float Fine, int CommitingUserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO DetainedLicenses
                                    VALUES (@LID, format(getdate(), 'dd-MMM-yyyy'), @fine ,@user, 0, null, null, null);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@LID", LicenseID);
            Command.Parameters.AddWithValue("@fine", Fine);
            Command.Parameters.AddWithValue("@user", CommitingUserID);

            try
            {
                Connection.Open();

                object NewDetainID = Command.ExecuteScalar();

                return  (NewDetainID != DBNull.Value ? Convert.ToInt32(NewDetainID) : -1) ;

            }

            catch
            {
                return -1;
            }

            finally
            {
                Connection.Close();
            }
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT found=1 FROM DetainedLicenses WHERE DetainedLicenses.licenseid = @LID AND DetainedLicenses.IsReleased = 0";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@LID", LicenseID);

            try
            {
                Connection.Open();

                return (Command.ExecuteScalar() != null);
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
