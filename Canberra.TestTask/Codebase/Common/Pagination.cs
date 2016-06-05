namespace Canberra.TestTask.Codebase.Common
{
    public class Pagination
    {
        public static readonly Pagination Default = new Pagination
        {
            ItemsPerPage = 12,
            Page = 1
        };

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}