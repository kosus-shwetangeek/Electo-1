using ElectoSystem.Common;
using ElectoSystem.Entities;
using ElectoSystem.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace ElectoSystem.Admin
{
    public partial class HouseDesignation : System.Web.UI.Page
    {
        public string JHouseData
        {
            get
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    return  JsonConvert.SerializeObject(lData.GetHouseDropDown());
                }
            }
        }

        public string JsonData
        {
            get
            {
                List<StudentEntity> studentEntityList = new List<StudentEntity>();
                UIHelper studentHelper = new UIHelper();

                studentEntityList = studentHelper.GetAllHousesDesignationHelp();
                string houseDesignation = JsonConvert.SerializeObject(studentEntityList);

                return houseDesignation;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string DeleteHouseDesignation(string housedesignatioid, string housedesignation)
        {
            UIHelper studentHelper = new UIHelper();
            if (studentHelper.AddUpdateDelHouseDesignationHelp(Convert.ToInt32(housedesignatioid), 0, "", "", "", 0, "D", 1))
            {
                return "1";
                //return "House designation " + housedesignation + " has been deleted successfully";
            }
            else
            {
                //return "House designation is not deleted";
                return "0";
            }
        }

        [WebMethod]
        public static string AddHouseDesignation(string houseid, string housedesignation, string housedesignationdescription, string genderid)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(housedesignation))
            {
                string houseCode = "";
                string[] arry = housedesignation.Split(' ');
                for (int i = 0; i < arry.Count(); i++)
                {
                    houseCode = houseCode + arry[i].Substring(0, 1).ToUpper();
                }

                if (studentHelper.AddUpdateDelHouseDesignationHelp(0, Convert.ToInt32(houseid), housedesignation, housedesignationdescription, houseCode, Convert.ToInt32(genderid), "A", 1))
                {
                    return "1";
                    //return "House designation " + housedesignation + " has been added successfully";
                }
                else
                {
                    return "0";
                    //return "House designation is not added";
                }
            }
            else
            {
                //return "Please insert house designation";
                return "101";
            }
        }

        [WebMethod]
        public static string UpdateHouseDesignation(string housedesignatioid, string houseid, string housedesignation, string housedesignationdescription, string genderid)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(housedesignation))
            {
                string houseCode = "";
                string[] arry = housedesignation.Split(' ');
                for (int i = 0; i < arry.Count(); i++)
                {
                    houseCode = houseCode + arry[i].Substring(0, 1).ToUpper();
                }

                if (studentHelper.AddUpdateDelHouseDesignationHelp(Convert.ToInt32(housedesignatioid), Convert.ToInt32(houseid), housedesignation, housedesignationdescription, houseCode, Convert.ToInt32(genderid), "E", 1))
                {
                    //return "House designation has been updated successfully";
                    return "1";
                }
                else
                {
                    //return "House designation is not updated";
                    return "0";
                }
            }
            else
            {
                //return "Please insert house designation";
                return "101";
            }
        }
    }
}