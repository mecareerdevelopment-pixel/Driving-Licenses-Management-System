using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public static class clsDriverDataAccess
    {

        public static DataTable GetAll()
        {
            DataTable AllDrivers = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "select Driverid as [Driver ID], drivers.personid as [Person ID],NationalNo as [National No.], Firstname + ' ' + secondname + ' ' + (case when thirdname is null then '' else thirdname + ' ' end) + lastname as [Full Name] , format(drivers.CreatedDate, 'dd,MMM,yyyy') as [Date],   (select count(*) from licenses where Licenses.DriverID = drivers.DriverID And IsActive = 1) as [Active Licenses] from drivers inner join people on people.PersonID  = Drivers.PersonID;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            
            try
            {
                Connection.Open();

                SqlDataReader R = Command.ExecuteReader();
                AllDrivers.Load(R);        // it automatically closes the reader.

                return AllDrivers;
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


        public static int GetDriverIDWithPersonID(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT DriverID FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object DriverID =  Command.ExecuteScalar();

                return DriverID == null ? -1 : Convert.ToInt32(DriverID);
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


        public static int AddNewDriverAndGetID(int PersonID, int CommitingUser)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO Drivers
                                   VALUES (@PersonID, @CommitingUser, FORMAT(GETDATE(), 'dd,MMM,yyyy'));
                                   SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CommitingUser", CommitingUser);

            try
            {
                Connection.Open();

                object DriverID = Command.ExecuteScalar();

                if (DriverID != DBNull.Value)
                    return Convert.ToInt32(DriverID);
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


        public static int GetPersonID(int DriverID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT dbo.Drivers.PersonID FROM dbo.Drivers WHERE DriverID = @DriverID;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();

                object PersonID = Command.ExecuteScalar();

                if (PersonID != null)
                    return Convert.ToInt32(PersonID);
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
