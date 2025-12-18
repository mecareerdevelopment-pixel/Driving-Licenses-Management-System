using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessTier;
using System.Threading.Tasks;

namespace BusinessLogicTier
{
    public class clsTest
    {
        private enmMode _Mode = enmMode.AddNew;

        public clsTest()
        {

        }

        public clsTest(int TestID, int TestAppointmentID, bool Result, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.Result = Result;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enmMode.Update;
        }

        public int TestID
            { set; get; }

        public int TestAppointmentID
            { set; get; }

        public bool Result
        { set; get; }

        public string Notes
        { set; get; }

        public int CreatedByUserID        // No need for composition of user here
        { set; get; }

        private bool _AddNew()
        {
            TestID = clsTestDataAccess.AddNew(TestAppointmentID, Result, Notes, CreatedByUserID);

            return TestID != -1;
        }

        private bool _Update()
        {
            return clsTestDataAccess.Update(TestID, Notes);
        }


        public bool Save()
        {
            if (_Mode == enmMode.AddNew)
            {
                if (_AddNew())
                {
                    _Mode = enmMode.Update;

                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return _Update();
            }
        }


        public static clsTest FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = 0; bool Result = false; string Notes = ""; int CreatedByUserID = 0;

            if (clsTestDataAccess.FindByTestAppointmentID(TestAppointmentID, ref TestID, ref Result, ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, Result, Notes, CreatedByUserID);

            return null;
        }
    }
}
