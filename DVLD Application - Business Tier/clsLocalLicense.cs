using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Tier;
using DataAccessTier;

namespace BusinessLogicTier
{
    public enum enmLocalLicenseIssueReason
    {
        FirstTime = 1,
        Renew,
        DamagedReplacement,
        LostReplacement
    }

    public class clsLocalLicense
    {
        public clsLocalLicense(int ID, int ApplicationID, int DriverID, byte LicenseClassID, DateTime IssuingDate, DateTime ExpirationDate, string Notes, double PaidFees, bool IsActive, enmLocalLicenseIssueReason IssueReason, int CreatedByUserID)
        {
            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssuingDate = IssuingDate;
            this.ExpirationDate = ExpirationDate;
            this.PaidFees = PaidFees;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.IssuedByUserID = CreatedByUserID;
        }

        public clsLocalLicense()
        {

        }

        public int ID
        { get; set; }

        public clsPerson ApplicantPerson
        {
            get
            {
                return clsPerson.Find(clsDriver.GetPersonID(this.DriverID));
            }
        }

        public int ApplicationID
        {
            get;set;
        }

        public int DriverID
        { get; set; }

        public clsLicenseClass LicenseClass
        {
            private set;
            get;
        }

        public byte LicenseClassID
        {
            private get
            {
                return _LicenseClassID;
            }
            set
            {
                _LicenseClassID = value;
                LicenseClass = clsLicenseClass.Find(_LicenseClassID);
            }
        }
        private byte _LicenseClassID;

        
        public DateTime IssuingDate
        {
            get;

            set;
        }

        public DateTime ExpirationDate
        {
             set;

            get;
        }

        public double PaidFees
        { set; get; }

        public string Notes
        {
            set;
            get;
        }

        public bool IsActive
        {
            get;set;
        }

        public enmLocalLicenseIssueReason IssueReason
        {
            get;

            set;
        }

        public string IssueReasonString
        {
            get
            {
                switch (this.IssueReason)
                {
                    case enmLocalLicenseIssueReason.FirstTime:
                        return "First Time";

                    case enmLocalLicenseIssueReason.Renew:
                        return "Renewing";

                    case enmLocalLicenseIssueReason.DamagedReplacement:
                        return "Replacement For Damaged";

                    case enmLocalLicenseIssueReason.LostReplacement:
                        return "Replacement For Lost";

                    default:
                        return "";
                }
            }
        }
        public int IssuedByUserID
        {
            get;
            set;
        }

        public bool IsExpired()
        {
            return clsLocalLicenseDataAccess.IsExpired(this.ID);
        }

        public bool IsDetained
        {
            get
            {
                return clsLocalLicenseDataAccess.IsLicenseDetained(this.ID);
            }
        }

        public bool IssueForFirstTime()
        {
            DriverID = clsDriver.GetDriverIDWithPersonID(ApplicantPerson.ID);

            if (DriverID == -1)     // This License is the First Most License For the person
            {
                DriverID = clsDriver.AddNewDriverAndGetID(ApplicantPerson.ID, IssuedByUserID);
            }

            ID = clsLocalLicenseDataAccess.AddNew(ApplicationID, DriverID, LicenseClassID, DateTime.Today, DateTime.Today.AddYears(LicenseClass.ValidityLength), Notes, PaidFees, true, Convert.ToByte(IssueReason), IssuedByUserID);

            if (ID != -1)
            {
                clsApplication.Find(this.ApplicationID).ChangeStatus(enmApplicationStatus.Completed);

                return true;
            }

            return false;
        }

