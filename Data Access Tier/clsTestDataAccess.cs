using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsTestDataAccess
    {
        public static bool FindByTestID(int TestID, ref int TAID, ref bool TestResult, ref string N, ref int U)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM Tests WHERE testid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", TestID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    TAID = Convert.ToInt32(R["testappointmentid"]);
                    TestResult = Convert.ToBoolean(R["Testresult"]);
                    N = R["notes"] == DBNull.Value ? "" : R["notes"].ToString();
                    U = Convert.ToInt32(R["Createdbyuserid"]);
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

        public static bool FindByTestAppointmentID(int TestAppointmentID, ref int TID, ref bool TestResult, ref string N, ref int U)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM Tests inner join testappointments on tests.testappointmentid = testappointments.testappointmentid WHERE tests.testappointmentid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", TestAppointmentID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    TID = Convert.ToInt32(R["testid"]);
                    TestResult = Convert.ToBoolean(R["Testresult"]);
                    N = R["notes"] == DBNull.Value ? "" : R["notes"].ToString();
                    U = Convert.ToInt32(R["Createdbyuserid"]);
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


        public static int AddNew(int TestAppointmentID, bool TestResult, string Notes, int CommitingUserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO Tests
                                    VALUES (@taid, @r, @n ,@u);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@taid", TestAppointmentID);
            Command.Parameters.AddWithValue("@r", TestResult);
            Command.Parameters.AddWithValue("@u", CommitingUserID);

            if (Notes == "")
                Command.Parameters.AddWithValue("@n", DBNull.Value);

            else
                Command.Parameters.AddWithValue("@n", Notes);


            try
            {
                Connection.Open();

                object NewID = Command.ExecuteScalar();

                if (NewID != null && NewID != DBNull.Value)
                    return Convert.ToInt32(NewID);

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

        public static bool Update(int TestID, string NewNotes)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE Tests
                                    SET Notes = @n
                                    WHERE testid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            if (NewNotes == "")
                Command.Parameters.AddWithValue("@n", DBNull.Value);

            else
                Command.Parameters.AddWithValue("@n", NewNotes);

            Command.Parameters.AddWithValue("@id", TestID);

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
