using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Tier;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class clsInternationalLicense
    {

        public clsInternationalLicense()
        {

        }

        private clsInternationalLicense(int ID, int ApplicationID, int DriverID, int LocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = ID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedDueToLocalLicenseID = LocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
        }

        public int InternationalLicenseID
        {
            get;
            set;
        }

        public int ApplicationID
        {
            get;
            set;
        }

        public int DriverID
        {
            get;
            set;
        }

        public int IssuedDueToLocalLicenseID
        {
            get;
            set;
        }

        public int CreatedByUserID
        {
            get;
            set;
        }

        public DateTime IssueDate
        {
            get;
            private set;
        }

        public DateTime ExpirationDate
        {
            get; private set;
        }

        public bool IsActive
        {
            get;

            set;
        }

        private static void _DeactivateLastIssuedLicenseIfExists(int DriverID)
        {
            clsInternationalLicenseDataAccess.DeactivateLastIssuedLicenseIfExists(DriverID);
        }

        public static int GetActiveAndNonExpiredInternationalLicenseID(int DriverID)
        {
            return clsInternationalLicenseDataAccess.GetActiveAndNonExpiredInternationalLicenseID(DriverID);
        }

        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            return clsInternationalLicenseDataAccess.GetAllLicensesForPerson(PersonID);
        }

        public static DataTable GetAll()
        {
            return clsInternationalLicenseDataAccess.GetAll();
        }

        private bool _AddNewInternationalLicense()
        {
            clsInternationalLicense._DeactivateLastIssuedLicenseIfExists(this.DriverID);    // remove any active license before (as since we reached here) then local license id is EITHER attached to active but expired international license OR no international license at all

            this.InternationalLicenseID = clsInternationalLicenseDataAccess.AddNew(this.ApplicationID, this.DriverID, this.IssuedDueToLocalLicenseID, this.CreatedByUserID);
            this.IssueDate = DateTime.Today;
            this.ExpirationDate = DateTime.Today.AddYears(1);
            return this.InternationalLicenseID != -1;
        }

        public bool IssueNewInternationalLicense()
        {
            clsApplication NewInternationalLicenseApplication = new clsApplication();
            NewInternationalLicenseApplication.ApplicantPersonID = clsLocalLicense.Find(this.IssuedDueToLocalLicenseID).ApplicantPerson.ID;
            NewInternationalLicenseApplication.ApplicationType = enmApplicationType.NewInternationalLicense;
            NewInternationalLicenseApplication.PaidFees = Convert.ToSingle(clsApplicationType.Find(Convert.ToInt32(enmApplicationType.NewInternationalLicense)).Fees);
            NewInternationalLicenseApplication.CreatedByUserID = this.CreatedByUserID;

            if (!NewInternationalLicenseApplication.Save())
            {
                return false;
            }

            NewInternationalLicenseApplication.ChangeStatus(enmApplicationStatus.Completed);    // no more changes will be made on the application (it is not a local driving license application)
            this.ApplicationID = NewInternationalLicenseApplication.ApplicationID;

            if (this._AddNewInternationalLicense())
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int AppID = default; int DriverID = default; int LocalLicenseID = 0; DateTime IssueDate = default; DateTime ExpDate = default;bool IsActive = default; int CreatedByUserID = default;

            if (clsInternationalLicenseDataAccess.Find(ref InternationalLicenseID, ref AppID, ref DriverID, ref LocalLicenseID, ref IssueDate, ref ExpDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, AppID, DriverID, LocalLicenseID, IssueDate, ExpDate, IsActive, CreatedByUserID);
            }

            return null;
        }
    }
}