        public static clsLocalLicense Find(int LicenseID)
        {
            int AppID = default; int DriverID = default; byte LicenseClassID = 0; DateTime IssueDate = default; DateTime ExpDate = default; string Notes = default; double PaidFees = default; bool IsActive = default; byte IssueReason = 0; int CreatedByUserID = default;

            if (clsLocalLicenseDataAccess.Find(ref LicenseID, ref AppID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpDate , ref Notes, ref PaidFees, ref IsActive, ref IssueReason , ref CreatedByUserID))
            {
                return new clsLocalLicense(LicenseID, AppID, DriverID, LicenseClassID, IssueDate, ExpDate, Notes, PaidFees, IsActive, (enmLocalLicenseIssueReason)IssueReason, CreatedByUserID);
            }

            return null;
        }

        public static bool DoesLicenseWithIDExist(int ID)
        {
            return clsLocalLicenseDataAccess.DoesLicenseWithIDExist(ID);
        }

        public static int GetLicenseIDWhichIssuedDueToApplicationID(int AppID)
        {
            return clsLocalLicenseDataAccess.GetLicenseIDWhichIssuedDueToApplicationID(AppID);
        }

        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            return clsLocalLicenseDataAccess.GetAllLicensesForPerson(PersonID);
        }


        public bool Renew(int CreatingUserID)
        {
            // the _BackingLocalLicense (this) Wil be the new license in other words, the renewd version

            // Logic Of renewing is on two stages ... creating application and editing dataof this license

            // -------- First Satage -------
            clsApplication RenewLicenseApplication = new clsApplication();
            RenewLicenseApplication.ApplicantPersonID = clsDriver.GetPersonID(this.DriverID);
            RenewLicenseApplication.ApplicationType = enmApplicationType.Renew;
            RenewLicenseApplication.PaidFees = Convert.ToSingle(clsApplicationType.Find(Convert.ToInt32(RenewLicenseApplication.ApplicationType)).Fees);
            RenewLicenseApplication.CreatedByUserID = CreatingUserID;
            //------------------------------



            // ---------- Second Stage ----------
            if (!RenewLicenseApplication.Save())
            {
                return false;
            }

            this.ApplicationID = RenewLicenseApplication.ApplicationID;

            if (!clsLocalLicense.DeactiveLicense(this.ID))
            {
                return false;
            }
            this.IsActive = false;

            this.IssuedByUserID = CreatingUserID;
            this.IssueReason = enmLocalLicenseIssueReason.Renew;
            this.IssuingDate = DateTime.Today;
            this.ExpirationDate = DateTime.Today.AddYears(this.LicenseClass.ValidityLength);
            this.PaidFees = this.LicenseClass.Fees;
            this.IsActive = true;



            this.ID = clsLocalLicenseDataAccess.AddNew(RenewLicenseApplication.ApplicationID, this.DriverID, this.LicenseClassID, this.IssuingDate, this.ExpirationDate, this.Notes, this.PaidFees, true, Convert.ToByte(IssueReason), this.IssuedByUserID);

            if (this.ID != -1)
            {
                RenewLicenseApplication.ChangeStatus(enmApplicationStatus.Completed);

                return true;
            }

            return false;

            // ---------------------------------------


        }

        public int Detain(float Fine, int CommitingUserID)
        {
            return clsLocalLicenseDataAccess.DetainLicense(this.ID, Fine, CommitingUserID);
        }


