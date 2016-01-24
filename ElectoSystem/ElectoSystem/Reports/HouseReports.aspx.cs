using ElectoSystem.Common;
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

namespace ElectoSystem.Reports
{
    public partial class HouseReports : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    Drp_House.DataSource = lData.GetHouseDropDown();
                    Drp_House.DataValueField = "Key";
                    Drp_House.DataTextField = "Value";
                    Drp_House.DataBind();

                    Drp_Election.Enabled = false;
                }
            }
        }

        protected void Drp_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Drp_House.SelectedValue) > 0)
            {

                StudHouseName = Drp_House.SelectedItem.Text;
                StudHouseId = Convert.ToInt32(Drp_House.SelectedItem.Value);

                using (DropDownCommon lData = new DropDownCommon())
                {
                    Drp_Election.DataSource = lData.GetHouseElectionDropDown();
                    Drp_Election.DataValueField = "Key";
                    Drp_Election.DataTextField = "Value";
                    Drp_Election.DataBind();

                    Drp_Election.SelectedValue = Drp_Election.Items.FindByValue("0").Value;

                    Drp_Election.Enabled = true;
                }
            }
            else
            {
                Drp_Election.SelectedValue = Drp_Election.Items.FindByValue("0").Value;
                Drp_Election.Enabled = false;
            }
        }

        protected void Drp_Election_SelectedIndexChanged(object sender, EventArgs e)
        {
            //==========================================================================
            // Bind grid with student information for nominee selection process.
            // Remember we are getting student by their house refer to selected dropdown
            //==========================================================================
            if (Convert.ToInt32(Drp_Election.SelectedValue) > 0)
            {
                ToNominee = GetHouseNominee(Convert.ToInt32(Drp_House.SelectedValue), Convert.ToInt32(Drp_Election.SelectedValue));

                ToDesignation = GetHouseDesignation(Convert.ToInt32(Drp_House.SelectedValue));

                ReportElectionId = Convert.ToInt32(Drp_Election.SelectedItem.Value);
                ReportElectionName = Drp_Election.SelectedItem.Text;

                StudHouseId = Convert.ToInt32(Drp_House.SelectedItem.Value);
                StudHouseName = Drp_House.SelectedItem.Text;
            }
            else
            {
                ToNominee = null;
                ToDesignation = null;

                ReportElectionName = null;
                ReportElectionId = 0;
            }
        }

        #region Global Member Veriable & Member Functions
        private string mNominees;
        private string mDesignations;

        public UIHelper studentHelper;

        List<NomineesEntity> allNomineesList;
        private int studHouseId;

        public int StudHouseId
        {
            get { return studHouseId; }
            set { studHouseId = value; }
        }

        private string studHouseName;

        public string StudHouseName
        {
            get { return studHouseName; }
            set { studHouseName = value; }
        }

        private int reportElectionId;

        public int ReportElectionId
        {
            get { return reportElectionId; }
            set { reportElectionId = value; }
        }
        private string reportElectionName;

        public string ReportElectionName
        {
            get { return reportElectionName; }
            set { reportElectionName = value; }
        }
        
        List<NomineesEntity> toNominee;

        public List<NomineesEntity> ToNominee
        {
            get { return toNominee; }
            set { toNominee = value; }
        }
        
        private List<DropDownDataSource> toDesignation;

        public List<DropDownDataSource> ToDesignation
        {
            get { return toDesignation; }
            set { toDesignation = value; }
        }

        public List<NomineesEntity> GetHouseNominee(int xiHouseId, int xiElectionId)
        {
            if(Drp_House.SelectedValue != "0" && Drp_Election.SelectedValue != "0")
            {
                studentHelper = new UIHelper();
                List<NomineesEntity> lNominees  = studentHelper.GetHouseNominationsByIdHelp(xiHouseId).Where(x => x.Nom_ElectionId == xiElectionId).OrderByDescending(x => x.Nom_VoteCount).ToList();

                if(lNominees != null &&
                    lNominees.Count > 0)
                {
                    return lNominees;
                }
            }

            return null;
        }

        public List<DropDownDataSource> GetHouseDesignation(int xiHouseId)
        {
            if (Drp_House.SelectedValue != "0")
            {
                DropDownCommon lDropCommon = new DropDownCommon();
                List<DropDownDataSource> lLstRet = lDropCommon.GetHouseDesignationDropDown(xiHouseId);

                if (lLstRet != null && lLstRet.Count > 0)
                {
                    return lLstRet;
                }
            }
            return null;
        }

        public Dictionary<int, string> ColorCode 
        {
            get 
            {
                Dictionary<int, string> lColorDict = new Dictionary<int, string>();

                lColorDict.Add(0, "#FF6600");
                lColorDict.Add(1, "#3399FF");
                lColorDict.Add(2, "#00CC99");
                lColorDict.Add(3, "#FFCC00");
                lColorDict.Add(4, "#B28F00");
                lColorDict.Add(5, "#CC00CC");
                lColorDict.Add(6, "#FF9966");
                lColorDict.Add(7, "");
                lColorDict.Add(8, "");
                lColorDict.Add(9, "");
                lColorDict.Add(10, "");

                return lColorDict;
            }
        }

        #endregion
    }
}