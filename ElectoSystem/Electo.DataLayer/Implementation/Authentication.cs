using System;
using System.Collections.Generic;
using System.Data;
using Electo.DataLayer.Entities;
using System.Configuration;
using Kosus.DataAccess.MySql;
using Electo.Constants;


namespace Electo.DataLayer.Implementation
{
    /// <summary>
    /// Class Authentication.
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Gets all student.
        /// </summary>
        /// <returns>DataTable.</returns>
        public List<StudentEntity> GetAllStudent()
        {
            try
            {
                List<StudentEntity> studentList = new List<StudentEntity>();

                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtStudents = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllStudents);
                    StudentEntity stud;

                    foreach (DataRow dr in dtStudents.Rows)
                    {
                        stud = new StudentEntity();

                        stud.Stud_Id = Convert.ToInt32(dr["stud_Id"]);
                        stud.Stud_Key = dr["stud_Key"].ToString();
                        stud.Stud_FName = dr["stud_FirstName"].ToString();
                        stud.Stud_MName = dr["stud_MiddleName"].ToString();
                        stud.Stud_LName = dr["stud_LastName"].ToString();
                        stud.Stud_DoB = DateTime.Parse(dr["stud_DoB"].ToString());
                        stud.Stud_GenderId = Convert.ToInt32(dr["stud_GenderId"].ToString());
                        stud.Stud_Gender = dr["stud_Gender"].ToString();
                        stud.Stud_GenderCode = dr["stud_GenderCode"].ToString();
                        stud.Stud_ClassSectionId = Convert.ToInt32(dr["stud_ClassSectionId"].ToString());
                        stud.Stud_ClassId = Convert.ToInt32(dr["Stud_ClassId"].ToString());
                        stud.Stud_Class = dr["Stud_Class"].ToString();
                        stud.Stud_SectionId = Convert.ToInt32(dr["Stud_SectionId"].ToString());
                        stud.Stud_Section = dr["Stud_Section"].ToString();
                        stud.Stud_ClassSection = dr["Stud_ClassSection"].ToString();
                        stud.Stud_HouseId = Convert.ToInt32(dr["Stud_HouseId"].ToString());
                        stud.Stud_HouseName = dr["Stud_HouseName"].ToString();
                        stud.Stud_UserType = dr["Stud_UserType"].ToString();
                        stud.Stud_HouseCode = dr["Stud_HouseCode"].ToString();
                        stud.Stud_Photo = dr["stud_Photo"] == null ? string.Empty : dr["stud_Photo"].ToString().Trim();// string.Empty;// dr.GetString(19);
                        stud.Stud_Password = dr["stud_Password"].ToString();
                        stud.Stud_IsInUse = dr["IsInUse"].ToString();
                        studentList.Add(stud);
                    }
                }

