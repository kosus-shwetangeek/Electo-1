using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electo.DataLayer.Entities
{
    class VotedStaff
    {
        private int vst_Id;
        private string vst_StaffKey;

        public string Vst_StudentKey
        {
            get { return vst_StaffKey; }
            set { vst_StaffKey = value; }
        }

        public int Vst_Id
        {
            get { return vst_Id; }
            set { vst_Id = value; }
        }


    }
}
