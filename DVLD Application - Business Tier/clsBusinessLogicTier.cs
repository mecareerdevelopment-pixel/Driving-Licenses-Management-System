
using System.Data;
using DataAccessTier;

namespace BusinessLogicTier
{
    public static class clsBusinessLogicTier
    {
        public static DataTable GetCountriesList()
        {
            return clsDataAccessTier.GetCountriesList();
        }

        public static bool DoesNationalNumberExist(string NationalNumber)
        {
            NationalNumber = NationalNumber.Trim();
            return clsPersonDataAccess.DoesNationalNumberExist(NationalNumber);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.GetAllPeople();
        }
    }
}
