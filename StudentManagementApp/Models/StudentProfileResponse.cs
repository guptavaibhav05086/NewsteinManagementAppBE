using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Models
{
    public class StudentProfileResponse
    {
        public UserDetailsModel userDetails { get; set; }
        public List<SessionDetailsModel> sessionDetails { get; set; }
    }
}