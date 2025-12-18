using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsUserDataAccess
    {

        public static string GetHashedValueOfPassword(int UserID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT Users.Password FROM Users WHERE UserID = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", UserID);

            try
            {
                Connection.Open();

                return Command.ExecuteScalar().ToString();
            }

            catch
            {
                return null;
            }

            finally
            {
                Connection.Close();
            }
        }

        public static object GetIsActiveFieldIfFound(string Username, string Password)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT Users.IsActive FROM Users WHERE UserName = @u AND Password = @p";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@u", Username);
            Command.Parameters.AddWithValue("@p", Password);

            try
            {
                Connection.Open();

                return Command.ExecuteScalar();
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

        public static bool DoesUsernameExist(string username)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT 1 FROM Users WHERE Users.UserName = @param1;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@param1", username);

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
        public static bool FindByUserID(int ID, ref int PersonId, ref string Username,  ref bool IsActive)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM Users WHERE Userid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    Username = R["username"].ToString();
                    PersonId = (int)R["Personid"];
                    IsActive = Convert.ToBoolean(R["isactive"]);

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
                R.Close();
                Connection.Close();
            }

            return false;
        }

        public static bool FindByUsernameAndPassword(ref int UserID, ref int PersonId, ref string Username, ref string Password, ref bool IsActive)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM Users WHERE UserName = @un AND PASSWORD = @ps";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@un", Username);
            Command.Parameters.AddWithValue("@ps", Password);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    UserID = (int)R["userid"];
                    PersonId = (int)R["Personid"];
                    IsActive = Convert.ToBoolean(R["isactive"]);

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
                R.Close();
                Connection.Close();
            }

            return false;
        }
        
        public static DataTable GetAllUsers()
        {
            DataTable UsersList = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT UserID as [User ID], users.PersonID as [Person ID] , 
CASE
WHEN ThirdName is not NULL THEN Firstname + ' ' + secondname + ' ' + ThirdName + ' ' + LastName
ELSE Firstname + ' ' + secondname + ' ' + LastName
END As [Full Name] , Username, isactive as [Is Active]
FROM People inner join users on users.personID = people.PersonID;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();

                Reader = Command.ExecuteReader();
                UsersList = new DataTable();
                UsersList.Load(Reader);     // automatically close the reader after loading
            }

            catch
            {
                
            }

            finally
            {
                if (Reader != null)
                    Reader.Close();

                Connection.Close();
            }

            return UsersList;
        }

        public static int AddNewUserAndReturnID(int PersonID, string Un, string Ps, bool ac)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO Users
                                    VALUES (@p, @Un, @Ps,@actv);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@p", PersonID);
            Command.Parameters.AddWithValue("@Un", Un);
            Command.Parameters.AddWithValue("@Ps", Ps);
            Command.Parameters.AddWithValue("@actv", ac);

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

        public static bool UpdateExistingUser(int ID, int PersonID, string Un, string Ps, bool ac)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE Users
                                    SET personid = @pid, username = @Us,password= @ps,isactive=@tn
                                    WHERE userid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@id", ID);
            Command.Parameters.AddWithValue("@pid", PersonID);
            Command.Parameters.AddWithValue("@Us", Un);
            Command.Parameters.AddWithValue("@ps", Ps);
            Command.Parameters.AddWithValue("@tn", ac);

            int RowsAffected = 0;

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();
            }

            catch
            {

            }

            finally
            {
                Connection.Close();
            }

            return Convert.ToBoolean(RowsAffected);
        }

        public static bool ChangePassword(int UserID, string NewPassword_HashedValue)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE Users
                                    SET password= @password
                                    WHERE userid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", UserID);
            Command.Parameters.AddWithValue("@password", NewPassword_HashedValue);

            int RowsAffected = 0;

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();
            }

            catch
            {

            }

            finally
            {
                Connection.Close();
            }

            return Convert.ToBoolean(RowsAffected);
        }

        public static bool UpdateUser(int UserID, string Username, bool IsActive)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE Users
                                    SET isactive = @a, username = @u
                                    WHERE userid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", UserID);
            Command.Parameters.AddWithValue("@a", IsActive);
            Command.Parameters.AddWithValue("@u", Username);


            int RowsAffected = 0;

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();
            }

            catch
            {

            }

            finally
            {
                Connection.Close();
            }

            return Convert.ToBoolean(RowsAffected);
        }

        public static bool DeleteUser(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "DELETE FROM Users WHERE UserID = @id";

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


        public static bool DoesPersonIDExistForAUser(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT 1 FROM Users WHERE Users.PersonID = @param1;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@param1", PersonID);

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

    }
}
