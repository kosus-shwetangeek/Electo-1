//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectoSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class tsenatenomination
    {
        public int Snn_Id { get; set; }
        public Nullable<int> Snn_SenateDesignationId { get; set; }
        public Nullable<int> Snn_ClassSectionId { get; set; }
        public string Snn_studKey { get; set; }
        public Nullable<int> Snn_VoteCount { get; set; }
        public string Snn_Photo { get; set; }
        public string Snn_AboutNominee { get; set; }
        public Nullable<bool> Snn_IsDeleted { get; set; }
        public Nullable<System.DateTime> Snn_DeletedDate { get; set; }
        public Nullable<int> Snn_DeletedBy { get; set; }
        public Nullable<System.DateTime> Snn_LastUpdatedDate { get; set; }
        public Nullable<int> Snn_LastUpdatedBy { get; set; }
        public int Snn_SenateElectionId { get; set; }
    
        public virtual tsenatedesignation tsenatedesignation { get; set; }
        public virtual tsenateelection tsenateelection { get; set; }
        public virtual tstudent tstudent { get; set; }
    }
}