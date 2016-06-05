using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Canberra.TestTask.Codebase.Common
{
    public class PagedCollectionQuery : IValidatableObject
    {
        public PagedCollectionQuery()
        {
            Pagination = Pagination.Default;
            Sorting = null;
        }

        public Pagination Pagination { get; set; }
        public Sorting Sorting { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Sorting != null && (Sorting.Direction != SortDirection.Ascending || Sorting.Direction != SortDirection.Descending))
            {
                yield return new ValidationResult("Sort order is unacceptable");
            }
            else if (Sorting != null && (Sorting.Property != "FullName" || Sorting.Property != "Gender"))
            {
                yield return new ValidationResult(string.Format("Field {0} is not acceptable", Sorting.Property));
            }
        }
    }
}