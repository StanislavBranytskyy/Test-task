using System;
using System.Security.Cryptography;
using System.Text;
using Canberra.TestTask.Codebase.Models;

namespace Canberra.TestTask.Codebase.Core
{
    public class EmployeeGenerator
    {
        private readonly Random _random;


        private static readonly string[] MaleNames = new[]
        {
            "James", "John", "Robert", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas",
            "Christopher", "Daniel", "Paul", "Mark", "Donald", "George", "Kenneth", "Steven", "Edward"
        };

        private static readonly string[] FemaleNames = new[]
        {
            "Mary", "Patricia", "Linda", "Barbara", "Elizabeth", "Jennifer", "Maria", "Susan", "Margaret", "Dorothy",
            "Lisa", "Nancy", "Karen", "Betty", "Helen", "Sandra", "Donna", "Carol", "Ruth"
        };

        private static readonly string[] Surnames = new[]
        {
            "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson",
            "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark",
            "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King", "Wright", "Lopez",
            "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson"
        };


        public EmployeeGenerator()
        {
            _random = new Random((int)(DateTime.Now.Ticks / 397));
        }

        public EmployeeGenerator(Random random)
        {
            _random = random;
        }


        public Employee Next()
        {
            var gender = _random.Next(0, 2) == 0 ? Gender.Female : Gender.Male;
            var names = gender == Gender.Male ? MaleNames : FemaleNames;

            var nameIndex = _random.Next(0, names.Length - 1);
            var surnameIndex = _random.Next(0, Surnames.Length - 1);

            var name = names[nameIndex];
            var surname = Surnames[surnameIndex];

            return new Employee
            {
                Id = GenerateDeterministicId(name + surname),
                Name = name,
                Surname = surname,
                Gender = gender
            };
        }

        private Guid GenerateDeterministicId(string input)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.Default.GetBytes(input));
                var result = new Guid(hash);
                return result;
            }
        }
    }
}