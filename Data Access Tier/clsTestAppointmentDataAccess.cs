using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsTestAppointmentDataAccess
    {
        public static bool LockAppointment(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE TestAppointments
                                    SET islocked = 1
                                    WHERE testappointmentid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@id", ID);

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


        public static DataTable GetAllAppointmentsForLDLAndTestType(int LDLAppID, int TTID)
        {
            DataTable AllAppointments = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT TestAppointmentID as [Appointment ID], appointmentdate as [Appointment Date], paidfees as [Paid Fees] , islocked As [Is Locked] FROM testAppOINTMenTS Where localdrivinglicenseapplicationid = @ldlaid And TestTypeID = @ttid ORDER BY [Appointment ID] Desc;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@ldlaid", LDLAppID);
            Command.Parameters.AddWithValue("@ttid", TTID);

            try
            {
                Connection.Open();

                SqlDataReader R = Command.ExecuteReader();
                AllAppointments.Load(R);        // it automatically closes the reader.

                return AllAppointments;
            }

            catch
            {

            }

            finally
            {
                Connection.Close();     // connection automatically closes the readers in it
            }

            return null;
        }


        public static bool Find(int ID, ref int TestTypeID, ref double Fees, ref int LDLAppID, ref int CommitingUserID, ref bool IsLocked, ref int RTAppID, ref DateTime Date )
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM testappointments WHERE testappointmentid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    TestTypeID = Convert.ToInt32(R["testtypeID"]);
                    Fees = Convert.ToDouble(R["paiDfees"]);
                    RTAppID = (R["retaketestapplicationid"] == DBNull.Value ? -1 : Convert.ToInt32(R["retaketestapplicationid"]));
                    CommitingUserID = Convert.ToInt32(R["createdbyuserid"]);
                    LDLAppID = Convert.ToInt32(R["localdrivinglicenseapplicationid"]);
                    Date = (DateTime)R["appointmentdate"];
                    IsLocked = Convert.ToBoolean(R["islocked"]);
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


        public static int IsThereActiveTestAppointment(int LDLAppID, byte TT)
        {

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select testappointmentid from testappointments where testtypeid = @tt and LocalDrivingLicenseApplicationID = @ldlappid AND ISlocked = 0";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@ldlappid", LDLAppID);
            Command.Parameters.AddWithValue("@tt", TT);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                    return Convert.ToInt32(Result);
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

        public static bool IsTherePreviousTestAppointment(int LDLAppID, byte TT)
        {

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select testappointmentid from testappointments where testtypeid = @tt and LocalDrivingLicenseApplicationID = @ldlappid";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@ldlappid", LDLAppID);
            Command.Parameters.AddWithValue("@tt", TT);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                return (Result != null);
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


        public static int AddNew(int TestTypeID, int LDLAppID, DateTime D, double Fees, int CommitingUserID, bool IsLocked, int RTAppID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO TestAppointments
                                    VALUES (@ttid, @ldlappid, @d ,@f, @u, @lkd, @r);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@ttid", TestTypeID);
            Command.Parameters.AddWithValue("@ldlappid", LDLAppID);
            Command.Parameters.AddWithValue("@d", D);
            Command.Parameters.AddWithValue("@f", Fees);
            Command.Parameters.AddWithValue("@u", CommitingUserID);
            Command.Parameters.AddWithValue("@lkd", IsLocked);

            if (RTAppID == -1)
                Command.Parameters.AddWithValue("@r", DBNull.Value);

            else
                Command.Parameters.AddWithValue("@r", RTAppID);


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

        public static bool Update(int AppointmentID, DateTime NewDate)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE TestAppointments
                                    SET appointmentdate = @d
                                    WHERE testappointmentid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@d", NewDate);
            Command.Parameters.AddWithValue("@id", AppointmentID);

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


        public static int GetPrevTestingTrialsCount(int LDLAppID, byte TT)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select count(*) from testappointments where testtypeid = @tt and LocalDrivingLicenseApplicationID = @ldlappid and IsLocked = 1";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@ldlappid", LDLAppID);
            Command.Parameters.AddWithValue("@tt", TT);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                    return Convert.ToInt32(Result);
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
    }
}
