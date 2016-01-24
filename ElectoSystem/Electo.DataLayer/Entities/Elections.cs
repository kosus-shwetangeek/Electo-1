using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electo.DataLayer.Entities
{
    public class Elections
    {
        int lElectionId;
        DateTime lStartDate;
        DateTime lEndDate;
        string lElectionType;
        string lIsInUse;
        private string lDescription;

        public string Description
        {
            get { return lDescription; }
            set { lDescription = value; }
        }

        public string IsInUse
        {
            get { return lIsInUse; }
            set { lIsInUse = value; }
        }

        public int ElectionId
        {
            get { return lElectionId; }
            set { lElectionId = value; }
        }

        public DateTime StartDate
        {
            get { return lStartDate; }
            set { lStartDate = value; }
        }

        public DateTime EndDate
        {
            get { return lEndDate; }
            set { lEndDate = value; }
        }

        public string ElectionType
        {
            get { return lElectionType; }
            set { lElectionType = value; }
        }
    }
}