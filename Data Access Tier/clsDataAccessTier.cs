using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace DataAccessTier
{
    public static class clsDataAccessTier
    {
        public static DataTable GetCountriesList()
        {
            DataTable CountriesList = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessTierConfiguration.ConnectionString);

            string CommandText = "SELECT CountryName FROM Countries;";

            SqlCommand Command = new SqlCommand(CommandText, Connection);

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();

                Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    CountriesList = new DataTable();
                    CountriesList.Load(Reader);
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

            return CountriesList;
        }

    }
}