                return studentList;
            }
            catch (Exception ex)
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    mySqlHelper.SendQuery(  CommandType.StoredProcedure, 
                                            ProcedureConstant.SPLoggError, 
                                            new ParameterData("piSeverityId", (int)ENums.EWSSeverity.Error),
                                            new ParameterData("piDescription", ex.ToString()));
                }
                return null;
            }

            //return studentSessionList;
        }

        /// <summary>
        /// Gets the student by election identifier.
        /// </summary>
        /// <param name="ElectionId">The election identifier.</param>
        /// <returns>Nominees.</returns>
        public Nominees GetStudentByElectionId(string ElectionId)
        {
            try
            {
                Nominees studNom = null;
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable Students = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllStudents, 
                                                            new ParameterData("ElectionId", ElectionId));

                    if (Students.Rows.Count > 0)
                    {
                        foreach (DataRow dr in Students.Rows)
                        {
                            studNom = new Nominees();
                            studNom.Nom_Id = Convert.ToInt32(dr["NomineeId"]);
                            studNom.Nom_Key = dr["StudentID"].ToString();
                            studNom.Nom_Name = dr["StudentName"].ToString();
                            studNom.Nom_DesignationId = Convert.ToInt32(dr["DesignationID"]);
                            studNom.Nom_DesignationKey = dr["DesignationText"].ToString();
                            studNom.Nom_ClassSection = dr["ClassSection"].ToString();
                            studNom.Nom_PhotoURL = dr["PhotoURL"].ToString();
                            studNom.Nom_AboutNominee = dr["AboutMe"].ToString();

                            break;
                        }
                    }
                }

                return studNom;
            }
            catch (Exception ex)
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    mySqlHelper.SendQuery(CommandType.StoredProcedure,
                                            ProcedureConstant.SPLoggError,
                                            new ParameterData("piSeverityId", (int)ENums.EWSSeverity.Error),
                                            new ParameterData("piDescription", ex.ToString()));
                }
                return null;
            }
        }

        /// <summary>
        /// Checks the student exist.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns>StudentEntity.</returns>
        public StudentEntity CheckStudentExist(string UserName, string Password)
        {
            try
            {
                StudentEntity studentSession = null;

                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable Student = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPVerifyUser,
                                                    new ParameterData("piUserName", UserName),
                                                    new ParameterData("piNewPassword", Password));



                    if (Student.Rows.Count > 0)
                    {
                        foreach (DataRow dr in Student.Rows)
                        {
                            studentSession = new StudentEntity();
                            studentSession.Stud_Key = dr["Username"].ToString();
                            studentSession.Stud_Password = dr["Password"].ToString();
                            studentSession.Stud_UserType = dr["UserType"].ToString();

                            break;
                        }
                    }
                }

                return studentSession;
            }
            catch (Exception ex)
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    mySqlHelper.SendQuery(CommandType.StoredProcedure,
                                            ProcedureConstant.SPLoggError,
                                            new ParameterData("piSeverityId", (int)ENums.EWSSeverity.Error),
                                            new ParameterData("piDescription", ex.ToString()));
                }
                return null;
            }

            //return studentSession;
        }

        /// <summary>
        /// Updates the reset password.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <param name="DoB">The do b.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateResetPassword(string UserName, string Password, DateTime DoB)
        {
            bool isResetUpdate = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPUpdateUserPassword, new ParameterData("piUserName", UserName), new ParameterData("piNewPassword", Password), new ParameterData("piDoB", DoB.ToString("yyyy-MM-dd"))) > 0)
                    {
                        isResetUpdate = true;
                    }
                }

                return isResetUpdate;
            }
            catch (Exception ex)
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    mySqlHelper.SendQuery(CommandType.StoredProcedure,
                                            ProcedureConstant.SPLoggError,
                                            new ParameterData("piSeverityId", (int)ENums.EWSSeverity.Error),
                                            new ParameterData("piDescription", ex.ToString()));
                }
                return isResetUpdate;
            }
        }


        public StudentEntity GetUserSession(string UserName, string UserType)
        {
            try
            {
                StudentEntity studentSession = null;

                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtStudent = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetUserSession,
                                                                new ParameterData("piUserName", UserName), new ParameterData("piUserType", UserType));

                    foreach(DataRow dr in dtStudent.Rows)
                    {
                        studentSession = new StudentEntity();
                        studentSession.Stud_Id = Convert.ToInt32(dr["stud_Id"]);
                        studentSession.Stud_Key = dr["stud_Key"].ToString();
                        studentSession.Stud_Name = dr["StudentName"].ToString();
                        studentSession.Stud_FName = dr["stud_FirstName"].ToString();
                        studentSession.Stud_MName = dr["stud_MiddleName"].ToString();
                        studentSession.Stud_LName = dr["stud_LastName"].ToString();
                        studentSession.Stud_DoB = Convert.ToDateTime(dr["stud_DoB"]);
                        studentSession.Stud_GenderId = Convert.ToInt32(dr["stud_GenderId"]);
                        studentSession.Stud_Gender = dr["stud_Gender"].ToString();
                        studentSession.Stud_GenderCode = dr["stud_GenderCode"].ToString();
                        studentSession.Stud_ClassSectionId = Convert.ToInt32(dr["stud_ClassSectionId"]);
                        studentSession.Stud_ClassId = Convert.ToInt32(dr["stud_ClassId"]);
                        studentSession.Stud_Class = dr["stud_Class"].ToString();
                        studentSession.Stud_SectionId = Convert.ToInt32(dr["stud_SectionId"]);
                        studentSession.Stud_Section = dr["stud_Section"].ToString();
                        studentSession.Stud_ClassSection = dr["stud_ClassSection"].ToString();
                        studentSession.Stud_HouseId = Convert.ToInt32(dr["stud_HouseId"]);
                        studentSession.Stud_HouseName = dr["stud_HouseName"].ToString();
                        studentSession.Stud_UserType = dr["stud_UserType"].ToString();
                        studentSession.Stud_HouseCode = dr["stud_HouseCode"].ToString();
                        studentSession.Stud_Photo = dr["stud_Photo"].ToString();//Convert.ToInt32(dr["stud_GenderId"]) == 1 ? "../dist/img/boy.png" : "../dist/img/dT7eM7rac.png";// string.Empty;// dr.GetString(19);

                        break;
                    }
                }
                
                return studentSession;
            }
            catch (Exception ex)
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    mySqlHelper.SendQuery(CommandType.StoredProcedure,
                                            ProcedureConstant.SPLoggError,
                                            new ParameterData("piSeverityId", (int)ENums.EWSSeverity.Error),
                                            new ParameterData("piDescription", ex.ToString()));
                }
                return null;
            }
        }
    }
}
