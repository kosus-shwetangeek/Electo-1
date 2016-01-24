using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electo.DataLayer.Entities
{
    public class ClassSection : IDisposable
    {
        ~ClassSection()
        {

        }

        private string action;
        private string type;
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        #region Class

        private string class_IsInUse;
        private int classId;
        private string className;
        private string displayClassName;

        public string Class_IsInUse
        {
            get { return class_IsInUse; }
            set { class_IsInUse = value; }
        }

        public int ClassId
        {
            get { return classId; }
            set { classId = value; }
        }

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public string DisplayClassName
        {
            get { return displayClassName; }
            set { displayClassName = value; }
        }

        #endregion Class

        #region Section

        private string section_IsInUse;
        private int sectionId;
        private string sectionName;
        private string displaySectionName;

        public string Section_IsInUse
        {
            get { return section_IsInUse; }
            set { section_IsInUse = value; }
        }

        public int SectionId
        {
            get { return sectionId; }
            set { sectionId = value; }
        }

        public string SectionName
        {
            get { return sectionName; }
            set { sectionName = value; }
        }

        public string DisplaySectionName
        {
            get { return displaySectionName; }
            set { displaySectionName = value; }
        }

        #endregion Section

        #region ClassSection

        private string classSection_IsInUse;
        private int classSectionId;
        private string classSectionName;
        private string displayClassSectionName;

        public string ClassSection_IsInUse
        {
            get { return classSection_IsInUse; }
            set { classSection_IsInUse = value; }
        }

        public int ClassSectionId
        {
            get { return classSectionId; }
            set { classSectionId = value; }
        }

        public string ClassSectionName
        {
            get { return classSectionName; }
            set { classSectionName = value; }
        }

        public string DisplayClassSectionName
        {
            get { return displayClassSectionName; }
            set { displayClassSectionName = value; }
        }

        #endregion ClassSection

        public void Dispose()
        {
            //this.Dispose();
        }
    }
}
