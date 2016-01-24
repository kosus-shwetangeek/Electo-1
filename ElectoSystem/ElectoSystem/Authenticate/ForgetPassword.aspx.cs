using ElectoSystem.Entities;
using ElectoSystem.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectoSystem.Reports
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UIHelper studHelp = new UIHelper();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            bool isPasswordUpdate;
            UIHelper studHelp = new UIHelper();

            isPasswordUpdate = studHelp.UpdateResetPasswordHelp(txt_CandidateId.Text, txt_Password.Text, Convert.ToDateTime(txt_DOB.Text));

            if (isPasswordUpdate)
            {
                //Success Message
            }
            else
            { 
                //error Message
            }
        }
    }
}