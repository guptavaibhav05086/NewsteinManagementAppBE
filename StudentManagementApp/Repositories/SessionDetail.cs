//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagementApp.Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class SessionDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SessionDetail()
        {
            this.BatchDeatils = new HashSet<BatchDeatil>();
            this.MissedSessions = new HashSet<MissedSession>();
        }
    
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string SessionTopics { get; set; }
        public string SessionResources { get; set; }
        public Nullable<int> ModuleId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchDeatil> BatchDeatils { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MissedSession> MissedSessions { get; set; }
        public virtual Module Module { get; set; }
    }
}
