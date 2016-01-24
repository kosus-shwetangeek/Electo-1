using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electo.DataLayer.Implementation;

namespace Electo.BusinessLayer.Implementation
{
    ///====================================================================
    /// Class : Utility
    /// <summary>
    /// This class contains methods for Logging exception to database, 
    /// Email sending programs and other common functions used all over 
    /// Electo.
    /// </summary>
    ///====================================================================
    public class UtilityBusiness
    {

        #region member variables

        Utility mUtility = new Utility();

        #endregion

        ///====================================================================
        /// <summary>
        /// Business logic is applicable only to scope of the fucntion. 
        /// After businesss logic we are calling DataLayer for Data Stoarge 
        /// section.
        /// 
        /// TO DO: We need to apply check loop on Data Layer Method for status,
        /// so that if any case database isn't working at all we can store 
        /// error messages on text file.
        /// 
        /// Remember we are only writting error messages only if database isn't
        /// working.
        /// </summary>
        /// <param name="xiSeverityLevelId"></param>
        /// <param name="xiExceptionMessage"></param>
        ///====================================================================
        public void LogError(int xiSeverityLevelId, string xiExceptionMessage)
        {
            mUtility.LogError(xiSeverityLevelId, xiExceptionMessage);
        }
    }
}
