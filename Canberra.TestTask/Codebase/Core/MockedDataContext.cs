using System;
using System.Collections.Generic;
using System.Linq;
using Canberra.TestTask.Codebase.Core;
using Canberra.TestTask.Codebase.Models;

namespace Canberra.TestTask.Codebase.DataContext
{
    public class MockedDataContext
    {
        private const int Seed = 6534;
        private const int Count = 546;
        private readonly List<Employee> _collection;

        public MockedDataContext()
        {
            var random = new Random(Seed);
            var generator = new EmployeeGenerator(random);

            _collection = Enumerable.Repeat(0, Count).Select(x => generator.Next()).ToList();
        }

        public IQueryable<Employee> Persons
        {
            get
            {
                return _collection.AsQueryable();
            }
        }
    }
}