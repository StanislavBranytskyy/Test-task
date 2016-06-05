using System.Linq;
using Canberra.TestTask.Codebase.Common;

namespace Canberra.TestTask.Codebase.Contracts
{
    public interface IRepository<T>
    {
        PagedCollection<T> Query(PagedCollectionQuery query);
    }
}