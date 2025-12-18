using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Data_Access_Tier;

namespace BusinessLogicTier
{
    public class clsLicenseDetention
    {

        public clsLicenseDetention(int DetainID, int LicenseID, bool IsReleased, int DetainedByUserID, int ReleaseApplicationID, float FineFees, DateTime DetainDate, DateTime ReleaseDate, int ReleasedByUserID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.IsReleased = IsReleased;
            this.DetainedByUserID = DetainedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.FineFees = FineFees;
            this.DetentionDate = DetainDate;
            this.ReleasingDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
        }

        public int DetainID
        {
            get;set;
        }

        public int LicenseID
        {
            get;
            set;
        }

        public bool IsReleased
        {
            get;
            set;
        }

        public int DetainedByUserID
        {
            get;
            set;
        }

        public int ReleaseApplicationID
        {
            get;
            set;
        }

        public float FineFees
        {
            get;
            set;
        }

        public DateTime DetentionDate
        {
            get;
            set;
        }

        public DateTime ReleasingDate
        {
            get;
            set;
        }

        public int ReleasedByUserID
        {
            get;
            set;
        }

        public clsUser DetainingUser
        {
            get
            {
                return clsUser.FindByUserID(DetainedByUserID);
            }
        }

        public clsUser ReleasingUser
        {
            get
            {
                return clsUser.FindByUserID(ReleasedByUserID);

            }
        }


        public static DataTable GetAllDetainedLicenses()
        {
            return clsLicenseDetentionDataAccess.GetAllDetainedLicenses();
        }

        public static clsLicenseDetention FindByDetainedLicenseID(int LicenseID)
        {
            int DetainID = default;
            bool IsReleased = default;
            int DetainedByUserID = default;
            int ReleaseApplicationID = default;
            float FineFees = default;
            DateTime DetainDate = default;
            DateTime ReleaseDate = default;
            int ReleasedByUserID = default;


            if (clsLicenseDetentionDataAccess.Find(ref DetainID, ref LicenseID, ref IsReleased, ref DetainedByUserID, ref ReleaseApplicationID, ref FineFees, ref DetainDate, ref ReleaseDate, ref ReleasedByUserID))
            {
                return new clsLicenseDetention(DetainID, LicenseID,  IsReleased,  DetainedByUserID,  ReleaseApplicationID,  FineFees,  DetainDate,  ReleaseDate,  ReleasedByUserID);
            }

            return null;
        }

    }
}
