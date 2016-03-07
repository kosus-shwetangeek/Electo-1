using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectoSystem.Entities
{
    public class StaffEntity
    {
        private bool stf_IsInUse;
        private int stf_UserId;
        private string stf_UserName;
      
        //private string stf_Key;
        private string stf_FirstName;
        private string stf_MiddleName;
        private string stf_LastName;
        private DateTime stf_DoB;
        private int stf_EmailId;
        private int stf_ContactNo;
        private int stf_GenderId;
        private string stf_Gender;
        private string stf_GenderCode;
        private int stf_AddressId;
        private string stf_Address;
        private bool stf_IsCandidate;
        private int stf_RoleId;
        private string stf_UserType;
        private string stf_Photo;
        private string stf_Password;
        private DateTime stf_CreatedDate;
        private string stf_ElectionStatus;
        private bool stf_IsElectionActive;

        public bool Stf_IsInUse
        {
            get { return stf_IsInUse; }
            set { stf_IsInUse = value; }
        }
        public string Stf_Password
        {
            get { return stf_Password; }
            set { stf_Password = value; }
        }
        public int Stf_UserId
        {
            get { return stf_UserId; }
            set { stf_UserId = value; }
        }
        public string Stf_UserName
        {
            get { return stf_UserName; }
            set { stf_UserName = value; }
        }

        //public string Stf_Key
        //{
        //    get { return stf_Key; }
        //    set { stf_Key = value; }
        //}

        public string Stf_FirstName
        {
            get { return stf_FirstName; }
            set { stf_FirstName = value; }
        }

        public string Stf_MiddleName
        {
            get { return stf_MiddleName; }
            set { stf_MiddleName = value; }
        }

        public string Stf_LastName
        {
            get { return stf_LastName; }
            set { stf_LastName = value; }
        }

        public DateTime Stf_DoB
        {
            get { return stf_DoB; }
            set { stf_DoB = value; }
        }
        public int Stf_EmailId
        {
            get { return stf_EmailId; }
            set { stf_EmailId = value; }
        }

        public int Stf_ContactNo
        {
            get { return stf_ContactNo; }
            set { stf_ContactNo = value; }
        }
        public int Stf_GenderId
        {
            get { return stf_GenderId; }
            set { stf_GenderId = value; }
        }

        public string Stf_Gender
        {
            get { return stf_Gender; }
            set { stf_Gender = value; }
        }

        public string Stf_GenderCode
        {
            get { return stf_GenderCode; }
            set { stf_GenderCode = value; }
        }
        public int Stf_AddressId
        {
            get { return stf_AddressId; }
            set { stf_AddressId = value; }
        }
        public string Stf_Address
        {
            get { return stf_Address; }
            set { stf_Address = value; }
        }

        public bool Stf_IsCandidate
        {
            get { return stf_IsCandidate; }
            set { stf_IsCandidate = value; }
        }
        public int Stf_RoleId
        {
            get { return stf_RoleId; }
            set { stf_RoleId = value; }
        }

        public string Stf_UserType
        {
            get { return stf_UserType; }
            set { stf_UserType = value; }
        }
        public string Stf_Photo
        {
            get { return stf_Photo; }
            set { stf_Photo = value; }
        }

        public DateTime Stf_CreatedDate
        {
            get { return stf_CreatedDate; }
            set { stf_CreatedDate = value; }
        }

        public bool Stf_IsElectionActive
        {
            get { return stf_IsElectionActive; }
            set { stf_IsElectionActive = value; }
        }

        public string Stf_ElectionStatus
        {
            get { return stf_ElectionStatus; }
            set { stf_ElectionStatus = value; }
        }


    }
}