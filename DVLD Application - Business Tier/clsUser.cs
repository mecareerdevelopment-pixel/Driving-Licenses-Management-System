using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccessTier;

namespace BusinessLogicTier
{
    public enum AuthenticationStatus
    {
        AuthenticatedDeactivated,
        AuthenticatedActivated,
        InvalidCredentials,
        SystemError
    }

    public class clsUser
    {
        public clsUser(int ID,int PersonId,  string Username,  bool IsActive)
        {
            this.ID = ID;
            UnderlyingPersonID = PersonId;
            this.Username = Username;
            this.IsActive = IsActive;
        }

        public clsUser()
        {

        }

        public int ID
        { get; set; }

        public int UnderlyingPersonID
        { get; set; }

        public bool IsActive
        { get; set; }

        public string Username
        { get; set; }


        public string Password
        {
            set; get;
        }

        public string PasswordHashedValue
        {
            get
            {
                return clsUserDataAccess.GetHashedValueOfPassword(this.ID);
            }
        }

        public static AuthenticationStatus AuthenticateUser(string Username, string Password)
        {
            switch (DataAccessTier.clsUserDataAccess.GetIsActiveFieldIfFound(Username, clsUtility.GetHashValue(Password)))
            {
                case null:
                    return AuthenticationStatus.InvalidCredentials;

                case false:
                    return AuthenticationStatus.AuthenticatedDeactivated;

                case true:
                    return AuthenticationStatus.AuthenticatedActivated;

                default:
                    return AuthenticationStatus.SystemError;
            }
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = default;
            string Username = default;
            bool IsActive = default;

            if (clsUserDataAccess.FindByUserID(UserID, ref PersonID, ref Username, ref IsActive))
            {
                return new clsUser(UserID, PersonID, Username, IsActive);
            }

            return null;
        }

        public static clsUser FindByUsernameAndPassword(string username, string password)
        {
            int PersonID = default, UserID = 99999999;
            bool IsActive = default;

            password = clsUtility.GetHashValue(password);

            if (clsUserDataAccess.FindByUsernameAndPassword(ref UserID, ref PersonID, ref username, ref password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, username, IsActive);
            }

            return null;
        }

        private bool _AddNewUser()
        {
            ID = clsUserDataAccess.AddNewUserAndReturnID(UnderlyingPersonID, Username, clsUtility.GetHashValue(this.Password), IsActive);

            return ID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(ID, Username, IsActive);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUserDataAccess.ChangePassword(ID, clsUtility.GetHashValue(NewPassword));
        }

        public bool Save()
        {
            return (ID == -1 ? _AddNewUser() : _UpdateUser());
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static bool DeleteUserWithID(int UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }

        public static bool DoesPersonIDExistForAUser(int PersonID)
        {
            return clsUserDataAccess.DoesPersonIDExistForAUser(PersonID);
        }

        public static bool DoesUsernameExist(string username)
        {
            return clsUserDataAccess.DoesUsernameExist(username);
        }
    }
}
