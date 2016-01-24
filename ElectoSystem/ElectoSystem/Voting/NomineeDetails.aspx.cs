using ElectoSystem.Entities;
using ElectoSystem.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectoSystem.Voting
{
    public partial class NomineeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        NomineesEntity nominee;

        public NomineesEntity Nominee
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["electtype"]))
                {
                    NomineesEntity nominee = new NomineesEntity();
                    UIHelper lHelp = new UIHelper();
                    if (Request.QueryString["electtype"].ToString().ToLower() == "s")
                    {
                        return lHelp.GetSenateNomineeByStudKeyHelp(Request.QueryString["id"].ToString().ToLower());
                    }
                    else if (Request.QueryString["electtype"].ToString().ToLower() == "h")
                    {
                        return lHelp.GetHouseNominationsByIdHelp(Convert.ToInt32(Request.QueryString["houseid"]))
                                                                                      .Where(x => x.Nom_Key.ToLower() == Request.QueryString["id"].ToString().ToLower())
                                                                                      .FirstOrDefault();
                        //return lHelp.GetHouseNominationsByIdHelp(Request.QueryString["id"].ToString().ToLower());
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}