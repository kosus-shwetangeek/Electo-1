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
    
    public partial class thousenomination
    {
        public int Hsn_Id { get; set; }
        public Nullable<int> Hsn_HouseId { get; set; }
        public Nullable<int> Hsn_HouseDesignationId { get; set; }
        public Nullable<int> Hsn_ClassSectionId { get; set; }
        public string Hsn_studKey { get; set; }
        public Nullable<int> Hsn_VoteCount { get; set; }
        public string Hsn_Photo { get; set; }
        public string Hsn_AboutNominee { get; set; }
        public Nullable<bool> Hsn_IsDeleted { get; set; }
        public Nullable<System.DateTime> Hsn_DeletedDate { get; set; }
        public Nullable<int> Hsn_DeletedBy { get; set; }
        public Nullable<System.DateTime> Hsn_LastUpdatedDate { get; set; }
        public Nullable<int> Hsn_LastUpdatedBy { get; set; }
        public int Hsn_HouseElectionId { get; set; }
    
        public virtual thousedesignation thousedesignation { get; set; }
        public virtual thouseelection thouseelection { get; set; }
        public virtual thous thous { get; set; }
        public virtual tstudent tstudent { get; set; }
    }
}
