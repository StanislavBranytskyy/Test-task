using System;

namespace Canberra.TestTask.Codebase.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FullName
        {
            get
            {
                return ((Name ?? string.Empty) + " " + (Surname ?? string.Empty)).Trim();
            }
        }

        public Gender Gender { get; set; }
    }
}