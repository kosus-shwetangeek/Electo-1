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
    
    public partial class tacademicyear
    {
        public int Acy_Id { get; set; }
        public string Acy_AcademicYear { get; set; }
        public System.DateTime Acy_StartDate { get; set; }
        public System.DateTime Acy_EndDate { get; set; }
        public bool Acy_IsActive { get; set; }
        public Nullable<bool> Acy_IsDeleted { get; set; }
        public Nullable<System.DateTime> Acy_DeletedDate { get; set; }
        public Nullable<int> Acy_DeletedBy { get; set; }
        public Nullable<System.DateTime> Acy_LastUpdatedDate { get; set; }
        public Nullable<int> Acy_LastUpdatedBy { get; set; }
    }
}
