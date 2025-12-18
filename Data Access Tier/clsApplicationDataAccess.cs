using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsApplicationDataAccess
    {

        public static bool Delete(int AppID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "DELETE FROM Applications WHERE Applicationid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@id", AppID);

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

        public static bool ChangeStatusAndResetLastStatusDate(int applicationid, int changeto)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"Update Applications SET ApplicationStatus = @status , LastStatusDate = @d WHERE Applicationid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", applicationid);
            Command.Parameters.AddWithValue("@status", changeto);
            Command.Parameters.AddWithValue("@d", DateTime.Now);

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

        public static int AddNew(int ApplicantPersonID, int ApplicationTypeID, double fees, int user)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO Applications
                                    VALUES (@applicantpersonid, @appdate, @typeid ,@status, @LastSatusDate, @fees, @user);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@applicantpersonid", ApplicantPersonID);
            Command.Parameters.AddWithValue("@appdate", DateTime.Now);
            Command.Parameters.AddWithValue("@typeid", ApplicationTypeID);
            Command.Parameters.AddWithValue("@status", 1);
            Command.Parameters.AddWithValue("@LastSatusDate", DateTime.Now);
            Command.Parameters.AddWithValue("@fees", fees);
            Command.Parameters.AddWithValue("@user", user);


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

        public static bool Find(ref int AppID, ref int PId, ref DateTime Date, ref int ApplicationType, ref int Status, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            SqlConnection Conn = new SqlConnection(DataAccessTier.clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT  * FROM Applications WHERE ApplicationID = @id;";

            SqlCommand Comm = new SqlCommand(CommandText, Conn);
            Comm.Parameters.AddWithValue("@id", AppID);

            try
            {
                Conn.Open();

                SqlDataReader R = Comm.ExecuteReader();

                if (R.Read())
                {
                    PId = (int)R["applicantpersonid"];
                    Date = (DateTime)(R["applicationdate"]);
                    ApplicationType = (int)R["applicationtypeid"];
                    Status = Convert.ToInt32(R["applicationstatus"]);
                    LastStatusDate = (DateTime)(R["laststatusdate"]);
                    PaidFees = Convert.ToSingle(R["Paidfees"]);
                    CreatedByUserID = (int)R["createdbyuserid"]; 

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
