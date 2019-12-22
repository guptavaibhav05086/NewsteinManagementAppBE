using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Models
{
    public class MasterBatchDetails
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public DateTime BatchStartDate { get; set; }

        public int? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int SessionId { get; set; }
        public string Instructorname { get; set; }
        public DateTime? SessionDate { get; set; }
    }
}