        public clsLocalLicense IssueReplacement(int CreatingUserID, bool IsLostReplacement)
        {
            // Logic Of replacing is on two stages ... creating application for replacement and creating new local license and fill its data


            // ------------------------- First Satage ------------------------- creating application for replacement
            clsApplication ReplaceLicenseApplication = new clsApplication();
            ReplaceLicenseApplication.ApplicantPersonID = clsDriver.GetPersonID(this.DriverID);
            ReplaceLicenseApplication.ApplicationType = IsLostReplacement ? enmApplicationType.RepLost : enmApplicationType.RepDamaged ;
            ReplaceLicenseApplication.PaidFees = Convert.ToSingle(clsApplicationType.Find(Convert.ToInt32(ReplaceLicenseApplication.ApplicationType)).Fees);
            ReplaceLicenseApplication.CreatedByUserID = CreatingUserID;

            if (!ReplaceLicenseApplication.Save())
            {
                return null;
            }
            //------------------------------------------------------------------






            // ------------------------- Second Stage -------------------------- creating new local license and fill its data
            clsLocalLicense NewReplacingLicense = new clsLocalLicense();
            NewReplacingLicense.ApplicationID = ReplaceLicenseApplication.ApplicationID;

            if (!clsLocalLicense.DeactiveLicense(this.ID))
            {
                return null;
            }
            this.IsActive = false;

            NewReplacingLicense.IssuedByUserID = CreatingUserID;
            NewReplacingLicense.IssueReason = IsLostReplacement ? enmLocalLicenseIssueReason.LostReplacement : enmLocalLicenseIssueReason.DamagedReplacement;
            NewReplacingLicense.IssuingDate = this.IssuingDate;
            NewReplacingLicense.ExpirationDate = this.ExpirationDate;
            NewReplacingLicense.PaidFees = this.PaidFees;
            NewReplacingLicense.IsActive = true;        // since netered here then the (this) object licnese is active
            NewReplacingLicense.Notes = this.Notes;
            NewReplacingLicense.DriverID = this.DriverID;
            NewReplacingLicense.LicenseClassID = this.LicenseClassID;


            NewReplacingLicense.ID = clsLocalLicenseDataAccess.AddNew(NewReplacingLicense.ApplicationID, NewReplacingLicense.DriverID, NewReplacingLicense.LicenseClassID, NewReplacingLicense.IssuingDate, NewReplacingLicense.ExpirationDate, NewReplacingLicense.Notes, NewReplacingLicense.PaidFees, true, Convert.ToByte(NewReplacingLicense.IssueReason), NewReplacingLicense.IssuedByUserID);

            if (NewReplacingLicense.ID != -1)
            {
                ReplaceLicenseApplication.ChangeStatus(enmApplicationStatus.Completed);

                return NewReplacingLicense;
            }

            return null;
            // ----------------------------------------------------------------

        }

        public static bool DeactiveLicense(int LocalLicenseID)
        {
            return clsLocalLicenseDataAccess.DeactiveLicense(LocalLicenseID);
        }


        public bool ReleaseDetention(out int ReleaseDetainedLicenseApplicationID, int ReleasingUserID)
        {
            // Logic Of release detained license has two stages ... creating application from type release detained license and put application's data in the detained licenses table in database


            // ------------------------- First Satage ------------------------- creating application from type release detained license
            clsApplication ReleaseDetainedLicenseApplication = new clsApplication();
            ReleaseDetainedLicenseApplication.ApplicantPersonID = clsDriver.GetPersonID(this.DriverID);
            ReleaseDetainedLicenseApplication.ApplicationType = enmApplicationType.ReleaseDetained;
            ReleaseDetainedLicenseApplication.PaidFees = Convert.ToSingle(clsApplicationType.Find(Convert.ToInt32(enmApplicationType.ReleaseDetained)).Fees);
            ReleaseDetainedLicenseApplication.CreatedByUserID = ReleasingUserID;

            if (!ReleaseDetainedLicenseApplication.Save())
            {
                ReleaseDetainedLicenseApplicationID = -1;
                return false;
            }

            ReleaseDetainedLicenseApplicationID = ReleaseDetainedLicenseApplication.ApplicationID;
            //------------------------------------------------------------------







            // ------------------------- Second Stage -------------------------- put application's data in the detained licenses table in database
            if (clsLicenseDetentionDataAccess.ReleaseLicense(this.ID, ReleasingUserID, ReleaseDetainedLicenseApplicationID))
            {
                ReleaseDetainedLicenseApplication.ChangeStatus(enmApplicationStatus.Completed);
                return true;
            }

            else
            {
                return false;
            }
            // ----------------------------------------------------------------
        }


    }
}
