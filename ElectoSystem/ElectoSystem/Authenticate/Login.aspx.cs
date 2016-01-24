using ElectoSystem.Entities;
using ElectoSystem.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electo.Constants;

namespace ElectoSystem.Reports
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
                lblError.Text = string.Empty;
            }
        }

        protected void btn_LogIn_Click(object sender, EventArgs e)
        {
            UIHelper studentHelper = new UIHelper();
            try
            {
                if (username.Text.ToLower() == "admin" && password.Text.ToLower() == "admin@123")
                {
                    Response.Redirect("~/Admin/AdminWelcome.aspx", true);
                }
                else
                {
                    StudentEntity validateStudent = studentHelper.CheckStudentExistHelp(username.Text.ToString().ToLower(), password.Text.ToString().ToLower());

                    if (validateStudent != null)
                    {
                        StudentEntity student = studentHelper.GetUserSessionHelp(username.Text.ToString().ToLower(), validateStudent.Stud_UserType.ToString().ToLower());

                        if (student != null)
                        {
                            Session["LoggedInUser"] = student;
                            Response.Redirect("~/Voting/HouseElection.aspx", true);
                            //if (student.Stud_HouseCode.ToString().Trim() == "AH")
                            //    Response.Redirect("~/Voting/AHouseNominees.aspx");
                            //else if (student.Stud_HouseCode.ToString().Trim() == "VH")
                            //    Response.Redirect("~/Voting/VHouseNominees.aspx");
                            //else if (student.Stud_HouseCode.ToString().Trim() == "PH")
                            //    Response.Redirect("~/Voting/PHouseNominees.aspx");
                            //else if (student.Stud_HouseCode.ToString().Trim() == "SH")
                            //    Response.Redirect("~/Voting/SHouseNominees.aspx");
                        }
                    }
                }
                lblError.Visible = true;
                lblError.Text = "Incorrect Username or password. Please try again.";
            }
            catch (System.Threading.ThreadAbortException lException)
            {
                studentHelper.LogError(Convert.ToInt32(ENums.EWSSeverity.Error), lException.ToString());
            }
            catch (Exception EX)
            {
                studentHelper.LogError(Convert.ToInt32(ENums.EWSSeverity.Error), EX.ToString());
            }
        }
    }
}