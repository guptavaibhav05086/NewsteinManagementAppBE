using StudentManagementApp.Models;
using StudentManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp.Services
{
    public class AdminServices
    {
        public void updateCreateBatch(MasterBatchDetails batchDetails)
        {
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                try
                {
                    BatchDeatil newBatch = dbContext.BatchDeatils.Find(batchDetails.BatchId);
                   
                         newBatch = newBatch ==null? new BatchDeatil():newBatch;
                    
                    newBatch.BatchName = batchDetails.BatchName;
                    newBatch.BatchStartDate = batchDetails.BatchStartDate;
                    newBatch.Instructorname = batchDetails.Instructorname;
                    newBatch.ModuleId = batchDetails.ModuleId;
                    if(newBatch.BatchId == 0)
                    {
                        dbContext.BatchDeatils.Add(newBatch);
                    }
                    dbContext.SaveChanges();



                }
                catch (Exception ex)
                {

                    
                }
            }
        }

        public void CreateStudent(UserDetailsModel userDetails)
        {
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                try
                {
                    var student = new Student();
                    student.StudentName = userDetails.userName;
                    student.FeesPaid = (int)userDetails.feesPaid;
                    student.CourseId = userDetails.courseId;
                    student.RegistrationId = userDetails.RegistrationId;
                    //if(student.FeesPaid != (int)userDetails.feesPaid)
                    //{

                    //}
                    student.BatchId = userDetails.batchId;
                    student.DateOfJoining = userDetails.dateOfJoining;
                    student.DateOfPayment = userDetails.dateOfPayment;
                    student.DueDate = userDetails.dueDate;
                    student.CurrentStatus = userDetails.status;
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {


                }

            }
        }
        public void updateStudent(UserDetailsModel userDetails)
        {
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                try
                {
                    var student = dbContext.Students.Find(userDetails.studentId);
                    student.StudentName = userDetails.userName;
                    student.FeesPaid = (int)userDetails.feesPaid;
                    //if(student.FeesPaid != (int)userDetails.feesPaid)
                    //{

                    //}
                    student.BatchId = userDetails.batchId;
                    student.DateOfJoining = userDetails.dateOfJoining;
                    student.DateOfPayment = userDetails.dateOfPayment;
                    student.DueDate = userDetails.dueDate;
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {

                   
                }
               
            }
        }

        public void UpdateTransaction(Transactions transaction)
        {
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                
                try
                {

                    //using(var transaction = dbContext.conn)
                    Finance newtransaction = dbContext.Finances.Find(transaction.TransactionId);
                    
                   
                   
                    newtransaction.Comment = transaction.Comment;
                    if(transaction.StudentId != null)
                    {
                        if(transaction.TransactionType == "Credit")
                        newtransaction.Student.FeesPaid = (int)(newtransaction.Student.FeesPaid - newtransaction.Amount + transaction.Amount);
                        else
                            newtransaction.Student.FeesPaid = (int)(newtransaction.Student.FeesPaid - transaction.Amount);
                        newtransaction.PaidBy = newtransaction.Student.StudentName;
                    }
                    else
                    {
                        newtransaction.PaidBy = transaction.PaidBy;
                    }
                    newtransaction.Amount = transaction.Amount;
                    newtransaction.PaidTo = transaction.PaidTo;
                    newtransaction.TransactionDate = DateTime.Now;
                    newtransaction.TransactionMode = transaction.TransactionMode;
                    newtransaction.StudentId = transaction.StudentId;
                    newtransaction.TransactionType = transaction.TransactionType;
                    newtransaction.CreateBy = "Admin";
                   

                    dbContext.SaveChanges();
                   
                }
                catch (Exception ex)
                {
                   // begintransaction.Rollback();

                }



            }
        }
        public void CreateUpdateTransactions(Transactions transaction)
        {
            
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                dbContext.Database.Connection.Open();
                var begintransaction = dbContext.Database.BeginTransaction();
                try
                {
                    
                    //using(var transaction = dbContext.conn)
                    Finance newtransaction = new Finance();
                    newtransaction.Amount = transaction.Amount;
                    newtransaction.Comment = transaction.Comment;
                   
                   
                    newtransaction.PaidTo = transaction.PaidTo;
                    newtransaction.TransactionDate = DateTime.Now;
                    newtransaction.TransactionMode = transaction.TransactionMode;
                    newtransaction.StudentId = transaction.StudentId;
                    newtransaction.TransactionType = transaction.TransactionType;
                    newtransaction.CreateBy = "Admin";
                    dbContext.Finances.Add(newtransaction);

                    if(transaction.StudentId != null)
                    {
                        newtransaction.PaidBy = updateStudentFees(transaction.StudentId, dbContext,transaction);
                    }                    
                    else
                    {
                        newtransaction.PaidBy = transaction.PaidBy;

                    }

                    dbContext.SaveChanges();
                    begintransaction.Commit();
                }
                catch (Exception ex)
                {
                    begintransaction.Rollback();
                    
                }
                


            }

        }

        private string updateStudentFees(int? studentId, StudentManagementPortalEntities dbContext,Transactions transaction)
        {
            //using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            //{
                decimal totalfees = 0;
                var studentsData = (from a in dbContext.Finances where a.StudentId == studentId select a);
                foreach (var item in studentsData)
                {
                    if(item.TransactionType == "Credit")
                    {
                        totalfees += item.Amount;

                    }
                    else if (item.TransactionType == "Debit")
                    {
                        totalfees -= item.Amount;
                    }
                }
            totalfees = totalfees + transaction.Amount;
                var student = dbContext.Students.Find(studentId);
                if(student != null)
                {
                    student.FeesPaid =(int) totalfees;
                }

            return student.StudentName;
            //}
        }
        //public void CreateTransaction(int amount,int studentId,string studentName)
        //{
        //    using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
        //    {
        //        Finance transaction = new Finance();
        //        transaction.Amount = amount;
        //        transaction.Comment = "Enterned via Fees Details";
        //        transaction.PaidBy = studentName;
        //        transaction.PaidTo = "Newstein";
        //        transaction.TransactionDate = DateTime.Now;
        //        transaction.TransactionMode = "Bank Transfer";

        //    }
        //}

        public TransactionResponse GetTransactions()
        {
            TransactionResponse response = new TransactionResponse();
            List < Transactions > transactions= null;
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                transactions = (from a in dbContext.Finances select new Transactions {
                    TransactionId = a.TransactionId,
                    TransactionMode = a.TransactionMode,
                    Amount=a.Amount,
                    CreateBy=a.CreateBy,
                    Comment=a.Comment,
                    TransactionDate=a.TransactionDate,
                    TransactionType=a.TransactionType,
                    PaidBy=a.PaidBy,
                    PaidTo=a.PaidTo,
                    StudentId=a.StudentId
                }).ToList();

                response.transactions = transactions;
                response.students = (from a in dbContext.Students select new UserDetailsModel {
                    studentId = a.StudentId,
                    userName = a.StudentName
                }).ToList();

                
            }
            return response;
        
        }
        public List<UserDetailsModel> GetStudentDetails()
        {
            List<UserDetailsModel> response = new List<UserDetailsModel>();
            //UserDetailsModel user = null;

            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                response = (from a in dbContext.Students

                        select new UserDetailsModel
                        {
                            studentId = a.StudentId,
                            courseDetails = a.CourseDetail.CourseName,
                            courseId=a.CourseId,
                            totalFees = a.CourseDetail.CourseFees,
                            feesPaid = a.FeesPaid,
                            instructorName = a.BatchDeatil.Instructorname,
                            moduleName = a.BatchDeatil.Module.ModuleName,
                            userName = a.StudentName,
                            moduleId = a.BatchDeatil.Module.ModuleId,
                            dateOfJoining = a.DateOfJoining,
                            dateOfPayment = a.DateOfPayment,
                            dueDate = a.DueDate,
                            batchId=a.BatchId,
                            status = a.CurrentStatus
                        }).ToList();


            }

            
            return response;
        }

        public HomePageResponse GetHomePageSummary()
        {
            HomePageResponse response = new HomePageResponse();
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                var ownerDetails = new string[] { "Anish", "Lavish", "Vaibhav", "Gaurav" };
                
                var data = (from a in dbContext.Finances
                            group a by a.TransactionType into c
                            select new
                            {
                                Type = c.Key,
                                Sum = c.Sum(pc => pc.Amount)
                            });
                response.totalFinances = new Dictionary<string, decimal>();
                foreach (var item in data)
                {

                    response.totalFinances.Add(item.Type, item.Sum);
                }
                
                
                var ownerLibabilty = (from a in dbContext.Finances where ownerDetails.Contains(a.PaidTo)   group a by a.PaidTo into c select new {
                    Type=c.Key,
                    sum=c.Sum(pc=>pc.Amount)
                } );

                response.totalLibality = new Dictionary<string, decimal>();
                foreach (var item in ownerLibabilty)
                {
                    response.totalLibality.Add(item.Type, item.sum);
                }

                var students = (from a in dbContext.Students where a.CurrentStatus == "Active"   select a).ToList();
                response.totalActiveStudents = new Dictionary<string, decimal>();
                response.totalActiveStudents.Add("TotalActiveStudents", students.Count);
                var dueDate = students.Where(item => item.DueDate > DateTime.Now).ToList();
                response.dueDatePassed = new Dictionary<string, decimal>();
                response.dueDatePassed.Add("DueDateCount", dueDate.Count);
            }
            return response;
        }
        public MasterData GetMasterData()
        {
            MasterData data = new MasterData();
            using (StudentManagementPortalEntities dbContext = new StudentManagementPortalEntities())
            {
                data.batchDetails = (from a in dbContext.BatchDeatils
                                     select new MasterBatchDetails
                                     {
                                         BatchId = a.BatchId,
                                         BatchName = a.BatchName,
                                         BatchStartDate = a.BatchStartDate,
                                         Instructorname = a.Instructorname,
                                         ModuleId = a.ModuleId,
                                         SessionDate = a.SessionDate,
                                         ModuleName=a.Module.ModuleName

                                     }).ToList();
                data.courseDetails = (from a in dbContext.CourseDetails select new MasterCourseDetails { CourseFess = a.CourseFees,CourseId = a.CourseId,CourseName = a.CourseName }).ToList();
                data.moduleDetails = (from a in dbContext.Modules
                                      select new MasterModuleData
                                      {
                                          ModuleId = a.ModuleId,
                                          ModuleName = a.ModuleName
                                      }).ToList();
            }

             return data;
        }
    }
}