using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccessTier
{
    public static class clsNewLocalDrivingLicenseApplicationDataAccess
    {

        public static bool DoesLocalDrivingLicenseApplicationPassThatTestType(int LDLAppID, byte TestType)
        {
            SqlConnection Conn = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT SUM(Cast (Tests.TestResult AS int)) from Tests inner join TestAppointments on TestAppointments.TestAppointmentID = tests.TestAppointmentID 
inner join LocalDrivingLicenseApplications on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @ldlappid AND TestAppointments.TestTypeID = @tt ;";

            SqlCommand Comm = new SqlCommand(CommandText, Conn);
            Comm.Parameters.AddWithValue("@ldlappid", LDLAppID);
            Comm.Parameters.AddWithValue("@tt", TestType);

            try
            {
                Conn.Open();

                object PassedTestsInThatType = Comm.ExecuteScalar();

                if (PassedTestsInThatType != null && PassedTestsInThatType != DBNull.Value)
                    return Convert.ToBoolean(PassedTestsInThatType);

                return false;
            }

            catch
            {
            }

            finally
            {
                Conn.Close();
            }

            return false;
        }


        public static sbyte GetNumberOfPassedTests(int LDLAppID)
        {
            SqlConnection Conn = new SqlConnection(DataAccessTier.clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"select count(case when testresult = 1 then 388292828 else NULL end) from
LocalDrivingLicenseApplications inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @id;";

            SqlCommand Comm = new SqlCommand(CommandText, Conn);
            Comm.Parameters.AddWithValue("@id", LDLAppID);

            try
            {
                Conn.Open();

                object NumberOfPassedTests = Comm.ExecuteScalar();

                if (NumberOfPassedTests != null)
                {
                    return Convert.ToSByte(NumberOfPassedTests);
                }
            }

            catch
            {
            }

            finally
            {
                Conn.Close();
            }

            return -1;
        }

        public static bool Delete(int NewLDLAppID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@id", NewLDLAppID);

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

        public static int DoesApplicantHaveNonCancelledNewLDLApplication(int ApplicantPersonID, int LicenseClassID)
        {
            SqlConnection Conn = new SqlConnection(DataAccessTier.clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT applications.ApplicationID
                FROM LocalDrivingLicenseApplications Inner JOIN Applications ON applications.applicationid = LocalDrivingLicenseApplications.applicationid 
            WHERE applications.applicantPersonID = @id AND LocalDrivingLicenseApplications.LicenseClassID = @lcid AND applicationStatus <> 2;";

            SqlCommand Comm = new SqlCommand(CommandText, Conn);
            Comm.Parameters.AddWithValue("@id", ApplicantPersonID);
            Comm.Parameters.AddWithValue("@lcid", LicenseClassID);

            try
            {
                Conn.Open();

                object AppID = Comm.ExecuteScalar();

                if (AppID != null)
                {
                    return (int)AppID;
                }
            }

            catch
            {
            }

            finally
            {
                Conn.Close();
            }

            return -1;
        }

        public static bool DoesApplicantHaveLDLOfSameLicenseClass(int ApplicantPersonID, int LicenseClassID)
        {
            SqlConnection Conn = new SqlConnection(DataAccessTier.clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"select 1 from licenses inner join applications on Applications.ApplicationID = licenses.ApplicationID
WHERE ApplicantPersonID = @id AND LicenseClass = @lcid;";

            SqlCommand Comm = new SqlCommand(CommandText, Conn);
            Comm.Parameters.AddWithValue("@id", ApplicantPersonID);
            Comm.Parameters.AddWithValue("@lcid", LicenseClassID);

            try
            {
                Conn.Open();

                object AppID = Comm.ExecuteScalar();

                return (AppID != null);
            }

            catch
            {
            }

            finally
            {
                Conn.Close();
            }

            return false;
        }

        public static DataTable GetAll()
        {
            DataTable NewLocalDrivingLicenseApplicationsList = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM AllNewLocalDrivingLicenseApplications ORDER BY [Application Date] DESC;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();

                Reader = Command.ExecuteReader();
                NewLocalDrivingLicenseApplicationsList = new DataTable();
                NewLocalDrivingLicenseApplicationsList.Load(Reader);     // automatically close the reader after loading
            }

            catch
            {

            }

            finally
            {
                Connection.Close();
            }

            return NewLocalDrivingLicenseApplicationsList;
        }

        public static int AddNew(int ApplicationID, int LicenseClassNumber)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO LocalDrivingLicenseApplications
                                    VALUES (@appid, @LicenseClassID);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@appid", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassNumber);

            try
            {
                Connection.Open();

                object NewID = Command.ExecuteScalar();

                if (NewID != null && NewID != DBNull.Value)
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

        public static bool Update(int NewLDLAppID, int UpdatedLicenseClassID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE localdrivinglicenseapplications
                                    SET licenseclassid = @lcid
                                    WHERE localdrivinglicenseapplicationid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@id", NewLDLAppID);
            Command.Parameters.AddWithValue("@lcid", UpdatedLicenseClassID);

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

        public static bool Find( ref int AppID,ref int PId,ref DateTime Date,ref int ApplicationType, ref int Status,ref DateTime LastStatusDate, ref float PaidFees,ref  int CreatedByUserID, ref int NewLocalDrivingLicenseApplicationID, ref byte LicenseClassID)
        {
            SqlConnection Conn = new SqlConnection(DataAccessTier.clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT  LocalDrivingLicenseApplications.LicenseClassID , Applications.* FROM LocalDrivingLicenseApplications Inner JOIN Applications ON applications.applicationid = LocalDrivingLicenseApplications.applicationid WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @id;";

            SqlCommand Comm = new SqlCommand(CommandText, Conn);
            Comm.Parameters.AddWithValue("@id", NewLocalDrivingLicenseApplicationID);

            try
            {
                Conn.Open();

                SqlDataReader R = Comm.ExecuteReader();

                if (R.Read())
                {
                    
                    AppID = (int)R["applicationid"];
                    PId = (int)R["applicantpersonid"];
                    Date = (DateTime)(R["applicationdate"]);
                    ApplicationType = (int)R["applicationtypeid"];
                    Status = Convert.ToInt32(R["applicationstatus"]);
                    LastStatusDate = (DateTime)(R["laststatusdate"]);
                    PaidFees = Convert.ToSingle(R["Paidfees"]);
                    CreatedByUserID = (int)R["createdbyuserid"]; ;
                    LicenseClassID = Convert.ToByte(R["licenseclassid"]);

                    return true;
                }
            }

            catch
            {
            }

            finally
            {
                Conn.Close();
            }

            return false;
        }
    }
}
