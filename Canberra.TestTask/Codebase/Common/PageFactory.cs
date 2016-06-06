using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Canberra.TestTask.Codebase.Common
{
    public class PageFactory
    {
        public PagedCollection<T> GetPagedList<T>(IQueryable<T> query, PagedCollectionQuery paging)
        {
            if (paging == null || query == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(paging.Sorting.Property))
            {
                paging.Sorting.Property = typeof(T)
                    .GetProperties()
                    .First(p => p.PropertyType == typeof(string))
                    .Name;
            }

            var parameter = Expression.Parameter(typeof(T), "x");

            var command = paging.Sorting.Direction == SortDirection.Descending ? "OrderByDescending" : "OrderBy";

            PropertyInfo property = typeof(T).GetProperty(paging.Sorting.Property);
            MemberExpression member = Expression.MakeMemberAccess(parameter, property);

            var orderByExpression = Expression.Lambda(member, parameter);

            Expression resultExpression = Expression.Call(
                typeof(Queryable),
                command,
                new Type[] { typeof(T), property.PropertyType },
                query.Expression,
                Expression.Quote(orderByExpression));

            query = query.Provider.CreateQuery<T>(resultExpression);

            var count = query.Count();

            query = query.Skip(paging.Pagination.Page * paging.Pagination.ItemsPerPage)
                .Take(paging.Pagination.ItemsPerPage);

            return new PagedCollection<T>(query.AsEnumerable(), count, paging);
        }
    }
}
