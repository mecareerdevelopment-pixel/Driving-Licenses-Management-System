using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public static class clsPersonDataAccess
    {
        public static bool DoesNationalNumberExist(string NationalNumber)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT found=1 FROM People WHERE People.NationalNo = @param1;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@param1", NationalNumber);

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

        public static bool DoesPersonIDExist(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT found=1 FROM People WHERE People.PersonID = @param1;";

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

        public static DataTable GetAllPeople()
        {
            DataTable PeopleList = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT PersonID, Nationalno as [National No.], firstname as [First Name], secondname as [Second Name], thirdname as [Third Name], lastname as [Last Name], 
CASE
WHEN [gendor]=0 THEN @param1
ELSE @param2
END As Gender, dateofbirth, countryname as Nationality, Phone, Email
FROM People inner join countries on nationalitycountryID = CountryID;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@param1", "Male");
            Command.Parameters.AddWithValue("@param2", "Female");

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();

                Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    PeopleList = new DataTable();
                    PeopleList.Load(Reader);
                }
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

            return PeopleList;
        }

        public static int AddNewPersonAndReturnID(string FN, string SN, string TN, string LN, string NNo, string AD, string Ph, string Ml, int CID, short G, string ImPth, DateTime BD)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"INSERT INTO People
                                    VALUES (@nationalid, @fn, @sn,@tn,@ln,@birth,@gen,@add, @ph, @em, @countid, @imp);
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@nationalid", NNo);
            Command.Parameters.AddWithValue("@fn", FN);
            Command.Parameters.AddWithValue("@sn", SN);

            if (TN == "")
            {
                Command.Parameters.AddWithValue("@tn", DBNull.Value);
            }

            else
            {
                Command.Parameters.AddWithValue("@tn", TN);
            }

            Command.Parameters.AddWithValue("@ln", LN);
            Command.Parameters.AddWithValue("@birth", BD);
            Command.Parameters.AddWithValue("@gen", G);
            Command.Parameters.AddWithValue("@add", AD);
            Command.Parameters.AddWithValue("@ph", Ph);

            if (Ml == "")
            {
                Command.Parameters.AddWithValue("@em", DBNull.Value);
            }

            else
            {
                Command.Parameters.AddWithValue("@em", Ml);
            }

            Command.Parameters.AddWithValue("@countid", CID);

            if (ImPth == "")
            {
                Command.Parameters.AddWithValue("@imp", DBNull.Value);
            }

            else
            {
                Command.Parameters.AddWithValue("@imp", ImPth);
            }

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

        public static bool FindPersonWithNationalNumber(ref int ID, ref string FN, ref string SN, ref string TN, ref string LN, ref string NNo, ref string AD, ref string Ph, ref string Ml, ref int CID, ref bool G, ref string ImPth, ref DateTime BD)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM People WHERE NationalNo = @NNo";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@NNo", NNo);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    FN = R["firstname"].ToString();
                    SN = R["secondname"].ToString();
                    TN = (R["thirdname"] == DBNull.Value ? "" : R["thirdname"].ToString());
                    LN = R["lastname"].ToString();
                    ID = (int)R["Personid"];
                    AD = R["address"].ToString();
                    Ph = R["phone"].ToString();
                    Ml = (R["email"] == DBNull.Value ? "" : R["email"].ToString());
                    CID = (int)R["nationalitycountryid"];
                    G = Convert.ToBoolean(R["gendor"]);
                    ImPth = (R["imagepath"] == DBNull.Value ? "" : R["imagepath"].ToString());
                    BD = Convert.ToDateTime(R["dateofbirth"]);

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

        public static bool FindPersonWithID(int ID, ref string FN, ref string SN, ref string TN, ref string LN, ref string NNo, ref string AD, ref string Ph, ref string Ml, ref int CID, ref bool G, ref string ImPth, ref DateTime BD)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"SELECT * FROM People WHERE personid = @id";

            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Command.Parameters.AddWithValue("@id", ID);

            SqlDataReader R = null;

            try
            {
                Connection.Open();

                R = Command.ExecuteReader();

                if (R.Read())
                {
                    FN = R["firstname"].ToString();
                    SN = R["secondname"].ToString();
                    TN = (R["thirdname"] == DBNull.Value ? "" : R["thirdname"].ToString());
                    LN = R["lastname"].ToString();
                    NNo = R["nationalno"].ToString();
                    AD = R["address"].ToString();
                    Ph = R["phone"].ToString();
                    Ml = (R["email"] == DBNull.Value ? "" : R["email"].ToString());
                    CID = (int)R["nationalitycountryid"];
                    G = Convert.ToBoolean(R["gendor"]);
                    ImPth = (R["imagepath"] == DBNull.Value ? "" : R["imagepath"].ToString());
                    BD = Convert.ToDateTime(R["dateofbirth"]);

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

        public static bool UpdateExistingPerson(int ID, string FN, string SN, string TN, string LN, string NNo, string AD, string Ph, string Ml, int CID, bool G, string ImPth, DateTime BD)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = @"UPDATE People
                                    SET nationalno = @nationalid, firstname = @fn,secondname= @sn,thirdname=@tn,lastname=@ln,dateofbirth = @birth,gendor=@gen,address=@add, phone= @ph, email=@em, nationalitycountryid = @countid, imagepath = @imp
                                    WHERE personid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@id", ID);
            Command.Parameters.AddWithValue("@nationalid", NNo);
            Command.Parameters.AddWithValue("@fn", FN);
            Command.Parameters.AddWithValue("@sn", SN);

            if (TN == "")
            {
                Command.Parameters.AddWithValue("@tn", DBNull.Value);
            }

            else
            {
                Command.Parameters.AddWithValue("@tn", TN);
            }

            Command.Parameters.AddWithValue("@ln", LN);
            Command.Parameters.AddWithValue("@birth", BD);
            Command.Parameters.AddWithValue("@gen", G);
            Command.Parameters.AddWithValue("@add", AD);
            Command.Parameters.AddWithValue("@ph", Ph);

            if (Ml == "")
            {
                Command.Parameters.AddWithValue("@em", DBNull.Value);
            }

            else
            {
                Command.Parameters.AddWithValue("@em", Ml);
            }

            Command.Parameters.AddWithValue("@countid", CID);

            if (ImPth == "")
            {
                Command.Parameters.AddWithValue("@imp", DBNull.Value);
            }

            else
            {
                Command.Parameters.AddWithValue("@imp", ImPth);
            }

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

        public static bool DeletePerson(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "DELETE FROM People WHERE PersonID = @id";

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

        static public string GetCountryName(int CountryID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);
            string CommandText = "SELECT CountryName From Countries where countryid = @id;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            Command.Parameters.AddWithValue("@id", CountryID);

            try
            {
                Connection.Open();

                object CountryName = Command.ExecuteScalar();

                if (CountryName != null && CountryName != DBNull.Value)
                {
                    return CountryName.ToString();
                }
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
    }
}
