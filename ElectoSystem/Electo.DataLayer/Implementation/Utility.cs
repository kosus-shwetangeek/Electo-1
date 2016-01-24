using Electo.Constants;
using Kosus.DataAccess.MySql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electo.DataLayer.Implementation
{
    ///====================================================================
    /// Class : Utility
    /// <summary>
    /// This class contains methods for Logging exception to database, 
    /// Email sending programs and other common functions used all over 
    /// Electo.
    /// </summary>
    ///====================================================================
    public class Utility
    {

        ///====================================================================
        /// <summary>
        /// we are calling Data Aceess methods to store error into database.
        /// </summary>
        /// <param name="xiSeverityLevelId"></param>
        /// <param name="xiExceptionMessage"></param>
        ///====================================================================
        public bool LogError(int xiSeverityLevelId, string xiExceptionMessage)
        {
            bool lIsSuccess = false;

            try
            {
                using (MultiCon mySqlHelper = new MultiCon(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                {
                    lIsSuccess = mySqlHelper.SendQuery(CommandType.StoredProcedure,
                                            ProcedureConstant.SPLoggError,
                                            new ParameterData("piSeverityId", (int)ENums.EWSSeverity.Error),
                                            new ParameterData("piDescription", xiExceptionMessage.ToString())) > 0;
                }
            }
            catch(Exception)
            {
                return false;
            }

            return lIsSuccess;
        }
    }
}
