using ElectoSystem.Entities;
using ElectoSystem.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectoSystem.Common;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ElectoSystem.Admin
{
    public partial class StudentMaster : System.Web.UI.Page
    {
        votinglivedbEntities dbEntityF = new votinglivedbEntities();

        public string JClassSectionData
        {
            get
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    string test = JsonConvert.SerializeObject(lData.GetClassSectionDropDown());

                    return test;
                }
            }
        }

        public string JHouseData
        {
            get
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    string test = JsonConvert.SerializeObject(lData.GetHouseDropDown());

                    return test;
                }
            }
        }

        public string JsonData
        {
            get
            {
                List<StudentEntity> toEncode = new List<StudentEntity>();
                UIHelper studentHelper = new UIHelper();

                toEncode = studentHelper.GetAllStudentHelp();
                string test2 = JsonConvert.SerializeObject(toEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });
                string test = JsonConvert.SerializeObject(toEncode);

                return test2;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string DeleteStudent(string id)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(id))
            {
                //=======================================================
                // Now we need to create student DTO to with data we have
                //=======================================================
                StudentEntity lStudent = new StudentEntity();

                lStudent.Stud_Key = id;

                if (studentHelper.AddUpdateDeleteStudent(lStudent, "D"))
                {
                    return "1";
                    //return "Student has been deleted successfully";
                }
                else
                {
                    return "0";
                    //return "Student has not deleted. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot delete student. Please try later.";
            }
        }

        [WebMethod]
        public static string UpdateStudent(string xiKey, string xiFName, string xiMName, string xiLName, int xiGenderId, int xiClassSectionId, int xiHouseId, string xiPasswod, string xiDoB)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(xiKey))
            {
                //=======================================================
                // Now we need to create student DTO to with data we have
                //=======================================================
                StudentEntity lStudent = new StudentEntity();

                lStudent.Stud_Key = xiKey;
                lStudent.Stud_FName = xiFName;
                lStudent.Stud_MName = xiMName;
                lStudent.Stud_LName = xiLName;
                lStudent.Stud_GenderId = xiGenderId;
                lStudent.Stud_ClassSectionId = xiClassSectionId;
                lStudent.Stud_HouseId = xiHouseId;
                lStudent.Stud_Password = xiPasswod;
                lStudent.Stud_DoB = Convert.ToDateTime(xiDoB);

                if (studentHelper.AddUpdateDeleteStudent(lStudent, "E"))
                {
                    return "1";
                    //return "Student has been Updated successfully";
                }
                else
                {
                    return "0";
                    //return "Student has not Updated. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot Update student. Please try later.";
            }
        }

        [WebMethod]
        public static string AddStudent(string xiFName, string xiMName, string xiLName, int xiGenderId, int xiClassSectionId, int xiHouseId, string xiPasswod, string xiDoB)
        {
            UIHelper studentHelper = new UIHelper();
            //=======================================================
            // Now we need to create student DTO to with data we have
            //=======================================================
            StudentEntity lStudent = new StudentEntity();

            lStudent.Stud_FName = xiFName;
            lStudent.Stud_MName = xiMName;
            lStudent.Stud_LName = xiLName;
            lStudent.Stud_GenderId = xiGenderId;
            lStudent.Stud_ClassSectionId = xiClassSectionId;
            lStudent.Stud_HouseId = xiHouseId;
            lStudent.Stud_Password = xiPasswod;
            lStudent.Stud_DoB = Convert.ToDateTime(xiDoB);

            if (studentHelper.AddUpdateDeleteStudent(lStudent, "A"))
            {
                return "1";
                //return "Student has been added successfully.";
            }
            else
            {
                return "0";
                //return "Student has not added. Please try later.";
            }
        }
    }
}