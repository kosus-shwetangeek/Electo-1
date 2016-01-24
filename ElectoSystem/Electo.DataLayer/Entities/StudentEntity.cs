using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electo.DataLayer.Entities
{
    public class StudentEntity: IDisposable
    {
        ~StudentEntity()
        { 
            
        }
        private string stud_IsInUse;
        private int stud_Id;
        private string stud_Name;
        private string stud_Key;
        private string stud_FName;
        private string stud_MName;
        private string stud_LName;
        private DateTime stud_DoB;
        private int stud_GenderId;
        private string stud_Gender;
        private string stud_GenderCode;
        private int stud_ClassSectionId;
        private string stud_ClassSection;
        private int stud_ClassId;
        private string stud_Class;
        private int stud_SectionId;
        private string stud_Section;
        private string stud_HouseName;
        private string stud_HouseDescription;
        private int stud_HouseDesignationId;
        private string stud_HouseDesignation;
        private string stud_HouseDesignationDescription;
        private string stud_HouseDesignationCode;
        private int stud_SenateId;
        private string stud_SenateDesignation;
        private string stud_SenateDesignationCode;
        private string stud_SenateDesignationDescription;
        private string stud_ElectionStatus;
        private bool stud_IsElectionActive;
        private int stud_HouseId;
        private string stud_UserType;
        private string stud_HouseCode;
        private string stud_Photo;
        private string stud_Password;

        public string Stud_IsInUse
        {
            get { return stud_IsInUse; }
            set { stud_IsInUse = value; }
        }

        public string Stud_Password
        {
            get { return stud_Password; }
            set { stud_Password = value; }
        }

        public int Stud_Id
        {
            get { return stud_Id; }
            set { stud_Id = value; }
        }

        public string Stud_Name
        {
            get { return stud_Name; }
            set { stud_Name = value; }
        }

        public string Stud_Key
        {
            get { return stud_Key; }
            set { stud_Key = value; }
        }

        public string Stud_FName
        {
            get { return stud_FName; }
            set { stud_FName = value; }
        }

        public string Stud_MName
        {
            get { return stud_MName; }
            set { stud_MName = value; }
        }

        public string Stud_LName
        {
            get { return stud_LName; }
            set { stud_LName = value; }
        }

        public DateTime Stud_DoB
        {
            get { return stud_DoB; }
            set { stud_DoB = value; }
        }

        public int Stud_GenderId
        {
            get { return stud_GenderId; }
            set { stud_GenderId = value; }
        }

        public string Stud_Gender
        {
            get { return stud_Gender; }
            set { stud_Gender = value; }
        }

        public string Stud_GenderCode
        {
            get { return stud_GenderCode; }
            set { stud_GenderCode = value; }
        }

        public int Stud_ClassSectionId
        {
            get { return stud_ClassSectionId; }
            set { stud_ClassSectionId = value; }
        }

        public string Stud_ClassSection
        {
            get { return stud_ClassSection; }
            set { stud_ClassSection = value; }
        }

        public int Stud_ClassId
        {
            get { return stud_ClassId; }
            set { stud_ClassId = value; }
        }

        public string Stud_Class
        {
            get { return stud_Class; }
            set { stud_Class = value; }
        }

        public int Stud_SectionId
        {
            get { return stud_SectionId; }
            set { stud_SectionId = value; }
        }

        public string Stud_Section
        {
            get { return stud_Section; }
            set { stud_Section = value; }
        }

        public string Stud_HouseName
        {
            get { return stud_HouseName; }
            set { stud_HouseName = value; }
        }

        public int Stud_HouseId
        {
            get { return stud_HouseId; }
            set { stud_HouseId = value; }
        }

        public string Stud_UserType
        {
            get { return stud_UserType; }
            set { stud_UserType = value; }
        }

        public string Stud_HouseCode
        {
            get { return stud_HouseCode; }
            set { stud_HouseCode = value; }
        }

        public string Stud_Photo
        {
            get { return stud_Photo; }
            set { stud_Photo = value; }
        }

        public string Stud_HouseDescription
        {
            get { return stud_HouseDescription; }
            set { stud_HouseDescription = value; }
        }
        public bool Stud_IsElectionActive
        {
            get { return stud_IsElectionActive; }
            set { stud_IsElectionActive = value; }
        }

        public string Stud_ElectionStatus
        {
            get { return stud_ElectionStatus; }
            set { stud_ElectionStatus = value; }
        }

        public string Stud_SenateDesignationDescription
        {
            get { return stud_SenateDesignationDescription; }
            set { stud_SenateDesignationDescription = value; }
        }
        public string Stud_SenateDesignation
        {
            get { return stud_SenateDesignation; }
            set { stud_SenateDesignation = value; }
        }

        public string Stud_HouseDesignationDescription
        {
            get { return stud_HouseDesignationDescription; }
            set { stud_HouseDesignationDescription = value; }
        }


        public int Stud_SenateId
        {
            get { return stud_SenateId; }
            set { stud_SenateId = value; }
        }

        public string Stud_HouseDesignation
        {
            get { return stud_HouseDesignation; }
            set { stud_HouseDesignation = value; }
        }

        public int Stud_HouseDesignationId
        {
            get { return stud_HouseDesignationId; }
            set { stud_HouseDesignationId = value; }
        }

        public string Stud_HouseDesignationCode
        {
            get { return stud_HouseDesignationCode; }
            set { stud_HouseDesignationCode = value; }
        }

        public string Stud_SenateDesignationCode
        {
            get { return stud_SenateDesignationCode; }
            set { stud_SenateDesignationCode = value; }
        }

        public void Dispose()
        {
            //this.Dispose();
        }
    }
}
