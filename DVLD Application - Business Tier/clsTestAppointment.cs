using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessTier;

namespace BusinessLogicTier
{

    public class clsTestAppointment
    {
        public int ID
        { get; set; }

        private enmMode _Mode = enmMode.AddNew;

        public enmTestTypes TestType
        { 
            get
            {
                return _TestType;
            }
            
            set
            {
                _TestType = (enmTestTypes)value;
            } 
        }
        private enmTestTypes _TestType;

        public int LocalDrivingLicenseApplicationID
        { get; set; }

        public int CreatedByUserID
        {
            get
            {
                return _CreatedByUserID;
            }

            set
            {
                CreatedByUser = clsUser.FindByUserID(value);
                _CreatedByUserID = value;
            }
        }
        private int _CreatedByUserID;

        public clsUser CreatedByUser
        {
            get;
            set;
        }

        public double Fees
        { get; set; }

        public bool IsLocked
        { get; set; } = false;

        public int RetakeTestApplicationID
        { get; set; } = -1;

        public DateTime Date
        { get; set; }

        public clsTestAppointment()
        {

        }

        public clsTestAppointment(int ID, ref int TestTypeID, ref double Fees, ref int LDLAppID, ref int CommitingUserID, ref bool IsLocked, ref int RTAppID, ref DateTime Date)
        {
            CreatedByUserID = CommitingUserID;
            LocalDrivingLicenseApplicationID = LDLAppID;
            this.ID = ID;
            TestType = (enmTestTypes)TestTypeID;
            this.Date = Date;
            this.Fees = Fees;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RTAppID;

            _Mode = enmMode.Update;
        }


        public static int GetPrevTestingTrialsCount(int LDLAppID, enmTestTypes TT)
        {
            return clsTestAppointmentDataAccess.GetPrevTestingTrialsCount(LDLAppID, Convert.ToByte(TT));
        }


        public static clsTestAppointment Find(int TAID)
        {
            int TestTypeID = default;  double Fees = default;  int LDLAppID = default;int CommitingUserID = default; bool IsLocked = default; int RTAppID = default;  DateTime Date = default;

            if (clsTestAppointmentDataAccess.Find(TAID, ref TestTypeID, ref Fees, ref LDLAppID, ref CommitingUserID, ref IsLocked, ref RTAppID, ref Date))
                return new clsTestAppointment(TAID, ref TestTypeID, ref Fees, ref LDLAppID, ref CommitingUserID, ref IsLocked, ref RTAppID, ref Date);

            return null;
        }


        public static DataTable GetAllAppointmentsForLDLAndTestType(int LDLAppID, enmTestTypes TestType)
        {
            return clsTestAppointmentDataAccess.GetAllAppointmentsForLDLAndTestType(LDLAppID, (int)TestType);
        }

        public static bool IsThereActiveTestAppointment(int LDLAppID, enmTestTypes TT, out int TestAppointmentID)
        {
            TestAppointmentID = clsTestAppointmentDataAccess.IsThereActiveTestAppointment(LDLAppID, Convert.ToByte(TT));
            
            if (TestAppointmentID != -1)
                return true;

            return false; ;
        }

        public static bool IsTherePreviousTestAppointment(int LDLAppID, enmTestTypes TT)
        {
            return clsTestAppointmentDataAccess.IsTherePreviousTestAppointment(LDLAppID, Convert.ToByte(TT));
        }

        public bool _AddNewTestAppointment()
        {
            ID = clsTestAppointmentDataAccess.AddNew((int)TestType, LocalDrivingLicenseApplicationID, Date, Fees, CreatedByUserID, false, RetakeTestApplicationID);

            return ID != -1;

        }

        public bool _Update()
        {
            return clsTestAppointmentDataAccess.Update(ID, Date);
        }

        public bool Save()
        {
            if (_Mode == enmMode.AddNew)
            {
                if (_AddNewTestAppointment())
                {
                    _Mode = enmMode.Update;
                    return true;
                }

                return false;
            }

            else
            {
                return _Update();
            }
        }


        public static bool LockAppointment(int ID)
        {
            return clsTestAppointmentDataAccess.LockAppointment(ID);
        }

    }
}
