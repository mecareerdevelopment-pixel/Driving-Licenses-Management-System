using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTier
{
    public class clsRetakeTestApplication
    {
        public clsApplication RetakeTestApplication = new clsApplication();

        public clsRetakeTestApplication(int ApplicantPersonID, int CommitingUser)
        {
            this.RetakeTestApplication.ApplicantPersonID = ApplicantPersonID;
            RetakeTestApplication.ApplicationType = enmApplicationType.RetakeTest;
            RetakeTestApplication.PaidFees = Convert.ToSingle(clsApplicationType.Find((int)enmApplicationType.RetakeTest).Fees);
            RetakeTestApplication.CreatedByUserID = CommitingUser;
            RetakeTestApplication.Status = enmApplicationStatus.Completed;
        }

        public clsRetakeTestApplication(clsApplication Application)
        {
            RetakeTestApplication = Application;
        }

        public void SetCompleted()
        {
            RetakeTestApplication.ChangeStatus(enmApplicationStatus.Completed);
        }

        public bool Save()
        {
            return RetakeTestApplication.Save();
        }

        public static clsRetakeTestApplication Find(int RTAppID)
        {
            clsApplication Application = clsApplication.Find(RTAppID);

            return Application == null ? null : new clsRetakeTestApplication(Application);
        }
    }
}
