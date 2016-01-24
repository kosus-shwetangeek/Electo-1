using AutoMapper;
using ElectoSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Electo.DataLayer.Entities;
using Electo.BusinessLayer.Implementation;

namespace ElectoSystem.Helper
{
    public class UIHelper
    {
        #region Private Member

        List<ElectoSystem.Entities.StudentEntity> lStudentEntityList = new List<ElectoSystem.Entities.StudentEntity>();
        List<NomineesEntity> lNomineeList = new List<NomineesEntity>();
        List<ElectionsEntity> lElectionList = new List<ElectionsEntity>();
        List<HouseData> lHouseNameList;
        List<ClassSectionEntity> lClassSectionList;
        //List<tclass> lClassList;
        //List<tsection> lSectionList;
        AdminBusiness mAdminBusiness = new AdminBusiness();
        Authentication mAuthentication = new Authentication();
        Nomination mNomination = new Nomination();
        UtilityBusiness mUtility = new UtilityBusiness();
        //votinglivedbEntities entityFrame;

        #endregion Private Member

        #region Constructor

        public UIHelper()
        {
            Mapper.CreateMap<ElectoSystem.Entities.StudentEntity, Electo.DataLayer.Entities.StudentEntity>();
            Mapper.CreateMap<Electo.DataLayer.Entities.StudentEntity, ElectoSystem.Entities.StudentEntity>();
            Mapper.CreateMap<Elections, ElectionsEntity>();
            Mapper.CreateMap<ElectionsEntity, Elections>();
            Mapper.CreateMap<NomineesEntity, Nominees>();
            Mapper.CreateMap<Nominees, NomineesEntity>();
            Mapper.CreateMap<VotedStudentsEntity, VotetedStudents>();
            Mapper.CreateMap<VotetedStudents, VotedStudentsEntity>();
            Mapper.CreateMap<ClassSectionEntity, ClassSection>();
            Mapper.CreateMap<ClassSection, ClassSectionEntity>();
        }

        #endregion Constructor

