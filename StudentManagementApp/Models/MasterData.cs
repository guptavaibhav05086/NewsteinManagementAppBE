using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Models
{
    public class MasterData
    {
        public List<MasterCourseDetails> courseDetails { get; set; }

        public List<MasterBatchDetails> batchDetails { get; set; }
        public List<MasterModuleData> moduleDetails { get; set; }
    }
}