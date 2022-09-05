//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineVaccineSystem.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class VaccineCenter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VaccineCenter()
        {
            this.AppoimentMasters = new HashSet<AppoimentMaster>();
            this.CenterSlots = new HashSet<CenterSlot>();
        }
    
        public int Id { get; set; }
        public string CenterName { get; set; }
        public string CenterState { get; set; }
        public string CenterDistict { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppoimentMaster> AppoimentMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CenterSlot> CenterSlots { get; set; }
    }
}
