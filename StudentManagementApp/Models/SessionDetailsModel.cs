using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Models
{
    public class SessionDetailsModel
    {
        public string sessionName {get;set;}
        public string sessionTopics { get; set; }
        public string sessionResources { get; set; }

        public string sessionDate { get; set; }
    }
}