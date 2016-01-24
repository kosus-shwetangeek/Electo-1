using ElectoSystem.Common;
using ElectoSystem.Entities;
using ElectoSystem.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectoSystem.UserControl
{
    public partial class UCSenateElection : System.Web.UI.UserControl
    {
        #region Data Structures & Member Variables
        List<NomineesEntity> allSenateList;
        public static string studId;

        public List<NomineesEntity> AllSenateList
        {
            get { return allSenateList; }
            set { allSenateList = value; }
        }

        List<Designation> allDesignation;

        public List<Designation> AllDesignation
        {
            get { return allDesignation; }
            set { allDesignation = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            UICommon uICommon = new UICommon();
            UIHelper studentHelper = new UIHelper();
            AllSenateList = new List<NomineesEntity>();
            AllSenateList = uICommon.FillNominationDetails(0, "s");

            AllDesignation = AllSenateList.Select(d => new Designation
            {
                DesignationId = d.Nom_DesignationId,
                DesignationCode = d.Nom_DesignationCode,
                DesignationText = d.Nom_DesignationKey
            }).ToList().GroupBy(x => x.DesignationId).Select(x => x.First()).ToList<Designation>();

            studId = ((StudentEntity)Session["LoggedInUser"]).Stud_Key;
        }

        [System.Web.Services.WebMethod]
        public static string UpdateVotes(string xiNominees)
        {
            UIHelper studentHelper = new UIHelper();
            string columnName = string.Empty;

            if (studentHelper.UpdateCandidateVoteHelp(studId, xiNominees, "s", columnName))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public bool IsVoted
        {
            get
            {
                UIHelper studentHelper = new UIHelper();
                //Get status of is student is voted or not.
                return studentHelper.GetVotetedStudentsStatusHelp(studId).Vst_IVFSenate;
            }
        }
    }
}