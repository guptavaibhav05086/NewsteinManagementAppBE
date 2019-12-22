using StudentManagementApp.Models;
using StudentManagementApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace StudentManagementApp.Controllers
{
    public class StudentsController : ApiController
    {
        UserDetailsService services = null;

        [EnableCors("*", "*", "*")]
        [Route("api/Students/GetUserProfile")]
        [HttpGet]
        public StudentProfileResponse GetUserProfile(string studentId)
        {
            StudentProfileResponse user = null;
            try
            {
                services = new UserDetailsService();
                user=services.GetUserDetails(studentId);
                
            }
            catch (Exception ex)
            {

                
            }
            return user;
        }


    }
}
