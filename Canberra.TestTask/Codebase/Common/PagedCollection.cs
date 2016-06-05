using System.Collections.Generic;
using System.Linq;

namespace Canberra.TestTask.Codebase.Common
{
    public class PagedCollection<T>
    {
        public PagedCollection(IEnumerable<T> items, int count, PagedCollectionQuery paging)
        {
            TotalCount = count;
            Items = items.ToList();
            Paging = paging;
        }

        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        public PagedCollectionQuery Paging { get; set; }
    }
}