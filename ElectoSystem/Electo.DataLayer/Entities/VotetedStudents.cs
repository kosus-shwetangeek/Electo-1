using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electo.DataLayer.Entities
{
    public class VotetedStudents
    {
        private int vst_Id;
        private string vst_StudentKey;
        private bool vst_IVFHouse;
        private bool vst_IVFGamesCap;
        private bool vst_IVFGamesViceCap;
        private bool vst_IVFPrefect;
        private bool vst_IVFVicePrefect;
        private bool vst_IVFJuniorPrefect;
        private bool vst_IVFHeadGirl;
        private bool vst_IVFHeadBoy;
        private bool vst_IVFSenate;

        public bool Vst_IVFSenate
        {
            get { return vst_IVFSenate; }
            set { vst_IVFSenate = value; }
        }

        public bool Vst_IVFPrefect
        {
            get { return vst_IVFPrefect; }
            set { vst_IVFPrefect = value; }
        }

        public bool Vst_IVFVicePrefect
        {
            get { return vst_IVFVicePrefect; }
            set { vst_IVFVicePrefect = value; }
        }

        public bool Vst_IVFJuniorPrefect
        {
            get { return vst_IVFJuniorPrefect; }
            set { vst_IVFJuniorPrefect = value; }
        }

        public bool Vst_IVFHeadBoy
        {
            get { return vst_IVFHeadBoy; }
            set { vst_IVFHeadBoy = value; }
        }

        public bool Vst_IVFHeadGirl
        {
            get { return vst_IVFHeadGirl; }
            set { vst_IVFHeadGirl = value; }
        }

        Nominees nomiees;

        public Nominees Nomiees
        {
            get { return nomiees; }
            set { nomiees = value; }
        }


        public bool Vst_IVFGamesViceCap
        {
            get { return vst_IVFGamesViceCap; }
            set { vst_IVFGamesViceCap = value; }
        }

        public bool Vst_IVFGamesCap
        {
            get { return vst_IVFGamesCap; }
            set { vst_IVFGamesCap = value; }
        }

        public bool Vst_IVFHouse
        {
            get { return vst_IVFHouse; }
            set { vst_IVFHouse = value; }
        }

        public string Vst_StudentKey
        {
            get { return vst_StudentKey; }
            set { vst_StudentKey = value; }
        }

        public int Vst_Id
        {
            get { return vst_Id; }
            set { vst_Id = value; }
        }
    }
}
