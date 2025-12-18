using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessTier;

namespace BusinessLogicTier
{
    public enum enmApplicationStatus
    {
        New = 1,
        Cancelled,
        Completed
    }

    public enum enmApplicationType
    {
        NewLocalDrivingLicense = 1,
        Renew,
        RepLost,
        RepDamaged,
        ReleaseDetained,
        NewInternationalLicense,
        RetakeTest
    }

    public enum enmMode
    {
        AddNew, Update
    }

    public class clsApplication
    {
        protected enmMode _ApplicationMode = enmMode.AddNew;

        public clsApplication()
        {
        }

        public clsApplication(int AppID, int PId, DateTime Date, enmApplicationType ApplicationType, enmApplicationStatus Status, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this._ApplicationMode = enmMode.Update;

            ApplicationID = AppID;
            ApplicantPersonID = PId;
            ApplicationDate = Date;
            this.ApplicationType = ApplicationType;
            this.Status = Status;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
        }

        public int ApplicationID
        { get; set; } = -1;

        public int ApplicantPersonID
        { 
            get
            {
                return _ApplicantPersonID;
            }
            set
            {
                _ApplicantPersonID = value;
                ApplicantPerson = clsPerson.Find(_ApplicantPersonID);
            }
        }
        private int _ApplicantPersonID = -1;

        public DateTime ApplicationDate
        { get; set; }

        public enmApplicationType ApplicationType
        { get; set; }

        public enmApplicationStatus Status
        { get; set; }

        public DateTime LastStatusDate
        { get; set; }

        public float PaidFees
        { get; set; }

        public clsPerson ApplicantPerson
        {
            get;
            private set;
        }

        public int CreatedByUserID
        { 
            get
            {
                return _CreatedByUserID;
            }
            
            set
            {
                _CreatedByUserID = value;
                CreatedByUser = clsUser.FindByUserID(_CreatedByUserID);
            }
        }
        private int _CreatedByUserID;

        public clsUser CreatedByUser
        { get; private set; }

        public bool ChangeStatus(enmApplicationStatus ChangeTo)
        {
            return DataAccessTier.clsApplicationDataAccess.ChangeStatusAndResetLastStatusDate(this.ApplicationID, (int)ChangeTo);
        }

        private bool _AddNew()
        {
            ApplicationID = clsApplicationDataAccess.AddNew(ApplicantPersonID, (int)ApplicationType, PaidFees, CreatedByUserID);

            return ApplicationID != -1;
        }

        public bool Save()
        {
            if (_ApplicationMode == enmMode.AddNew)
            {
                if (_AddNew())
                {
                    _ApplicationMode = enmMode.Update;

                    return true;
                }

                else
                {
                    return false;
                }
            }

            return true;    // no logic in upating the application ..... all applicaltion data is unlogical to be updated
        }

        public bool Delete()
        {
            return clsApplicationDataAccess.Delete(ApplicationID);
        }

        public static clsApplication Find(int AppID)
        {
            int PId = default; DateTime Date = default; int ApplicationType = default; int Status = default; DateTime LastStatusDate = default; float PaidFees = default; int CreatedByUserID = default;

            if (DataAccessTier.clsApplicationDataAccess.Find(ref AppID, ref PId, ref Date, ref ApplicationType, ref Status, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplication(AppID, PId, Date, (enmApplicationType)ApplicationType, (enmApplicationStatus)Status, LastStatusDate, PaidFees, CreatedByUserID);

            return null;
        }

    }
}
