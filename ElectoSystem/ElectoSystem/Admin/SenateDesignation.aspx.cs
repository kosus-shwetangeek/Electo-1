using ElectoSystem.Entities;
using ElectoSystem.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectoSystem.Admin
{
    public partial class SenateDesignation : System.Web.UI.Page
    {
        private string jsonData;
        public string JsonData
        {
            get
            {
                List<StudentEntity> studentEntityList = new List<StudentEntity>();
                UIHelper studentHelper = new UIHelper();

                studentEntityList = studentHelper.GetAllSenateDesignationHelp();
                string houseDesignation = JsonConvert.SerializeObject(studentEntityList);

                return houseDesignation;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string DeleteSenateDesignation(string senatedesignatioid)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            UIHelper studentHelper = new UIHelper();
            if (studentHelper.AddUpdateDelSenateDesignationHelp(Convert.ToInt32(senatedesignatioid), "", "", "", 0, "D", 1))
            {
                return "1";
                //return "Senate designation has been deleted successfully";
            }
            else
            {
                return "0";
                //return "Senate designation is not deleted";
            }
        }

        [WebMethod]
        public static string AddSenateDesignation(string senatedesignation, string senatedesignationdescription, string genderid)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(senatedesignation))
            {
                string senateDesignationCode = "";
                string[] arry = senatedesignation.Split(' ');
                for (int i = 0; i < arry.Count(); i++)
                {
                    senateDesignationCode = senateDesignationCode + arry[i].Substring(0, 1).ToUpper();
                }

                if (studentHelper.AddUpdateDelSenateDesignationHelp(0, senatedesignation, senatedesignationdescription, senateDesignationCode, Convert.ToInt32(genderid), "A", 1))
                {
                    return "1";
                    //return "Senate designation has been added successfully";
                }
                else
                {
                    return "0";
                    //return "Senate designation is not added";
                }
            }
            else
            {
                return "10";
                //return "Please insert senate designation";
            }
        }

        [WebMethod]
        public static string UpdateSenateDesignation(string senatedesignatioid, string senatedesignation, string senatedesignationdescription, string genderid)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(senatedesignation))
            {
                string senateDesignationCode = "";
                string[] arry = senatedesignation.Split(' ');
                for (int i = 0; i < arry.Count(); i++)
                {
                    senateDesignationCode = senateDesignationCode + arry[i].Substring(0, 1).ToUpper();
                }

                if (studentHelper.AddUpdateDelSenateDesignationHelp(Convert.ToInt32(senatedesignatioid), senatedesignation, senatedesignationdescription, senateDesignationCode, Convert.ToInt32(genderid), "E", 1))
                {
                    return "1";
                    //return "Senate designation has been updated successfully";
                }
                else
                {
                    return "0";
                    //return "Senate designation is not updated";
                }
            }
            else
            {
                return "10";
                //return "Please insert senate designation";
            }
        }
    }
}