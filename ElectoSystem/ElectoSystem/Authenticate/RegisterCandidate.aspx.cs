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

namespace ElectoSystem.Authenticate
{
    public partial class RegisterCandidate : System.Web.UI.Page
    {
        //=====================================================
        // Get all students data for Autocomplete textbox.
        //=====================================================
        public string JsonData
        {
            get
            {
                List<StudentEntity> toEncode = new List<StudentEntity>();
                UIHelper studentHelper = new UIHelper();

                toEncode = studentHelper.GetAllStudentHelp();
                string str =  JsonConvert.SerializeObject(toEncode, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy" });
                str.Replace("Stud_Key", "label");
                return str;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            bool isPasswordUpdate;
            UIHelper studHelp = new UIHelper();

            isPasswordUpdate = studHelp.UpdateResetPasswordHelp(Txt_CandidateId.Text, txt_Password.Text, Convert.ToDateTime(txt_DOB.Text));

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