using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Data_Access_Tier;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class clsNewLocalDrivingLicenseApplication : clsApplication
    {
        public int NewLocalDrivingLicenseApplicationID
        { get; set; }

        public byte LicenseClassID
        {
            set
            {
                _LicenseClassID = value;
                LicenseClass = clsLicenseClass.Find(value);
            }

            get
            {
                return _LicenseClassID;
            }
        }
        private byte _LicenseClassID;

        public clsLicenseClass LicenseClass
        {
            get;

            private set;
        }

        public clsNewLocalDrivingLicenseApplication()   // new local driving license application
            : base()
        {
            ApplicationType = enmApplicationType.NewLocalDrivingLicense;
        }       

        public clsNewLocalDrivingLicenseApplication(int AppID, int PId, DateTime Date, enmApplicationType ApplicationType, enmApplicationStatus Status, DateTime LastStatusDate, float PaidFees, int CreatedByUserID, int NewLocalDrivingLicenseApplicationID, byte LicenseClassID)
            : base(AppID, PId, Date, ApplicationType, Status, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.NewLocalDrivingLicenseApplicationID = NewLocalDrivingLicenseApplicationID;

            this.LicenseClassID = LicenseClassID;

            // EDITING application mode to enmMode.Update occurs in application (base) constructor
        }

        private bool _AddNewNewLDLApplication()
        {
            NewLocalDrivingLicenseApplicationID = clsNewLocalDrivingLicenseApplicationDataAccess.AddNew(base.ApplicationID, this.LicenseClassID);

            return (NewLocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLDLApplication()        // can only update the license class
        {
            return clsNewLocalDrivingLicenseApplicationDataAccess.Update(NewLocalDrivingLicenseApplicationID, LicenseClassID);
        }

        public new bool Save()
        {
            if (_ApplicationMode == enmMode.AddNew)
            {
                return (base.Save() && _AddNewNewLDLApplication());
            }

            else
            {
                return _UpdateLDLApplication();
            }
        }

        public bool DoesApplicantHaveLDLOfSameLicenseClass()
        {
            return clsNewLocalDrivingLicenseApplicationDataAccess.DoesApplicantHaveLDLOfSameLicenseClass(ApplicantPersonID, LicenseClassID);
        }

        public int DoesApplicantHaveNonCancelledNewLDLApplicationOfSameLicenseClass()
        {
            int AppID = clsNewLocalDrivingLicenseApplicationDataAccess.DoesApplicantHaveNonCancelledNewLDLApplication(ApplicantPersonID, LicenseClassID);

            if (AppID == this.ApplicationID)
                return -1;

            return AppID;
        }


        public new bool ChangeStatus(enmApplicationStatus ChangeTo)
        {
            return base.ChangeStatus(ChangeTo);
        }
        
        public sbyte GetNumberOfPassedTests()
        {
            return clsNewLocalDrivingLicenseApplicationDataAccess.GetNumberOfPassedTests(this.NewLocalDrivingLicenseApplicationID);
        }









        new public bool Delete()
        {
            if (clsNewLocalDrivingLicenseApplicationDataAccess.Delete(NewLocalDrivingLicenseApplicationID))     // the LDL application deleted only if there is not appointment
                return base.Delete();

            return false;
        }

        public new static clsNewLocalDrivingLicenseApplication Find(int NewLocDLAppID)
        {
            int AppID = default; int PId = default; DateTime Date = default; int ApplicationType = default; int Status = default; DateTime LastStatusDate = default; float PaidFees = default; int CreatedByUserID = default; byte LicenseClassID = 0;

            if (DataAccessTier.clsNewLocalDrivingLicenseApplicationDataAccess.Find(ref AppID, ref PId, ref Date, ref ApplicationType, ref Status, ref LastStatusDate, ref PaidFees, ref CreatedByUserID, ref NewLocDLAppID, ref LicenseClassID))
                return new clsNewLocalDrivingLicenseApplication(AppID, PId, Date, (enmApplicationType)ApplicationType, (enmApplicationStatus)Status, LastStatusDate, PaidFees, CreatedByUserID, NewLocDLAppID, LicenseClassID);

            return null;
        }

        public static DataTable GetAll()
        {
            return clsNewLocalDrivingLicenseApplicationDataAccess.GetAll();
        }



        public static bool DoesLocalDrivingLicenseApplicationPassThatTestType(int LDLAppID, enmTestTypes TestType)
        {
            return clsNewLocalDrivingLicenseApplicationDataAccess.DoesLocalDrivingLicenseApplicationPassThatTestType(LDLAppID, Convert.ToByte(TestType));
        }


    }
}
