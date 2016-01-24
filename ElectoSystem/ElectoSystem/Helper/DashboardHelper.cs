using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectoSystem.Helper
{
    ///======================================================================
    /// Class: DashboardHelper
    /// <summary>
    /// DashboardHelper will help to fetch value from database
    /// </summary>
    /// <returns></returns>
    ///======================================================================
    public class DashboardHelper
    {
        DashboardEntities dashboardEF;

        ///======================================================================
        /// Method: GetActiveHouseElectionsCount
        /// <summary>
        /// This method will return the active election counts which represents,
        /// ongoing elections. It may contain multiple types of house elections.
        /// </summary>
        /// <returns></returns>
        ///======================================================================
        protected internal int GetActiveHouseElectionsCount()
        {
            return 0;
        }

        ///======================================================================
        /// Method: GetActiveSenateElectionsCount
        /// <summary>
        /// This method will return the active election counts which represents,
        /// ongoing elections. It may contain multiple types of senate elections.
        /// </summary>
        /// <returns></returns>
        ///======================================================================
        protected internal int GetActiveSenateElectionsCount()
        {
            return 0;
        }

        ///======================================================================
        /// Method: GetActiveSenateElectionsCount
        /// <summary>
        /// This method will return the active election counts which represents,
        /// ongoing elections. It may contain multiple types of senate elections.
        /// </summary>
        /// <returns></returns>
        ///======================================================================
        protected internal int GetAHouseNomineesCount()
        {
            return 0;
        }
    }
}