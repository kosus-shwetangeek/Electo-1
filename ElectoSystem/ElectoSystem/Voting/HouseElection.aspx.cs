using ElectoSystem.Common;
using ElectoSystem.Entities;
using ElectoSystem.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ElectoSystem.Voting
{
    public partial class HouseElection : System.Web.UI.Page
    {
        #region Data Structures & Member Variables
        List<NomineesEntity> allNomineesList;
        public int studHouseId;
        public static string studId;

        public List<NomineesEntity> AllNomineesList
        {
            get { return allNomineesList; }
            set { allNomineesList = value; }
        }
        List<Designation> allDesignation;

        public List<Designation> AllDesignation
        {
            get { return allDesignation; }
            set { allDesignation = value; }
        }
        VotedStudentsEntity votetedStatus;

        public VotedStudentsEntity VotetedStatus
        {
            get { return votetedStatus; }
            set { votetedStatus = value; }
        }

        public bool IsVoted
        {
            get 
            {
                UIHelper studentHelper = new UIHelper();
                //Get status of is student is voted or not.
                return studentHelper.GetVotetedStudentsStatusHelp(studId).Vst_IVFHouse;
            }
        }

        public List<NomineesEntity> JuniorPrefectList
        {
            get
            {
                if (allNomineesList != null && allNomineesList.Count > 0)
                {
                    return allNomineesList.Where(x => x.Nom_DesignationCode.ToUpper() == "JP").ToList();
                }
                else
                {
                    return null;
                }
            }
        }
        // Label Lbl_houseName = new Label();
        public string HouseName { get; set; }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            UICommon uICommon = new UICommon();
            UIHelper studentHelper = new UIHelper();

            //Check whether student login successfully & has user information                                                                                       
            if (Session["LoggedInUser"] != null)
            {
                //Get house name for dynamic house name.
                HouseName = ((StudentEntity)Session["LoggedInUser"]).Stud_HouseName.ToString().Trim();

                //Get student house code for differentiating house.
                string studHouseCode = ((StudentEntity)Session["LoggedInUser"]).Stud_HouseCode.ToString().Trim();
                studHouseId = ((StudentEntity)Session["LoggedInUser"]).Stud_HouseId;

                //Get nomination detail by student house Id.
                AllNomineesList = uICommon.FillNominationDetails(studHouseId, "h");

                //Get all designation by house id.
                //AllDesignation = new List<Designation>();
                //List<StudentEntity> allDesignationtemp = new List<StudentEntity>();
                //allDesignationtemp = studentHelper.GetAllHousesDesignationHelp().Where(h => h.Stud_HouseId == studHouseId).ToList();

                // List<Designation>  allDesignationtemp = new List<Designation>();
                AllDesignation = AllNomineesList.Select(d => new Designation
                {
                    DesignationId = d.Nom_DesignationId,
                    DesignationCode = d.Nom_DesignationCode,
                    DesignationText = d.Nom_DesignationKey
                }).ToList().GroupBy(x => x.DesignationId).Select(x => x.First()).ToList<Designation>();
                //AllDesignation = allDesignationtemp.Distinct().ToList();

                // Get student Id to check is voted or not.
                studId = ((StudentEntity)Session["LoggedInUser"]).Stud_Key;

                ////Get status of is student is voted or not.
                //VotetedStatus = studentHelper.GetVotetedStudentsStatusHelp(studId);



                Page.DataBind();
            }
            else
                Response.Redirect("~/Authenticate/Login.aspx");
        }

        [System.Web.Services.WebMethod]
        public static string UpdateVotes(string xiNominees)
        {
            UIHelper studentHelper = new UIHelper();
            string columnName = string.Empty;

            if (studentHelper.UpdateCandidateVoteHelp(studId,xiNominees,"h", columnName))
            {
                return "1";
            }
            else
            {
                return "0";
            }               
        }
    }
}