        #region Member Function
        internal List<ElectoSystem.Entities.StudentEntity> GetAllStudentHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllStudents] == null)
            {
                lStudentEntityList = Mapper.Map<List<Electo.DataLayer.Entities.StudentEntity>, List<ElectoSystem.Entities.StudentEntity>>(mAuthentication.GetAllStudent());

                if (lStudentEntityList != null && lStudentEntityList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllStudents, lStudentEntityList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lStudentEntityList = (List<ElectoSystem.Entities.StudentEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllStudents];
            }
            return lStudentEntityList;
        }

        internal ElectoSystem.Entities.StudentEntity GetStudentByElectionId(string ElectionId)
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllStudents] == null)
            {
                lStudentEntityList = Mapper.Map<List<Electo.DataLayer.Entities.StudentEntity>, List<ElectoSystem.Entities.StudentEntity>>(mAuthentication.GetAllStudent());

                if (lStudentEntityList != null && lStudentEntityList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllStudents, lStudentEntityList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lStudentEntityList = (List<ElectoSystem.Entities.StudentEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllStudents];
            }

            return lStudentEntityList.Where(X => X.Stud_Key.ToLower() == ElectionId.ToLower()).FirstOrDefault();
        }

        internal List<NomineesEntity> GetHouseNominationsByIdHelp(int studHouseId)
        {
            return Mapper.Map<List<Nominees>, List<NomineesEntity>>(mNomination.GetHouseNominationsById(studHouseId));
        }

        internal List<NomineesEntity> GetAllSenateNomineesHelp(bool xiDontUseCache)
        {
            if (xiDontUseCache || HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateNomination] == null)
            {
                lNomineeList = Mapper.Map<List<Nominees>, List<NomineesEntity>>(mNomination.GetAllSenateNominees());

                if (lNomineeList != null && lNomineeList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllSenateNomination, lNomineeList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lNomineeList = (List<NomineesEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateNomination];
            }
            return lNomineeList;
        }

        internal VotedStudentsEntity GetVotetedStudentsStatusHelp(string studId)
        {
            return Mapper.Map<VotetedStudents, VotedStudentsEntity>(mNomination.GetVotetedStudentsStatus(studId));
        }

        internal ElectoSystem.Entities.StudentEntity CheckStudentExistHelp(string userName, string password)
        {
            return Mapper.Map<Electo.DataLayer.Entities.StudentEntity, ElectoSystem.Entities.StudentEntity>(mAuthentication.CheckStudentExist(userName, password));
        }

        internal ElectoSystem.Entities.StudentEntity GetUserSessionHelp(string userName, string userType)
        {
            return Mapper.Map<Electo.DataLayer.Entities.StudentEntity, ElectoSystem.Entities.StudentEntity>(mAuthentication.GetUserSession(userName, userType));
        }

        internal List<ElectoSystem.Entities.StudentEntity> GetAllHouseHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHouse] == null)
            {
                lStudentEntityList = Mapper.Map<List<Electo.DataLayer.Entities.StudentEntity>, List<ElectoSystem.Entities.StudentEntity>>(mAdminBusiness.GetAllHouses());

                if (lStudentEntityList != null && lStudentEntityList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHouse, lStudentEntityList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lStudentEntityList = (List<ElectoSystem.Entities.StudentEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHouse];
            }
            return lStudentEntityList;
        }

        internal bool UpdateResetPasswordHelp(string userName, string newPassword, DateTime sDoB)
        {
            return mAuthentication.UpdateResetPassword(userName, newPassword, sDoB);
        }

        internal bool AddUpdateDelHouseHelp(int houseId, string houseName, string houseDescription, string houseCode, string action, int userId)
        {
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllHouse);
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllHousePair);
            return mAdminBusiness.AddUpdateDelHouse(houseId, houseName, houseDescription, houseCode, action, userId);
        }

        internal List<Entities.StudentEntity> GetAllHousesDesignationHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseDesignation] == null)
            {
                lStudentEntityList = Mapper.Map<List<Electo.DataLayer.Entities.StudentEntity>, List<ElectoSystem.Entities.StudentEntity>>(mAdminBusiness.GetAllHousesDesignation());

                if (lStudentEntityList != null && lStudentEntityList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHouseDesignation, lStudentEntityList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lStudentEntityList = (List<ElectoSystem.Entities.StudentEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseDesignation];
            }
            return lStudentEntityList;
        }

        internal bool AddUpdateDelHouseDesignationHelp(int houseDesignationId, int houseId, string designationName, string designationDescription, string designationCode, int genderId, string action, int userId)
        {
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllHouseDesignation);
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllHouseDesignationPair);

            return mAdminBusiness.AddUpdateDelHouseDesignation(houseDesignationId, houseId, designationName, designationDescription, designationCode, genderId, action, userId);
        }

        internal List<ElectoSystem.Entities.StudentEntity> GetAllSenateDesignationHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateDesignation] == null)
            {
                lStudentEntityList = Mapper.Map<List<Electo.DataLayer.Entities.StudentEntity>, List<Entities.StudentEntity>>(mAdminBusiness.GetAllSenateDesignation());

                if (lStudentEntityList != null && lStudentEntityList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllSenateDesignation, lStudentEntityList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lStudentEntityList = (List<Entities.StudentEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateDesignation];
            }
            return lStudentEntityList;
        }

        internal bool AddUpdateDelSenateDesignationHelp(int senateId, string senateDesignation, string senateDescription, string senateCode, int genderId, string action, int userId)
        {
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllSenateDesignation);
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllSenateDesignationPair);

            return mAdminBusiness.AddUpdateDelSenateDesignation(senateId, senateDesignation, senateDescription, senateCode, genderId, action, userId);
        }

        internal List<HouseData> GetAllHouseNameHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHouse] == null)
            {
                lStudentEntityList = Mapper.Map<List<Electo.DataLayer.Entities.StudentEntity>, List<Entities.StudentEntity>>(mAdminBusiness.GetAllHouses());

                if (lStudentEntityList != null && lStudentEntityList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHouse, lStudentEntityList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lStudentEntityList = (List<Entities.StudentEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHouse];
            }

            lHouseNameList = new List<HouseData>();
            HouseData houseDataDefault = new HouseData();
            houseDataDefault.HouseName = "All Houses";
            houseDataDefault.HouseId = 0;
            lHouseNameList.Add(houseDataDefault);

            foreach (Entities.StudentEntity house in lStudentEntityList)
            {
                HouseData houseData = new HouseData();
                houseData.HouseName = house.Stud_HouseName;
                houseData.HouseId = house.Stud_HouseId;
                lHouseNameList.Add(houseData);
            }

            return lHouseNameList;
        }

        /// <summary>
        /// Helper method for Add Update Delete Student which will call Admin Service
        /// </summary>
        /// <param name="xiStudent">Student Object</param>
        /// <param name="xiOperationMode">Choice code to select Add Update or Delete</param>
        /// <returns></returns>
        internal bool AddUpdateDeleteStudent(ElectoSystem.Entities.StudentEntity xiStudent, string xiOperationMode)
        {
            Electo.DataLayer.Entities.StudentEntity lStudent = Mapper.Map<Entities.StudentEntity, Electo.DataLayer.Entities.StudentEntity>(xiStudent);

            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllStudents);
            return mAdminBusiness.AddUpdateDelStudent(lStudent, xiOperationMode);
        }

        internal bool AddDeleteHouseNominee(int xiHouseNominationId, int xiHouseId, int xiHouseDesId, int xiClassSecId, string xiStudKey, string xiPhotURL, int xiElectionId, string xiAction, int xiUserId)
        {
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllHouseNomination);
            return mAdminBusiness.AddUpdateDelHouseNominationDetails(xiHouseNominationId, xiHouseId, xiHouseDesId, xiClassSecId, xiStudKey, xiPhotURL, xiElectionId, xiAction, xiUserId);
        }

        internal bool AddDeleteSenateNominee(int xiSenateNominationId, int xiSenateDesignationId, int xiClassSectionId, string xiStudentKey, string xiPhotoURL, int xiElectionId, string xiAbout, string xiAction, int xiUserId)
        {
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllSenateNomination);
            return mAdminBusiness.AddUpdateDelSenateNominationDetails(xiSenateNominationId, xiSenateDesignationId, xiClassSectionId, xiStudentKey, xiPhotoURL, xiElectionId, xiAbout, xiAction, xiUserId);
        }

        internal List<ElectoSystem.Entities.StudentEntity> GetAllHousesNominationHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseNomination] == null)
            {
                lStudentEntityList = Mapper.Map<List<Electo.DataLayer.Entities.StudentEntity>, List<Entities.StudentEntity>>(mAdminBusiness.GetAllHouseNominationDetails());

                if (lStudentEntityList != null && lStudentEntityList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHouseNomination, lStudentEntityList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lStudentEntityList = (List<Entities.StudentEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseNomination];
            }
            return lStudentEntityList;
        }

        internal NomineesEntity GetSenateNomineeByStudKeyHelp(string xiStudKey)
        {
            lNomineeList = Mapper.Map<List<Nominees>, List<NomineesEntity>>(mNomination.GetAllSenateNominees());
            NomineesEntity nomineesEntity = new NomineesEntity();
            if (lNomineeList != null && lNomineeList.Count > 0)
            {
                nomineesEntity = lNomineeList.Where(x => x.Nom_Key.ToLower() == xiStudKey.ToLower()).FirstOrDefault();
            }
            //return Mapper.Map<NomineesDTO, NomineesEntity>(iNomination.GetAllSenateNominees().Where(x => x.Nom_Key.ToLower() == xiStudKey.ToLower()).FirstOrDefault());
            return nomineesEntity;
        }

        internal bool UpdateCandidateVoteHelp(string xiVoaterId, string xiNomineeId, string xiVoteType, string xiStudKey)
        {
            return mNomination.UpdateCandidateVote(xiVoaterId, xiNomineeId, xiVoteType, xiStudKey);
        }

        internal List<ElectionsEntity> GetAllHouseElectionsHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseElections] == null)
            {
                lElectionList = Mapper.Map<List<Elections>, List<ElectionsEntity>>(mAdminBusiness.GetAllHouseElections());

                if (lElectionList != null && lElectionList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHouseElections, lElectionList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lElectionList = (List<ElectionsEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseElections];
            }

            return lElectionList;
        }

        internal List<ElectionsEntity> GetAllSenateElectionsHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateElections] == null)
            {
                lElectionList = Mapper.Map<List<Elections>, List<ElectionsEntity>>(mAdminBusiness.GetAllSenateElections());

                if (lElectionList != null && lElectionList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllSenateElections, lElectionList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lElectionList = (List<ElectionsEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateElections];
            }

            return lElectionList;
        }

        internal bool AddUpdateDeleteSenateElectionHelp(int xiElectionId, DateTime xiStartDate, DateTime xiEndDate, string xiDescription, string xiMode)
        {
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllSenateElections);
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllSenateElectionsPair);

            return mAdminBusiness.AddUpdateDeleteSenateElections(xiElectionId, xiStartDate, xiEndDate, xiDescription, xiMode);
        }

        internal bool AddUpdateDeleteHouseElectionHelp(int xiElectionId, DateTime xiStartDate, DateTime xiEndDate, string xiDescription, string xiMode)
        {
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllHouseElections);
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllHouseElectionsPair);

            return mAdminBusiness.AddUpdateDeleteHouseElections(xiElectionId, xiStartDate, xiEndDate, xiDescription, xiMode);
        }

        internal void LogError(int xiServerityId, string xiMessage)
        {
            mUtility.LogError(xiServerityId, xiMessage);
        }

        #region ClassSection

        internal List<ClassSectionEntity> GetAllClassesHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllClasses] == null)
            {
                lClassSectionList = Mapper.Map<List<ClassSection>, List<ClassSectionEntity>>(mAdminBusiness.GetAllClasses());

                if (lClassSectionList != null && lClassSectionList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllClasses, lClassSectionList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lClassSectionList = (List<ClassSectionEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllClasses];
            }

            return lClassSectionList;
        }

        internal List<ClassSectionEntity> GetAllSectionsHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllSections] == null)
            {
                lClassSectionList = Mapper.Map<List<ClassSection>, List<ClassSectionEntity>>(mAdminBusiness.GetAllSections());

                if (lClassSectionList != null && lClassSectionList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllSections, lClassSectionList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lClassSectionList = (List<ClassSectionEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllSections];
            }

            return lClassSectionList;
        }

        internal List<ClassSectionEntity> GetAllClassSectionHelp()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllClassSections] == null)
            {
                lClassSectionList = Mapper.Map<List<ClassSection>, List<ClassSectionEntity>>(mAdminBusiness.GetAllClassSection());

                if (lClassSectionList != null && lClassSectionList.Count > 0)
                {
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllClassSections, lClassSectionList, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
            else
            {
                lClassSectionList = (List<ClassSectionEntity>)HttpContext.Current.Cache[Common.UIConstants.cache_AllClassSections];
            }

            return lClassSectionList;
        }

        internal bool AddUpdateDelClassAndSectionHelp(ClassSectionEntity classSectionEntity)
        {
            ClassSection lClassSection = Mapper.Map<ClassSectionEntity, ClassSection>(classSectionEntity);

            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllClasses);
            HttpContext.Current.Cache.Remove(Common.UIConstants.cache_AllSections);
            return mAdminBusiness.AddUpdateDelClassAndSection(lClassSection);
        }

        #endregion ClassSection

        #endregion Member Function
    }
}