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
    public partial class SenateNomination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    DrpD_Designation.DataSource = lData.GetSenateDesignationDropDown();
                    DrpD_Designation.DataValueField = "Key";
                    DrpD_Designation.DataTextField = "Value";
                    DrpD_Designation.DataBind();

                    DrpD_Election.DataSource = lData.GetSenateElectionDropDown();
                    DrpD_Election.DataValueField = "Key";
                    DrpD_Election.DataTextField = "Value";
                    DrpD_Election.DataBind();
                }

                //==========================================================================
                // Bind grid with student information for nominee selection process.
                // Remember we are getting student by their house refer to selected dropdown
                //==========================================================================
                List<StudentEntity> toEncode = new List<StudentEntity>();
                UIHelper studentHelper = new UIHelper();
                List<NomineesEntity> toNomineeEncode = new List<NomineesEntity>();
                
                toNomineeEncode = studentHelper.GetAllSenateNomineesHelp(false);

                toEncode = studentHelper.GetAllStudentHelp().Where(x => !toNomineeEncode.Any(y => y.Nom_Key == x.Stud_Key)).ToList();

                StudentData = JsonConvert.SerializeObject(toEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });

                Nominees = JsonConvert.SerializeObject(toNomineeEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });
            }

        }

        #region UDF
        [WebMethod]
        public static string AddNominee(string xiClassSectionId, string xiStudKey, string xiDesignationDrp, string xiElectionDrp)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(xiStudKey))
            {
                if (studentHelper.AddDeleteSenateNominee(0, Convert.ToInt32(xiDesignationDrp), Convert.ToInt32(xiClassSectionId), xiStudKey, string.Empty, Convert.ToInt32(xiElectionDrp), string.Empty, "A", 1))
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
                if (studentHelper.AddDeleteSenateNominee(Convert.ToInt32(xiNomId),0,0,"","",0,"","D",1))
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

        public static string UpdateNominee(string xiNomId, string xiAboutNom)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(xiNomId))
            {
                if (studentHelper.AddDeleteSenateNominee(Convert.ToInt32(xiNomId), 0, 0, "", "", 0, xiAboutNom, "E", 1))
                {
                    return "1";
                    //return "Nominee has been updated successfully";
                }
                else
                {
                    return "0";
                    //return "Nominee has not updated. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot update nominee. Please try later.";
            }
        }
        #endregion

        #region Member Accessor
        string mStudentData;
        string mNominees;
        string mDesignation;
        string mElections;

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

        public string JSenateDesignationData
        {
            get
            {
                using (DropDownCommon lData = new DropDownCommon())
                {
                    string test = JsonConvert.SerializeObject(lData.GetSenateDesignationDropDown());

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
                    string test = JsonConvert.SerializeObject(lData.GetSenateElectionDropDown());

                    return test;
                }
            }
        }
        #endregion
    }
}