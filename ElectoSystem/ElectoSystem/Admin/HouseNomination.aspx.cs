using ElectoSystem.Common;
using ElectoSystem.Entities;
using ElectoSystem.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectoSystem.Admin
{
    public partial class HouseNomination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    DrpD_Houses.DataSource = lData.GetHouseDropDown();
                    DrpD_Houses.DataValueField = "Key";
                    DrpD_Houses.DataTextField = "Value";
                    DrpD_Houses.DataBind();

                    DrpD_Election.DataSource = lData.GetHouseElectionDropDown();
                    DrpD_Election.DataValueField = "Key";
                    DrpD_Election.DataTextField = "Value";
                    DrpD_Election.DataBind();
                }

                DrpD_Designation.Enabled = false;
                StudentData = string.Empty;
                Nominees = string.Empty;
                JDesignation = string.Empty;
            }
        }

        protected void DrpD_Houses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //=====================================================================
            // Bind dropdown for Designation according to House selected by user.
            //=====================================================================
            int lSelectedHouse = Convert.ToInt32(DrpD_Houses.SelectedValue);

            if (lSelectedHouse > 0)
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    DrpD_Designation.DataSource = lData.GetHouseDesignationDropDown(lSelectedHouse);
                    DrpD_Designation.DataValueField = "Key";
                    DrpD_Designation.DataTextField = "Value";
                    DrpD_Designation.DataBind();

                    JDesignation = JsonConvert.SerializeObject(lData.GetHouseDesignationDropDown(lSelectedHouse), Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });
                }

                if (DrpD_Designation.Items.Count > 0)
                {
                    DrpD_Designation.Enabled = true;
                }


                //==========================================================================
                // Bind grid with student information for nominee selection process.
                // Remember we are getting student by their house refer to selected dropdown
                //==========================================================================
                List<StudentEntity> toEncode = new List<StudentEntity>();
                UIHelper studentHelper = new UIHelper();
                List<NomineesEntity> toNomineeEncode = new List<NomineesEntity>();

                
                toNomineeEncode = studentHelper.GetHouseNominationsByIdHelp(lSelectedHouse);

                toEncode = studentHelper.GetAllStudentHelp()
                                        .Where(x => x.Stud_HouseId == lSelectedHouse).ToList()
                                        .Where(y => !toNomineeEncode.Any(z => z.Nom_Key == y.Stud_Key)).ToList();
                
                StudentData = JsonConvert.SerializeObject(toEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });

                Nominees = JsonConvert.SerializeObject(toNomineeEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });
            }
            else
            {
                StudentData = string.Empty;
                Nominees = string.Empty;
                JDesignation = string.Empty;
                DrpD_Designation.DataSource = null;
                DrpD_Designation.Enabled = false;
            }
        }

        protected void DrpD_Designation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region UDF
        [WebMethod]
        public static string AddNominee(string xiClassSectionId, string xiStudKey, string xiHouseDrp, string xiDesignationDrp, string xiElectionDrp)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(xiStudKey))
            {
                if (studentHelper.AddDeleteHouseNominee(0, Convert.ToInt32(xiHouseDrp), Convert.ToInt32(xiDesignationDrp), Convert.ToInt32(xiClassSectionId), xiStudKey, string.Empty, Convert.ToInt32(xiElectionDrp), "A", 1))
                {
                    return "1";
                    //return "Nominee " + xiStudKey + " has been added successfully";
                }
                else
                {
                    return "0";
                    //return "Nominee " + xiStudKey + " has not added. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot add nominee " + xiStudKey + " . Please try later.";
            }
        }

        [WebMethod]
        public static string DeleteNominee(string xiNomId)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(xiNomId))
            {
                if (studentHelper.AddDeleteHouseNominee(Convert.ToInt32(xiNomId), 0, 0, 0, string.Empty, string.Empty, 0,"D", 1))
                {
                    return "1";
                    //return "Nominee has been deleted successfully";
                }
                else
                {
                    return "0";
                    //return "Nominee has not deleted. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot delete nominee. Please try later.";
            }
        }
        #endregion

        #region Member Accessor
        string mStudentData;
        string mNominees;
        string mDesignation;

        public string StudentData
        {
            get { return mStudentData; }
            set { mStudentData = value; }
        }

        public string Nominees
        {
            get { return mNominees; }
            set { mNominees = value; }
        }

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

        public string JDesignation
        {
            get { return mDesignation; }
            set { mDesignation = value; }
        }

        public string JElectionsData
        {
            get
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    string test = JsonConvert.SerializeObject(lData.GetHouseElectionDropDown());

                    return test;
                }
            }
        }
        #endregion
    }
}