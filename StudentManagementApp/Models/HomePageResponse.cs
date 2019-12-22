using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Models
{
    public class HomePageResponse
    {
        public Dictionary<string, decimal> totalFinances;
        public Dictionary<string, decimal> totalLibality;
        public Dictionary<string, decimal> totalActiveStudents;
        public Dictionary<string, decimal> dueDatePassed;


    }
}