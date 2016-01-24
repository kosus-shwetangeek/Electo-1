using Electo.DataLayer.Entities;
using Electo.Constants;
using Kosus.DataAccess.MySql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Electo.DataLayer.Implementation
{
    public class Admin
    {
        /// <summary>
        /// Gets all houses.
        /// </summary>
        /// <returns>List&lt;StudentEntity&gt;.</returns>
        public List<StudentEntity> GetAllHouses()
        {
            List<StudentEntity> houseList = new List<StudentEntity>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtHouses = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllHouses);
                    StudentEntity house;

                    foreach (DataRow dr in dtHouses.Rows)
                    {
                        house = new StudentEntity();

                        house.Stud_HouseId = Convert.ToInt32(dr["Hus_Id"].ToString());
                        house.Stud_HouseName = dr["HouseName"].ToString();
                        house.Stud_HouseCode = dr["HouseCode"].ToString();
                        house.Stud_HouseDescription = dr["HouseDescription"].ToString();
                        house.Stud_IsInUse = dr["IsInUse"].ToString();
                        houseList.Add(house);
                    }
                }
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

            return houseList;
        }

        /// <summary>
        /// Adds the update house.
        /// </summary>
        /// <param name="houseId">The house identifier.</param>
        /// <param name="houseName">Name of the house.</param>
        /// <param name="houseDescription">The house description.</param>
        /// <param name="houseCode">The house code.</param>
        /// <param name="action">The action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddUpdateDelHouse(int houseId, string houseName, string houseDescription, string houseCode, string action, int userId)
        {
            bool isAddDeleted = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddDelHouses,
                                                new ParameterData("piHouseId", houseId), new ParameterData("piHouseNmae", houseName),
                                                new ParameterData("piHouseDescription", houseDescription), new ParameterData("piHouseCode", houseCode),
                                                new ParameterData("piAction", action), new ParameterData("piUserId", userId)) > 0)
                    {
                        isAddDeleted = true;
                    }
                }

                return isAddDeleted;
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
                return isAddDeleted;
            }
        }

        /// <summary>
        /// Gets all houses designation.
        /// </summary>
        /// <returns>List&lt;StudentEntity&gt;.</returns>
        public List<StudentEntity> GetAllHousesDesignation()
        {
            List<StudentEntity> houseDesignationList = new List<StudentEntity>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtHousesDesignation = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SP_GetAllHouseDesignation);
                    StudentEntity houseDesignation;

                    foreach (DataRow dr in dtHousesDesignation.Rows)
                    {
                        houseDesignation = new StudentEntity();

                        houseDesignation.Stud_HouseId = Convert.ToInt32(dr["Hus_Id"].ToString());
                        houseDesignation.Stud_HouseName = dr["HouseName"].ToString();
                        houseDesignation.Stud_HouseDesignationId = Convert.ToInt32(dr["Hsd_Id"].ToString());
                        houseDesignation.Stud_HouseDesignation = dr["HouseDesignation"].ToString();
                        houseDesignation.Stud_HouseDesignationCode = dr["HouseDesignationCode"].ToString();
                        houseDesignation.Stud_HouseDesignationDescription = dr["HouseDesignationDescription"].ToString();
                        houseDesignation.Stud_GenderId = Convert.ToInt32(dr["Gen_Id"]);
                        houseDesignation.Stud_Gender = dr["Gender"].ToString();
                        houseDesignation.Stud_IsInUse = dr["IsInUse"].ToString();
                        houseDesignationList.Add(houseDesignation);
                    }
                }
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

            return houseDesignationList;
        }

        /// <summary>
        /// Adds the update house designation.
        /// </summary>
        /// <param name="houseDesignationId">The house designation identifier.</param>
        /// <param name="houseId">The house identifier.</param>
        /// <param name="designationName">Name of the designation.</param>
        /// <param name="designationDescription">The designation description.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="genderId">The gender identifier.</param>
        /// <param name="action">The action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddUpdateDelHouseDesignation(int houseDesignationId, int houseId, string designationName, string designationDescription, string designationCode,
            int genderId, string action, int userId)
        {
            bool isAddDeleted = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddUpdateDelHouseDesignation,
                                                new ParameterData("piHouseDesignationId", houseDesignationId), new ParameterData("piHouseId", houseId),
                                                new ParameterData("piDesignationNmae", designationName), new ParameterData("piDesignationDescription", designationDescription),
                                                new ParameterData("piDesignationCode", designationCode), new ParameterData("piGender", genderId),
                                                new ParameterData("piAction", action), new ParameterData("piUserId", userId)) > 0)
                    {
                        isAddDeleted = true;
                    }
                }

                return isAddDeleted;
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
                return isAddDeleted;
            }
        }

        /// <summary>
        /// Gets all senate designation.
        /// </summary>
        /// <returns>List&lt;StudentEntity&gt;.</returns>
        public List<StudentEntity> GetAllSenateDesignation()
        {
            List<StudentEntity> senateDesignationList = new List<StudentEntity>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtSenateDesignation = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllSenateDesignation);
                    StudentEntity senateDesignation;

                    foreach (DataRow dr in dtSenateDesignation.Rows)
                    {
                        senateDesignation = new StudentEntity();

                        senateDesignation.Stud_SenateId = Convert.ToInt32(dr["Sen_Id"].ToString());
                        senateDesignation.Stud_SenateDesignation = dr["SenateDesignation"].ToString();
                        senateDesignation.Stud_SenateDesignationCode = dr["SenateDesignationCode"].ToString();
                        senateDesignation.Stud_SenateDesignationDescription = dr["SenateDescription"].ToString();
                        senateDesignation.Stud_GenderId = Convert.ToInt32(dr["Gen_Id"]);
                        senateDesignation.Stud_Gender = dr["Gender"].ToString();
                        senateDesignation.Stud_IsInUse = dr["IsInUse"].ToString();
                        senateDesignationList.Add(senateDesignation);
                    }
                }
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
            return senateDesignationList;
        }

        /// <summary>
        /// Adds the update senate designation.
        /// </summary>
        /// <param name="senateId">The senate identifier.</param>
        /// <param name="senateDesignation">The senate designation.</param>
        /// <param name="senateDescription">The senate description.</param>
        /// <param name="senateCode">The senate code.</param>
        /// <param name="genderId">The gender identifier.</param>
        /// <param name="action">The action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddUpdateDelSenateDesignation(int senateId, string senateDesignation, string senateDescription, string senateCode, int genderId, string action, int userId)
        {
            bool isAddDeleted = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddUpdateDelSenateDesignation,
                                                new ParameterData("piSenateId", senateId),
                                                new ParameterData("piSenateDesignation", senateDesignation), new ParameterData("piSenateDescription", senateDescription),
                                                new ParameterData("piSenateCode", senateCode), new ParameterData("piGender", genderId),
                                                new ParameterData("piAction", action), new ParameterData("piUserId", userId)) > 0)
                    {
                        isAddDeleted = true;
                    }
                }

                return isAddDeleted;
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
                return isAddDeleted;
            }
        }

        /// <summary>
        /// Add Update or Delete student from student table
        /// </summary>
        /// <param name="xiStudent">Student Object</param>
        /// <param name="xiOperationMode">Select mode Add Update Delete</param>
        /// <returns></returns>
        public bool AddUpdateDelStudent(StudentEntity xiStudent, string xiOperationMode)
        {
            bool isSuccess = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (xiOperationMode == "D")
                    {
                        if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPDeleteStudent,
                                                    new ParameterData("pistude_key", xiStudent.Stud_Key),
                                                    new ParameterData("piuser_id", 1)) > 0)
                        {
                            isSuccess = true;
                        }
                    }
                    else
                    {
                        if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddUpdateDelStudent,
                                                    new ParameterData("pistud_id", xiStudent.Stud_Id),
                                                    new ParameterData("pistud_Key", xiStudent.Stud_Key),
                                                    new ParameterData("pistud_FirstName", xiStudent.Stud_FName),
                                                    new ParameterData("pistud_LastName", xiStudent.Stud_LName),
                                                    new ParameterData("pistud_MiddleName", xiStudent.Stud_MName),
                                                    new ParameterData("pistud_DoB", xiStudent.Stud_DoB.Date.ToString("yyyy-MM-dd")),
                                                    new ParameterData("pistud_GenderId", xiStudent.Stud_GenderId),
                                                    new ParameterData("pistud_ClassSectionId", xiStudent.Stud_ClassSectionId),
                                                    new ParameterData("pistud_HouseId", xiStudent.Stud_HouseId),
                                                    new ParameterData("pistud_Password", xiStudent.Stud_Password),
                                                    new ParameterData("piAction", xiOperationMode),
                                                    new ParameterData("piuser_id", 1)) > 0)
                        {
                            isSuccess = true;
                        }
                    }
                }

                return isSuccess;
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
                return isSuccess;
            }
        }


        public int GetCurrentStudentId()
        {
            int lLastStudentId = int.MinValue;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    return mySqlHelper.GetColumn<int>(ProcedureConstant.Q_GetNextStudentId, "Stud_Id", true).FirstOrDefault();
                }
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
                return lLastStudentId;
            }
        }

        public List<StudentEntity> GetAllHouseNominationDetails()
        {
            List<StudentEntity> houseNominationList = new List<StudentEntity>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtHouseNomination = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllHouseNominationDetails);

                    foreach (DataRow dr in dtHouseNomination.Rows)
                    {
                        StudentEntity houseNomination = new StudentEntity();

                        houseNomination.Stud_HouseId = Convert.ToInt32(dr["HouseId"].ToString());
                        houseNomination.Stud_HouseName = dr["HouseName"].ToString();
                        houseNomination.Stud_HouseDesignationId = Convert.ToInt32(dr["HouseDesignationId"]);
                        houseNomination.Stud_HouseDesignation = dr["HouseDesignationName"].ToString();
                        houseNomination.Stud_ClassSectionId = Convert.ToInt32(dr["ClassSectionId"]);
                        houseNomination.Stud_ClassSection = dr["ClassSection"].ToString();
                        houseNomination.Stud_Id = Convert.ToInt32(dr["stud_Id"]);
                        houseNomination.Stud_Key = dr["stud_Key"].ToString();
                        houseNomination.Stud_FName = dr["stud_FirstName"].ToString();
                        houseNomination.Stud_MName = dr["stud_MiddleName"].ToString();
                        houseNomination.Stud_LName = dr["stud_LastName"].ToString();
                        houseNomination.Stud_GenderId = Convert.ToInt32(dr["Gen_Id"]);
                        houseNomination.Stud_Gender = dr["Gender"].ToString();
                        houseNomination.Stud_Photo = dr["stud_Photo"].ToString();
                        houseNominationList.Add(houseNomination);
                    }
                }
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
            return houseNominationList;
        }

        public bool AddUpdateDelHouseNominationDetails(int houseNominationId, int houseId, int houseDesignationId, int classSectionId, string studentKey, string photoURL, int electionId, string action, int userId)
        {
            bool isAddDeleted = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddUpdateDelHouseNominationDetails,
                                                new ParameterData("houseNominationId", houseNominationId),
                                                new ParameterData("houseId", houseId),
                                                new ParameterData("houseDesignationId", houseDesignationId),
                                                new ParameterData("classSectionId", classSectionId),
                                                new ParameterData("studentKey", studentKey),
                                                new ParameterData("photoURL", photoURL),
                                                new ParameterData("elctionid", electionId),
                                                new ParameterData("actionChr", action),
                                                new ParameterData("userId", userId)) > 0)
                    {
                        isAddDeleted = true;
                    }
                }

                return isAddDeleted;
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
                return isAddDeleted;
            }
        }


        public bool AddUpdateDelSenateNominationDetails(int xiSenateNominationId, int xiSenateDesignationId, int xiClassSectionId, string xiStudentKey, string xiPhotoURL, int xiElectionId, string xiAbout, string xiAction, int xiUserId)
        {
            bool isAddDeleted = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddUpdateDelSenateNominationDetails,
                                                new ParameterData("piSenateNominationId", xiSenateNominationId),
                                                new ParameterData("piSenateDesignationId", xiSenateDesignationId),
                                                new ParameterData("piClassSectionId", xiClassSectionId),
                                                new ParameterData("piStudentKey", xiStudentKey),
                                                new ParameterData("piPhotoURL", xiPhotoURL),
                                                new ParameterData("piAboutNominee", xiAbout),
                                                new ParameterData("piElctionid", xiElectionId),
                                                new ParameterData("piActionChr", xiAction),
                                                new ParameterData("piUserId", xiUserId)) > 0)
                    {
                        isAddDeleted = true;
                    }
                }

                return isAddDeleted;
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
                return isAddDeleted;
            }
        }


        public List<Elections> GetAllHouseElections()
        {
            List<Elections> lElectionsList = new List<Elections>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable lDTElections = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetHouseElection);

                    foreach (DataRow dr in lDTElections.Rows)
                    {
                        Elections lElection = new Elections();

                        lElection.ElectionId = Convert.ToInt32(dr["ElectionId"].ToString());
                        lElection.StartDate = dr["StartDate"] == null || string.IsNullOrEmpty(dr["StartDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["StartDate"]);
                        lElection.EndDate = dr["EndDate"] == null || string.IsNullOrEmpty(dr["EndDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["EndDate"]);
                        lElection.IsInUse = dr["IsInUse"].ToString();
                        lElection.Description = dr["Description"].ToString();
                        lElection.ElectionType = "h";
                        lElectionsList.Add(lElection);
                    }
                }
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
            return lElectionsList;
        }

        public List<Elections> GetAllSenateElections()
        {
            List<Elections> lElectionsList = new List<Elections>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable lDTElections = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetSenateElection);

                    foreach (DataRow dr in lDTElections.Rows)
                    {
                        Elections lElection = new Elections();

                        lElection.ElectionId = Convert.ToInt32(dr["ElectionId"].ToString());
                        lElection.StartDate = dr["StartDate"] == null || string.IsNullOrEmpty(dr["StartDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["StartDate"]);
                        lElection.EndDate = dr["EndDate"] == null || string.IsNullOrEmpty(dr["EndDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["EndDate"]);
                        lElection.IsInUse = dr["IsInUse"].ToString();
                        lElection.Description = dr["Description"].ToString();
                        lElection.ElectionType = "h";
                        lElectionsList.Add(lElection);
                    }
                }
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
            return lElectionsList;
        }

        public bool AddUpdateDeleteHouseElections(int xiElectionId, DateTime xiStartDate, DateTime xiEndDate, string xiDescription, string xiMode)
        {
            bool lIsSuccess = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddUpdateDeleteHouseElection,
                                                new ParameterData("piElectionId", xiElectionId),
                                                new ParameterData("piStartDate", xiStartDate),
                                                new ParameterData("piEndDate", xiEndDate),
                                                new ParameterData("piDescription", xiDescription),
                                                new ParameterData("piActionChr", xiMode)) > 0)
                    {
                        lIsSuccess = true;
                    }
                }

                return lIsSuccess;
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
                return lIsSuccess;
            }
        }

        public bool AddUpdateDeleteSenateElections(int xiElectionId, DateTime xiStartDate, DateTime xiEndDate, string xiDescription, string xiMode)
        {
            bool lIsSuccess = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddDeleteUpdateSenateElection,
                                                new ParameterData("piElectionId", xiElectionId),
                                                new ParameterData("piStartDate", xiStartDate),
                                                new ParameterData("piEndDate", xiEndDate),
                                                new ParameterData("piDescription", xiDescription),
                                                new ParameterData("piActionChr", xiMode)) > 0)
                    {
                        lIsSuccess = true;
                    }
                }

                return lIsSuccess;
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
                return lIsSuccess;
            }
        }

        #region ClassSection
        public List<ClassSection> GetAllClasses()
        {
            List<ClassSection> classList = new List<ClassSection>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtHouses = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllClasses);

                    foreach (DataRow dr in dtHouses.Rows)
                    {
                        ClassSection classes = new ClassSection();

                        classes.ClassId = Convert.ToInt32(dr["Cls_Id"].ToString());
                        classes.ClassName = dr["Cls_Name"].ToString();
                        classes.DisplayClassName = dr["Cls_DisplayName"].ToString();
                        classes.Class_IsInUse = dr["IsInUse"].ToString();
                        classList.Add(classes);
                    }
                }
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

            return classList;
        }

        public List<ClassSection> GetAllSections()
        {
            List<ClassSection> sectionList = new List<ClassSection>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtHouses = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllSections);

                    foreach (DataRow dr in dtHouses.Rows)
                    {
                        ClassSection sections = new ClassSection();

                        sections.SectionId = Convert.ToInt32(dr["Sec_Id"].ToString());
                        sections.SectionName = dr["Sec_Name"].ToString();
                        sections.DisplaySectionName = dr["Sec_DisplayName"].ToString();
                        sections.Section_IsInUse = dr["IsInUse"].ToString();
                        sectionList.Add(sections);
                    }
                }
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

            return sectionList;
        }

        public List<ClassSection> GetAllClassSection()
        {
            List<ClassSection> classSectionList = new List<ClassSection>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtHouses = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetAllClassSections);

                    foreach (DataRow dr in dtHouses.Rows)
                    {
                        ClassSection classsection = new ClassSection();

                        classsection.ClassSectionId = Convert.ToInt32(dr["Csc_Id"].ToString());
                        classsection.DisplayClassSectionName = dr["Csc_DisplayName"].ToString();
                        classsection.ClassSection_IsInUse = dr["IsInUse"].ToString();
                        classSectionList.Add(classsection);
                    }
                }
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

            return classSectionList;
        }

        public bool AddUpdateDelClassAndSection(ClassSection classSectionEntity)
        {
            bool isSuccess = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    if (mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPAddUpdateDelClassAndSection,
                                                    new ParameterData("piClassId", classSectionEntity.ClassId),
                                                    new ParameterData("piClassNmae", classSectionEntity.ClassName == null ? classSectionEntity.ClassName = "" : classSectionEntity.ClassName),
                                                    new ParameterData("piDisplayClassName", classSectionEntity.DisplayClassName == null ? classSectionEntity.DisplayClassName = "" : classSectionEntity.DisplayClassName),
                                                    new ParameterData("piSectionId", classSectionEntity.SectionId),
                                                    new ParameterData("piSectionName", classSectionEntity.SectionName == null ? classSectionEntity.SectionName = "" : classSectionEntity.SectionName),
                                                    new ParameterData("piDisplaySectionName", classSectionEntity.DisplaySectionName == null ? classSectionEntity.DisplaySectionName = "" : classSectionEntity.DisplaySectionName),
                                                    new ParameterData("piClassSectionId", classSectionEntity.ClassSectionId),
                                                    new ParameterData("piClassSectionName", classSectionEntity.ClassSectionName == null ? classSectionEntity.ClassSectionName = "" : classSectionEntity.ClassSectionName),
                                                    new ParameterData("piDisplayClassSectionName", classSectionEntity.DisplayClassSectionName == null ? classSectionEntity.DisplayClassSectionName = "" : classSectionEntity.DisplayClassSectionName),
                                                    new ParameterData("piType", classSectionEntity.Type),
                                                    new ParameterData("piAction", classSectionEntity.Action),
                                                    new ParameterData("piUserId", classSectionEntity.UserId)) > 0)
                    {
                        isSuccess = true;
                    }
                }

                return isSuccess;
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
                return isSuccess;
            }
        }

        #endregion ClassSection
    }
}