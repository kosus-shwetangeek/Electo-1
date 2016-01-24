using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectoSystem.Entities
{
    public class Designation : IEqualityComparer<Designation>
    {
        private int lDesignationId;
        private string lDesignationText;
        private string lDesignationCode;

        public string DesignationCode
        {
            get { return lDesignationCode; }
            set { lDesignationCode = value; }
        }

        public string DesignationText
        {
            get { return lDesignationText; }
            set { lDesignationText = value; }
        }
        

        public int DesignationId
        {
            get { return lDesignationId; }
            set { lDesignationId = value; }
        }
        

        public bool Equals(Designation other)
        {
            if (DesignationId == other.DesignationId && DesignationText == other.DesignationText && DesignationCode == other.DesignationCode)
                return true;

            return false;
        }

        public bool Equals(Designation x, Designation y)
        {
            if ((object)x == null && (object)y == null)
            {
                return true;
            }
            if ((object)x == null || (object)y == null)
            {
                return false;
            }
            return x.DesignationId == y.DesignationId;
        }

        public int GetHashCode(Designation obj)
        {
            int hashDesignation = DesignationId == null ? 0 : DesignationCode.GetHashCode();

            return hashDesignation;
        }
    }
}