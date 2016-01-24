using Electo.DataLayer.Entities;
using Electo.DataLayer.Implementation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Electo.BusinessLayer.Implementation
{
    public class AdminBusiness
    {
        Admin Admin = new Admin();
        StudentEntity house = new StudentEntity();
        List<StudentEntity> houseList = new List<StudentEntity>();
        private bool disposed = false;

        /// <summary>
        /// Gets all houses.
        /// </summary>
        /// <returns>List&lt;StudentEntity&gt;.</returns>
        public List<StudentEntity> GetAllHouses()
        {
            return Admin.GetAllHouses();
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
            //admin = new Admin();
            return Admin.AddUpdateDelHouse(houseId, houseName, houseDescription, houseCode, action, userId);
        }

        /// <summary>
        /// Gets all houses designation.
        /// </summary>
        /// <returns>List&lt;StudentEntity&gt;.</returns>
        public List<StudentEntity> GetAllHousesDesignation()
        {
            //admin = new Admin();
            return houseList = Admin.GetAllHousesDesignation();
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
        public bool AddUpdateDelHouseDesignation(int houseDesignationId, int houseId, string designationName, string designationDescription, string designationCode, int genderId, string action, int userId)
        {
            //admin = new Admin();
            return Admin.AddUpdateDelHouseDesignation(houseDesignationId, houseId, designationName, designationDescription, designationCode, genderId, action, userId);
        }

        /// <summary>
        /// Gets all senate designation.
        /// </summary>
        /// <returns>List&lt;StudentEntity&gt;.</returns>
        public List<StudentEntity> GetAllSenateDesignation()
        {
            //admin = new Admin();
            return houseList = Admin.GetAllSenateDesignation();
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
            //admin = new Admin();
            return Admin.AddUpdateDelSenateDesignation(senateId, senateDesignation, senateDescription, senateCode, genderId, action, userId);
        }

        /// <summary>
        /// Add Update or Delete student from student table
        /// </summary>
        /// <param name="xiStudent">Student Object</param>
        /// <param name="xiOperationMode">Select mode Add Update Delete</param>
        /// <returns></returns>
        public bool AddUpdateDelStudent(StudentEntity xiStudent, string xiOperationMode)
        {
            if (xiOperationMode.ToUpper() == "A")
            {
                //===========================================================
                // We need to explicitly get Current student id so that we 
                // can generate next student id for the insertion, because 
                // mysql doesnt support to autogenrate custome numbers.
                //===========================================================
                int lStudent_ID = Admin.GetCurrentStudentId();

                if (lStudent_ID > 0)
                {
                    xiStudent.Stud_Id = lStudent_ID;

                    xiStudent.Stud_Key = "KL" + lStudent_ID.ToString().Trim();
                }
            }

            return Admin.AddUpdateDelStudent(xiStudent, xiOperationMode);
        }

        public List<StudentEntity> GetAllHouseNominationDetails()
        {
            List<StudentEntity> houseNominationList = new List<StudentEntity>();
            return houseNominationList = Admin.GetAllHouseNominationDetails();
        }

        public bool AddUpdateDelHouseNominationDetails(int houseNominationId, int houseId, int houseDesignationId, int classSectionId, string studentKey, string photoURL, int electionId, string action, int userId)
        {
            return Admin.AddUpdateDelHouseNominationDetails(houseNominationId, houseId, houseDesignationId, classSectionId, studentKey, photoURL, electionId, action, userId);
        }


        public bool AddUpdateDelSenateNominationDetails(int xiSenateNominationId, int xiSenateDesignationId, int xiClassSectionId, string xiStudentKey, string xiPhotoURL, int xiElectionId, string xiAbout, string xiAction, int xiUserId)
        {
            return Admin.AddUpdateDelSenateNominationDetails(xiSenateNominationId, xiSenateDesignationId, xiClassSectionId, xiStudentKey, xiPhotoURL, xiElectionId, xiAbout, xiAction, xiUserId);
        }


        public List<Elections> GetAllHouseElections()
        {
            return Admin.GetAllHouseElections();
        }

        public List<Elections> GetAllSenateElections()
        {
            return Admin.GetAllSenateElections();
        }

        public bool AddUpdateDeleteHouseElections(int xiElectionId, DateTime xiStartDate, DateTime xiEndDate, string xiDescription, string xiMode)
        {
            return Admin.AddUpdateDeleteHouseElections(xiElectionId, xiStartDate, xiEndDate, xiDescription, xiMode);
        }

        public bool AddUpdateDeleteSenateElections(int xiElectionId, DateTime xiStartDate, DateTime xiEndDate, string xiDescription, string xiMode)
        {
            return Admin.AddUpdateDeleteSenateElections(xiElectionId, xiStartDate, xiEndDate, xiDescription, xiMode);
        }

        #region ClassSection

        public List<ClassSection> GetAllClasses()
        {
            return Admin.GetAllClasses();
        }

        public List<ClassSection> GetAllSections()
        {
            return Admin.GetAllSections();
        }

        public List<ClassSection> GetAllClassSection()
        {
            return Admin.GetAllClassSection();
        }

        public bool AddUpdateDelClassAndSection(ClassSection classSectionEntity)
        {
            return Admin.AddUpdateDelClassAndSection(classSectionEntity);
        }

        #endregion ClassSection
    }
}
