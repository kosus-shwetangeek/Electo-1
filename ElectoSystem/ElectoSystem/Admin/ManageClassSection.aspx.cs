using Electo.DataLayer.Entities;
using ElectoSystem.Entities;
using ElectoSystem.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace ElectoSystem.Admin
{
    public partial class ManageClassSection : System.Web.UI.Page
    {
        votinglivedbEntities dbEntityF = new votinglivedbEntities();

        #region Class
        public string JsonClassData
        {
            get
            {
                List<ClassSectionEntity> toEncode = new List<ClassSectionEntity>();
                UIHelper studentHelper = new UIHelper();

                toEncode = studentHelper.GetAllClassesHelp();
                string test = JsonConvert.SerializeObject(toEncode);

                return test;
            }
        }

        [WebMethod]
        public static string DeleteClass(string id)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(id))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.ClassId = Convert.ToInt32(id);
                lClassSectionEntity.Action = "D";
                lClassSectionEntity.Type = "CL";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "class has been deleted successfully";
                }
                else
                {
                    return "0";
                    //return "Class has not deleted. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot delete class. Please try later.";
            }
        }

        [WebMethod]
        public static string UpdateClass(string id, string name, string desc)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                !string.IsNullOrEmpty(desc.Trim()))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.ClassId = Convert.ToInt32(id);
                lClassSectionEntity.ClassName = name;
                lClassSectionEntity.DisplayClassName = desc;
                lClassSectionEntity.Action = "E";
                lClassSectionEntity.Type = "CL";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "House has been updated successfully";
                }
                else
                {
                    return "0";
                    //return "House is not updated";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }

        [WebMethod]
        public static string AddClass(string name, string desc)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                 !string.IsNullOrEmpty(desc.Trim()))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.ClassId = Convert.ToInt32(0);
                lClassSectionEntity.ClassName = name;
                lClassSectionEntity.DisplayClassName = desc;
                //lClassSectionEntity.SectionId = 0;
                //lClassSectionEntity.SectionName = "";
                //lClassSectionEntity.DisplaySectionName = "";
                //lClassSectionEntity.ClassSectionId = 0;
                //lClassSectionEntity.ClassSectionName = "";
                //lClassSectionEntity.DisplayClassSectionName = "";
                lClassSectionEntity.Action = "A";
                lClassSectionEntity.Type = "CL";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "House has been added successfully";
                }
                else
                {
                    return "0";
                    //return "House is not added";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }
        #endregion Class

        #region Section
        public string JsonSectionData
        {
            get
            {
                List<ClassSectionEntity> toEncode = new List<ClassSectionEntity>();
                UIHelper studentHelper = new UIHelper();

                toEncode = studentHelper.GetAllSectionsHelp();
                string test = JsonConvert.SerializeObject(toEncode);

                return test;
            }
        }

        [WebMethod]
        public static string DeleteSection(string id)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(id))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.SectionId = Convert.ToInt32(id);
                lClassSectionEntity.Action = "D";
                lClassSectionEntity.Type = "S";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "class has been deleted successfully";
                }
                else
                {
                    return "0";
                    //return "Class has not deleted. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot delete class. Please try later.";
            }
        }

        [WebMethod]
        public static string UpdateSection(string id, string name, string desc)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                !string.IsNullOrEmpty(desc.Trim()))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.SectionId = Convert.ToInt32(id);
                lClassSectionEntity.SectionName = name;
                lClassSectionEntity.DisplaySectionName = desc;
                lClassSectionEntity.Action = "E";
                lClassSectionEntity.Type = "S";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "House has been updated successfully";
                }
                else
                {
                    return "0";
                    //return "House is not updated";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }

        [WebMethod]
        public static string AddSection(string name, string desc)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                 !string.IsNullOrEmpty(desc.Trim()))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.SectionId = Convert.ToInt32(0);
                lClassSectionEntity.SectionName = name;
                lClassSectionEntity.DisplaySectionName = desc;
                lClassSectionEntity.Action = "A";
                lClassSectionEntity.Type = "S";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "House has been added successfully";
                }
                else
                {
                    return "0";
                    //return "House is not added";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }

        #endregion Section

        #region Class Section
        public string JsonClassSectionData
        {
            get
            {
                List<ClassSectionEntity> toEncode = new List<ClassSectionEntity>();
                UIHelper studentHelper = new UIHelper();

                toEncode = studentHelper.GetAllClassSectionHelp();
                string test = JsonConvert.SerializeObject(toEncode);

                return test;
            }
        }

        [WebMethod]
        public static string DeleteClassSection(string id)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(id))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.ClassSectionId = Convert.ToInt32(id);
                lClassSectionEntity.Action = "D";
                lClassSectionEntity.Type = "CS";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "class has been deleted successfully";
                }
                else
                {
                    return "0";
                    //return "Class has not deleted. Please try later";
                }
            }
            else
            {
                return "10";
                //return "Cannot delete class. Please try later.";
            }
        }

        [WebMethod]
        public static string UpdateClassSection(string id, string classid, string sectionid, string name, string desc)
        {
            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                !string.IsNullOrEmpty(desc.Trim()))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.ClassSectionId = Convert.ToInt32(id);
                lClassSectionEntity.ClassSectionName = name;
                lClassSectionEntity.DisplayClassSectionName = desc;
                lClassSectionEntity.ClassId = Convert.ToInt32(classid);
                lClassSectionEntity.SectionId = Convert.ToInt32(sectionid);
                lClassSectionEntity.Action = "E";
                lClassSectionEntity.Type = "CS";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "House has been updated successfully";
                }
                else
                {
                    return "0";
                    //return "House is not updated";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }

        [WebMethod]
        public static string AddClassSection(string classid,string sectionid, string name, string desc)
        {
            //return "Hello " + id + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();

            UIHelper studentHelper = new UIHelper();
            if (!string.IsNullOrEmpty(name.Trim()) &&
                 !string.IsNullOrEmpty(desc.Trim()))
            {
                ClassSectionEntity lClassSectionEntity = new ClassSectionEntity();
                lClassSectionEntity.ClassSectionId = Convert.ToInt32(0);
                lClassSectionEntity.ClassSectionName = name;
                lClassSectionEntity.DisplayClassSectionName = desc;
                lClassSectionEntity.ClassId = Convert.ToInt32(classid);
                lClassSectionEntity.SectionId = Convert.ToInt32(sectionid);
                lClassSectionEntity.Action = "A";
                lClassSectionEntity.Type = "CS";
                lClassSectionEntity.UserId = 1;

                if (studentHelper.AddUpdateDelClassAndSectionHelp(lClassSectionEntity))
                {
                    return "1";
                    //return "House has been added successfully";
                }
                else
                {
                    return "0";
                    //return "House is not added";
                }
            }
            else
            {
                return "10";
                //return "Please insert house name";
            }
        }

        #endregion Class Section
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
    }
}