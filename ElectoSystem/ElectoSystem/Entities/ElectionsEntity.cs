using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectoSystem.Entities
{
    public class ElectionsEntity
    {
        int lElectionId;
        DateTime lStartDate;
        DateTime lEndDate;
        string lElectionType;
        string lIsInUse;
        string lDescription;
        string lStatus;


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


        public string Status
        {
            get { return lStatus; }
            set { lStatus = value; }
        }

        public string Description
        {
            get { return lDescription; }
            set { lDescription = value; }
        }
    }
}