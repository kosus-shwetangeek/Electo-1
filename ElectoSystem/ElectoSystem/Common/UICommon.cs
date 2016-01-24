using ElectoSystem.Entities;
using ElectoSystem.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ElectoSystem.Common
{
    public class UICommon
    {
        List<NomineesEntity> allNomineesList;
        DataTable dt;

        internal List<NomineesEntity> FillNominationDetails(int studHouseId, string electType)
        {
            UIHelper studentHelper = new UIHelper();
            dt = new DataTable();
            allNomineesList = new List<NomineesEntity>();
           
            try
            {
                if (electType == "h")
                    allNomineesList = studentHelper.GetHouseNominationsByIdHelp(studHouseId);
                else if (electType == "s")
                    allNomineesList = studentHelper.GetAllSenateNomineesHelp(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allNomineesList;
        }
    }
}