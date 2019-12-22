using StudentManagementApp.Models;
using StudentManagementApp.Repositories;
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
    [Authorize(Roles ="Admin")]
    public class AdminController : ApiController
    {
        AdminServices services = null;
        [EnableCors("*", "*", "*")]
        [Route("api/admin/GetUserProfile")]
        [HttpGet]
        public List<UserDetailsModel> GetStudentsDetails()
        {
            services = new AdminServices();
            return services.GetStudentDetails();
            
        }
        
        [EnableCors("*", "*", "*")]
        [Route("api/admin/GetMasterDetails")]
        [HttpGet]
        public MasterData GetMasterDetails()
        {
            services = new AdminServices();
            return services.GetMasterData();

        }
        [EnableCors("*", "*", "*")]
        [Route("api/admin/GetTransactions")]
        [HttpGet]
        public TransactionResponse GetTransactions()
        {
            services = new AdminServices();
            return services.GetTransactions();

        }
        [EnableCors("*", "*", "*")]
        [Route("api/admin/UpdateStudent")]
        [HttpPost]
        public void UpdateStudent([FromBody] UserDetailsModel userDetails)
        {
            services = new AdminServices();
            services.updateStudent(userDetails);
        }
        [EnableCors("*", "*", "*")]
        [Route("api/admin/CreateStudent")]
        [HttpPost]
        public void CreateStudent([FromBody] UserDetailsModel userDetails)
        {
            services = new AdminServices();
            services.CreateStudent(userDetails);
        }
        [EnableCors("*", "*", "*")]
        [Route("api/admin/CreateUpdateBatch")]
        [HttpPost]
        public void CreateUpdateBatch([FromBody] MasterBatchDetails batchDetails)
        {
            services = new AdminServices();
            services.updateCreateBatch(batchDetails);
        }
        [EnableCors("*", "*", "*")]
        [Route("api/admin/CreateTransactions")]
        [HttpPost]
        public void CreateTransactions([FromBody] Transactions transactions )
        {
            services = new AdminServices();
            services.CreateUpdateTransactions(transactions);
        }
        [EnableCors("*", "*", "*")]
        [Route("api/admin/UpdateTransaction")]
        [HttpPost]
        public void UpdateTransaction([FromBody] Transactions transactions)
        {
            services = new AdminServices();
            services.UpdateTransaction(transactions);
        }
        [EnableCors("*", "*", "*")]
        [Route("api/admin/GetHomePageResponse")]
        [HttpGet]
        public HomePageResponse GetHomePageResponse()
        {
            services = new AdminServices();
            return services.GetHomePageSummary();
        }

    }
}
