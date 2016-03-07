using System;
using System.Collections.Generic;
using Electo.DataLayer.Entities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Electo.BusinessLayer.Implementation
{
    public class Authentication
    {
        Electo.DataLayer.Implementation.Authentication lAuthentication = new DataLayer.Implementation.Authentication();
        Nominees studNom = new Nominees();
        StudentEntity studentSession = new StudentEntity();
        //Electo.DataLayer.Entities.StaffEntity staffSession = new StaffEntity();
        List<StudentEntity> studentSessionList = new List<StudentEntity>();
        //Electo.DataLayer.Entities.StaffEntity StaffSession = new StaffEntity();
        //List<StaffEntity> StaffSessionList = new List<StaffEntity>();
        /// <summary>
        /// Gets all student.
        /// </summary>
        /// <returns>DataTable.</returns>
        public List<StudentEntity> GetAllStudent()
        {
            //authentication = new DataLayer.Implementation.Authentication();
            return studentSessionList = lAuthentication.GetAllStudent();
        }
        /// <summary>
        /// Gets all staff.
        /// </summary>
        /// <returns>DataTable.</returns>
       // public List<StaffEntity> GetAllStaff()
        //{
            //authentication = new DataLayer.Implementation.Authentication();
          //  return StaffSessionList = lAuthentication.GetAllStaff();
        //}


        /// <summary>
        /// Gets the student by election identifier.
        /// </summary>
        /// <param name="ElectionId">The election identifier.</param>
        /// <returns>Nominees.</returns>
        public Nominees GetStudentByElectionId(string ElectionId)
        {
            //authentication = new DataLayer.Implementation.Authentication();
            return studNom = lAuthentication.GetStudentByElectionId(ElectionId);
        }

        /// <summary>
        /// Checks the student exist.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns>StudentEntity.</returns>
        public StudentEntity CheckStudentExist(string UserName, string Password)
        {
            //authentication = new DataLayer.Implementation.Authentication();
            return studentSession = lAuthentication.CheckStudentExist(UserName, Password);
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
            //authentication = new DataLayer.Implementation.Authentication();
            return lAuthentication.UpdateResetPassword(UserName, Password, DoB);
        }


        public StudentEntity GetUserSession(string UserName, string UserType)
        {
            //authentication = new DataLayer.Implementation.Authentication();
            return studentSession = lAuthentication.GetUserSession(UserName, UserType);
        //    public StaffEntity CheckStaffExist(string UserName, string Password)
        //{
        //    //authentication = new DataLayer.Implementation.Authentication();
        //    return StaffSession = lAuthentication.CheckStudentExist(UserId, Password);
        //}
        //public bool UpdateResetPassword(string UserName, string Password, DateTime DoB)
        //{
        //    //authentication = new DataLayer.Implementation.Authentication();
        //    return lAuthentication.UpdateResetPassword(UserName, Password, DoB);
        //}


        //public StaffEntity GetUserSession(string UserName, string UserType      
        //{
        //    //authentication = new DataLayer.Implementation.Authentication();
        //    return StaffSession = lAuthentication.GetUserSession(UserName, UserType);
        //}


        }
    }
}
