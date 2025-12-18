using System.Configuration;

namespace DataAccessTier
{
    internal static class clsDataAccessTierConfiguration
    {
        internal static string ConnectionString = ConfigurationManager.AppSettings["Connection String"];
    }
}
