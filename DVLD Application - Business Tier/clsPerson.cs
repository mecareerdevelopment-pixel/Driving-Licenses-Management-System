using System;
using DataAccessTier;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLogicTier
{
    public class clsPerson
    {
        public clsPerson()
        {

        }

        public clsPerson(int ID, string FN, string SN, string TN, string LN, string NNo, string AD, string Ph, string Ml, int CID, bool G, string ImPth, DateTime BD)
        {
            this.ID = ID;
            FirstName = FN;
            SecondName = SN;
            ThirdName = TN;
            LastName = LN;
            NationalNumber = NNo;
            Gender = G;
            ImagePath = ImPth;
            DateOfBirth = BD;
            ContactInfo = new clsContactInfo(Ph, Ml, AD, CID);
        }

        public int ID
        { get; set; }

        public int Age
        {
            get
            {
                int CompleteYearsDifference = DateTime.Now.Year - DateOfBirth.Year;

                if (DateOfBirth.AddYears(CompleteYearsDifference) > DateTime.Now)
                    CompleteYearsDifference--;

                return CompleteYearsDifference;
            }
        }

        public string FirstName
        { get; set; }

        public string SecondName
        { get; set; }

        public string ThirdName
        { get; set; }

        public string LastName
        { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.SecondName + " " + this.ThirdName + " " + this.LastName;
            }
        }

        public bool Gender
        { get; set; }

        public string NationalNumber
        { get; set; }

        public DateTime DateOfBirth
        { get; set; }

        public string ImagePath
        { get; set; } = "";

        public clsContactInfo ContactInfo
        { get; set; } = new clsContactInfo();

        private bool _AddNewPerson()
        {
            ID = clsPersonDataAccess.AddNewPersonAndReturnID(FirstName, SecondName, ThirdName, LastName, NationalNumber, ContactInfo.Address, ContactInfo.Phone, ContactInfo.Email, ContactInfo.CountryID, Convert.ToInt16(Gender), ImagePath, DateOfBirth);
            return ID != -1;
        }

        private bool _UpdateExistingPerson()
        {
            return clsPersonDataAccess.UpdateExistingPerson(this.ID, this.FirstName, this.SecondName, ThirdName, this.LastName, NationalNumber, this.ContactInfo.Address, this.ContactInfo.Phone, this.ContactInfo.Email, this.ContactInfo.CountryID, this.Gender, this.ImagePath, this.DateOfBirth);
        }

        public bool Save()
        {
            return (ID == -1 ? _AddNewPerson() : _UpdateExistingPerson());
        }

        public static clsPerson Find(object FindBy)
        {
            string fn = default, sn = default, tn = default, ln = default, NN = default, AD = default, Ph = default, Ml = default, IMP = default;
            int CID = default, id = default;
            bool G = default;
            DateTime BD = default;

            if (FindBy is int PersonID)
            {
                if (clsPersonDataAccess.FindPersonWithID(PersonID, ref fn, ref sn, ref tn, ref ln, ref NN, ref AD, ref Ph, ref Ml, ref CID, ref G, ref IMP, ref BD))
                {
                    return new clsPerson(PersonID, fn, sn, tn, ln, NN, AD, Ph, Ml, CID, G, IMP, BD);
                }
            }

            else if (FindBy is string NNo)
            {
                if (clsPersonDataAccess.FindPersonWithNationalNumber(ref id, ref fn, ref sn, ref tn, ref ln, ref NNo, ref AD, ref Ph, ref Ml, ref CID, ref G, ref IMP, ref BD))
                {
                    return new clsPerson(id, fn, sn, tn, ln, NNo, AD, Ph, Ml, CID, G, IMP, BD);
                }
            }

            return null;
        }

        public static bool DeletePersonWithID(int ID)
        {
            return clsPersonDataAccess.DeletePerson(ID);
        }


        public static bool CheckExistance(int PersonID)
        {
            return clsPersonDataAccess.DoesPersonIDExist(PersonID);
        }

        public static bool CheckExistance(string NationalNumber)
        {
            return clsPersonDataAccess.DoesNationalNumberExist(NationalNumber);
        }
    }
}
