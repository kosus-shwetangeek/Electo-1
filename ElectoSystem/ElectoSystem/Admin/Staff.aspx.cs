using System;
using System.Collections.Generic;
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
    public partial class Staff1 : System.Web.UI.Page
    {
        votinglivedbEntities dbEntityF = new votinglivedbEntities();
       /* public string JsonData
        {
            get
            {
                List<StaffEntity> toEncode = new List<StudentEntity>();
                UIHelper staffHelper = new UIHelper();

                toEncode = staffHelper.GetAllStaffHelp();
                string test2 = JsonConvert.SerializeObject(toEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });
                string test = JsonConvert.SerializeObject(toEncode);

                return test2;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string DeleteStaff(string Userid)
        {
            UIHelper StaffHelper = new UIHelper();
            if (!string.IsNullOrEmpty(id))
            {
                //=======================================================
                // Now we need to create student DTO to with data we have
                //=======================================================
                StaffEntity lStaff = new StaffEntity();

                lStaff.stf_UserId = id;

                if (staffHelper.AddUpdateDeleteStaff(lStaff, "D"))
                {
                    return "1";
                    //return "Staff has been deleted successfully";
                }
                else
                {
                    return "0";
                    //return "Staff has not deleted. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot delete staff. Please try later.";
            }
        }

        [WebMethod]
        public static string UpdateStaff(string xiUserId, string xiFirstName, string xiMiddleName, string xiLastName, string xiDoB, string xiEmailId, Int xiContactNo, int xiGenderId, int xiAddressId, String xiIsCandidate, int xiRoleId, string xiPasswod, DateTime xiCreadtedDate)
        {
            UIHelper staffHelper = new UIHelper();
            if (!string.IsNullOrEmpty(xiUserId))
            {
                //=======================================================
                // Now we need to create student DTO to with data we have
                //=======================================================
                StaffEntity lStaff = new staffEntity();

                lStaff.stf_UserId = xiUserId;
                lStaff.stf_FirstName = xiFirstName;
                lStaff.stf_MiddleName = xiMiddleName;
                lStaff.stf_LastName = xiLastName;
                lStaff.stf_xiDOB = Convert.ToDateTime(xiDoB);
                lStaff.stf_EmailId = xiEmailId;
                lStaff.stf_ = xiContactNo;
                lStaff.stf_GenderId = xiGenderId;
                lStaff.stf_AddressId = xiAddressId;
                lStaff.stf_IsCandidate = xiIsCandidate;
                lStaff.stf_Password = xiPasswod;
                lStaff.stf_CreatedDate = Convert.ToDateTime(xiCreatedDate);

                if (staffHelper.AddUpdateDeleteStaff(lStaff, "E"))
                {
                    return "1";
                    //return "Staff has been Updated successfully";
                }
                else
                {
                    return "0";
                    //return "Staff has not Updated. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot Update staff. Please try later.";
            }
        }

        [WebMethod]
        public static string AddStaff(string xiUserId, string xiFirstName, string xiMiddleName, string xiLastName, string xiDoB, string xiEmailId, Int xiContactNo, int xiGenderId, int xiAddressId, String xiIsCandidate, int xiRoleId, string xiPasswod, DateTime xiCreadtedDate)
        {
            UIHelper staffHelper = new UIHelper();
            //=======================================================
            // Now we need to create student DTO to with data we have
            //=======================================================
            StaffEntity lStaff = new StaffEntity();
            lStaff.stf_UserId = xiUserId;
            lStaff.stf_FirstName = xiFirstName;
            lStaff.stf_MiddleName = xiMiddleName;
            lStaff.stf_LastName = xiLastName;
            lStaff.stf_xiDOB = Convert.ToDateTime(xiDoB);
            lStaff.stf_EmailId = xiEmailId;
            lStaff.stf_ = xiContactNo;
            lStaff.stf_GenderId = xiGenderId;
            lStaff.stf_AddressId = xiAddressId;
            lStaff.stf_IsCandidate = xiIsCandidate;
            lStaff.stf_Password = xiPasswod;
            lStaff.stf_CreatedDate = Convert.ToDateTime(xiCreatedDate);


            if (staffHelper.AddUpdateDeleteStaff(lStaff, "A"))
            {
                return "1";
                //return "Staff has been added successfully.";
            }
            else
            {
                return "0";
                //return "Staff  has not added. Please try later.";
            }
        }*/
    }
}