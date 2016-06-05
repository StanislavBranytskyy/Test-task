using System;
using System.Diagnostics;
using System.Net;
using System.Web.Http;
using Canberra.TestTask.Codebase.Common;
using Canberra.TestTask.Codebase.Contracts;
using Canberra.TestTask.Codebase.Models;
using Canberra.TestTask.Codebase.Repositories;

namespace Canberra.TestTask.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IRepository<Employee> _employeeRepository = new EmployeeRepository();

        [HttpPost]
        [Route("query")]
        public PagedCollection<Employee> Query(PagedCollectionQuery query)
        {
            if (query == null)
               throw new HttpResponseException(HttpStatusCode.BadRequest);

            return _employeeRepository.Query(query);
        }
    }
}
