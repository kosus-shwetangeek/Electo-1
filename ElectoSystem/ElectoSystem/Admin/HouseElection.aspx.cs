using ElectoSystem.Entities;
using ElectoSystem.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectoSystem.Admin
{
    public partial class HouseElection : System.Web.UI.Page
    {

        public string JsonData
        {
            get
            {
                List<ElectionsEntity> toEncode = new List<ElectionsEntity>();
                UIHelper studentHelper = new UIHelper();

                toEncode = studentHelper.GetAllHouseElectionsHelp();

                DateTime lCurrentTimeStamp = DateTime.Now;

                foreach (ElectionsEntity election in toEncode)
                {
                    if (election.EndDate < lCurrentTimeStamp)
                        election.Status = "Closed";
                    else if (election.StartDate <= lCurrentTimeStamp && lCurrentTimeStamp <= election.EndDate)
                        election.Status = "Active";
                    else if (election.StartDate > lCurrentTimeStamp)
                        election.Status = "Scheduled";
                }

                string test = JsonConvert.SerializeObject(toEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });

                return test;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string DeleteItem(string id)
        {
            UIHelper studentHelper = new UIHelper();
            if (studentHelper.AddUpdateDeleteHouseElectionHelp(Convert.ToInt32(id), DateTime.MinValue, DateTime.MinValue, "", "D"))
            {
                return "1";
                //return "Election has been deleted successfully";
            }
            else
            {
                return "0";
                //return "Election is not deleted";
            }
        }

        [System.Web.Services.WebMethod]
        public static string AddItem(string startdate, string enddate, string description)
        {
            UIHelper studentHelper = new UIHelper();
            if (studentHelper.AddUpdateDeleteHouseElectionHelp(0, Convert.ToDateTime(startdate), Convert.ToDateTime(enddate), description, "A"))
            {
                return "1";
                //return "Election has been added successfully";
            }
            else
            {
                return "0";
                //return "Election is not added";
            }
        }

        [System.Web.Services.WebMethod]
        public static string UpdateItem(string id, string enddate)
        {
            UIHelper studentHelper = new UIHelper();

            if (studentHelper.AddUpdateDeleteHouseElectionHelp(Convert.ToInt32(id), DateTime.MinValue, Convert.ToDateTime(enddate), "", "E"))
            {
                return "1";
                //return "Election has been updated successfully";
            }
            else
            {
                return "0";
                //return "Election is not updated";
            }
        }
    }
}