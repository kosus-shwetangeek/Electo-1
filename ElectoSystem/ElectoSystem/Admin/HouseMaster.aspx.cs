using ElectoSystem.Entities;
using ElectoSystem.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectoSystem.Admin
{
    public partial class HouseMaster : System.Web.UI.Page
    {
        private string jsonData;
        public string JsonData
        {
            get
            {
                List<StudentEntity> toEncode = new List<StudentEntity>();
                UIHelper studentHelper = new UIHelper();

                toEncode = studentHelper.GetAllHouseHelp();
                string test = JsonConvert.SerializeObject(toEncode);

                return test;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string DeleteItem(string id)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            UIHelper studentHelper = new UIHelper();
            if (studentHelper.AddUpdateDelHouseHelp(Convert.ToInt32(id), "", "", "", "D", 1))
            {
                return "1";
                //return "House has been deleted successfully";
            }
            else
            {
                return "0";
                //return "House is not deleted";
            }
        }

        [System.Web.Services.WebMethod]
        public static string AddItem(string name, string desc)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                 !string.IsNullOrEmpty(desc.Trim()))
            {
                string houseCode = name.Substring(0, 1).ToUpper();

                if (studentHelper.AddUpdateDelHouseHelp(0, name, desc, houseCode + "H", "A", 1))
                {
                    return "1";
                    //return "House has been added successfully";
                }
                else
                {
                    return "0";
                    //return "House is not added";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }

        [System.Web.Services.WebMethod]
        public static string UpdateItem(string id, string name, string desc)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                !string.IsNullOrEmpty(desc.Trim()))
            {
                string houseCode = name.Substring(0, 1).ToUpper();

                if (studentHelper.AddUpdateDelHouseHelp(Convert.ToInt32(id), name, desc, "", "E", 1))
                {
                    return "1";
                    //return "House has been updated successfully";
                }
                else
                {
                    return "0";
                    //return "House is not updated";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }
    }
}