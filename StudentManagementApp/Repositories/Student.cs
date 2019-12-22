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
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.MissedSessions = new HashSet<MissedSession>();
            this.Finances = new HashSet<Finance>();
        }
    
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string PhotoLink { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<System.DateTime> DateOfJoining { get; set; }
        public string CurrentStatus { get; set; }
        public int FeesPaid { get; set; }
        public Nullable<System.DateTime> DateOfPayment { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string RegistrationId { get; set; }
    
        public virtual BatchDeatil BatchDeatil { get; set; }
        public virtual CourseDetail CourseDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MissedSession> MissedSessions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Finance> Finances { get; set; }
    }
}
