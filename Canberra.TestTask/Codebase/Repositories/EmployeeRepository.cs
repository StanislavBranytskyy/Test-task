using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Antlr.Runtime.Misc;
using Canberra.TestTask.Codebase.Common;
using Canberra.TestTask.Codebase.Contracts;
using Canberra.TestTask.Codebase.DataContext;
using Canberra.TestTask.Codebase.Models;

namespace Canberra.TestTask.Codebase.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private static readonly Sorting DefaultSorting = new Sorting { Property = "FullName", Direction = SortDirection.Ascending };

        private readonly MockedDataContext _context = new MockedDataContext();


        public PagedCollection<Employee> Query(PagedCollectionQuery query)
        {
            var errors = query.Validate(new ValidationContext(query));
            if (errors.Any())
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            if (query.Pagination == null)
                query.Pagination = Pagination.Default;

            if (query.Sorting == null || string.IsNullOrEmpty(query.Sorting.Property))
                query.Sorting = DefaultSorting;

            var items = _context.Persons;

            var pagedCollection = new PageFactory().GetPagedList(items, query);

            if (pagedCollection == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return pagedCollection;
        }

    }
}