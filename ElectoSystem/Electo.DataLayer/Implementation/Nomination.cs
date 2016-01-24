using System;
using System.Collections.Generic;
using Electo.DataLayer.Entities;
using System.Configuration;
using System.Data;
using Kosus.DataAccess.MySql;
using Electo.Constants;

namespace Electo.DataLayer.Implementation
{
    public class Nomination
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List<Nominees> List of Nominees</returns>
        public List<Nominees> GetAllSenateNominees()
        {
            List<Nominees> studNomList = new List<Nominees>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtSenateNominees = mySqlHelper.GetDataTable(System.Data.CommandType.StoredProcedure, ProcedureConstant.SPGetAllSenateNominees, 
                                                    new ParameterData("piStudentId", ""));

                    foreach (DataRow dr in dtSenateNominees.Rows)
                    {
                        Nominees studNom = new Nominees();
                        studNom.Nom_Id = Convert.ToInt32(dr["NomineeId"]);
                        studNom.Nom_Key = dr["StudentID"].ToString();
                        studNom.Nom_Name = dr["StudentName"].ToString();
                        studNom.Nom_DesignationId = Convert.ToInt32(dr["DesignationID"]);
                        studNom.Nom_DesignationCode = dr["DesignationCode"].ToString();
                        studNom.Nom_DesignationKey = dr["DesignationText"].ToString();
                        studNom.Nom_ClassSection = dr["ClassSection"].ToString();
                        studNom.Nom_PhotoURL = dr["PhotoURL"].ToString();
                        studNom.Nom_AboutNominee = dr["AboutMe"].ToString();
                        studNom.Nom_ElectionId = Convert.ToInt32(dr["ElectionId"]);
                        studNom.Nom_VoteCount = Convert.ToInt32(dr["TotalVote"]);
                        studNomList.Add(studNom);
                    }
                }
                return studNomList;
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

        public List<Nominees> GetHouseNominationsById(int houseId)
        {
            List<Nominees> studNomList = new List<Nominees>();

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable dtHouseNominees = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetHouseNominationsNameByHouseId
                                                                        , new ParameterData("piHouseId", houseId));

                    foreach (DataRow dr in dtHouseNominees.Rows)
                    {
                        Nominees studNom = new Nominees();
                        studNom.Nom_Id = Convert.ToInt32(dr["NomineeId"]);
                        studNom.Nom_Key = dr["StudentID"].ToString();
                        studNom.Nom_Name = dr["StudentName"].ToString();
                        studNom.Nom_DesignationId = Convert.ToInt32(dr["DesignationID"]);
                        studNom.Nom_DesignationCode = dr["DesignationCode"].ToString();
                        studNom.Nom_DesignationKey = dr["DesignationText"].ToString();
                        studNom.Nom_ClassSection = dr["ClassSection"].ToString();
                        studNom.Nom_PhotoURL = dr["PhotoURL"].ToString();
                        studNom.Nom_AboutNominee = dr["AboutMe"].ToString();
                        studNom.Nom_ElectionId = Convert.ToInt32(dr["ElectionId"]);
                        studNom.Nom_VoteCount = Convert.ToInt32(dr["TotalVote"]);

                        studNomList.Add(studNom);
                    }
                }
                return studNomList;
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

        public bool UpdateCandidateVote(string VoaterId,string NomineeId,string VoteType, string ColumnName)
        {
            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    return Convert.ToBoolean(mySqlHelper.SendQuery(CommandType.StoredProcedure, ProcedureConstant.SPUpdateCandidateVote,
                                              new ParameterData("piVoaterId", VoaterId),
                                              new ParameterData("piNomineeId", NomineeId),
                                              new ParameterData("piVoteType", VoteType),
                                              new ParameterData("piColumnName", ColumnName)) > 0);
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
                return false;
            }
        }

        public VotetedStudents GetVotetedStudentsStatus(string studId)
        {

            try
            {
                VotetedStudents votetedStudents = null;
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    DataTable VotedStatus = mySqlHelper.GetDataTable(CommandType.StoredProcedure, ProcedureConstant.SPGetVoteStatus, new ParameterData("StudId", studId));
                    
                    foreach(DataRow dr in VotedStatus.Rows)
                    {
                        votetedStudents = new VotetedStudents();
                        votetedStudents.Vst_StudentKey = dr["Vst_StudentKey"].ToString();
                        votetedStudents.Vst_IVFHouse =Convert.ToBoolean( dr["Vst_IVFHouse"]);
                        votetedStudents.Vst_IVFSenate = Convert.ToBoolean(dr["Vst_IVFSenate"]);
                    }
                }
                return votetedStudents;
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

        public Nominees GetSenateNomineesById(string studId)
        {
            throw new NotImplementedException();
        }

        public List<Nominees> GetHouseNominations()
        {
            throw new NotImplementedException();
        }
    }
}
