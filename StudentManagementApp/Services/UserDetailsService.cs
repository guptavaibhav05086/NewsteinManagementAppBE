using StudentManagementApp.Models;
using StudentManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Services
{
    public class UserDetailsService
    {
        public StudentProfileResponse GetUserDetails(string studentId)
        {
            StudentProfileResponse response = new StudentProfileResponse();
            UserDetailsModel user = null;
            List<SessionDetailsModel> sessionDetails = null;
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                user = (from a in dbContext.Students
                              where a.RegistrationId == studentId
                              select new UserDetailsModel
                              {
                                  courseDetails= a.CourseDetail.CourseName,
                                  totalFees=a.CourseDetail.CourseFees,
                                  feesPaid=a.FeesPaid,                                 
                                  instructorName = a.BatchDeatil.Instructorname,
                                  moduleName= a.BatchDeatil.Module.ModuleName,
                                  userName= a.StudentName,
                                  moduleId=a.BatchDeatil.Module.ModuleId,
                                  dateOfJoining = a.DateOfJoining,
                                  dateOfPayment=a.DateOfPayment,
                                  dueDate = a.DueDate
                              }).FirstOrDefault();

                sessionDetails = (from a in dbContext.SessionDetails where a.ModuleId == user.moduleId select new SessionDetailsModel {
                    sessionName = a.SessionName,
                    sessionTopics = a.SessionTopics,
                    sessionResources=a.SessionResources
                }).ToList();
            }
            response.sessionDetails = sessionDetails;
            response.userDetails = user;
            return response;
        }
    }
}