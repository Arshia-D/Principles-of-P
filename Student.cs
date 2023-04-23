using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principles_of_P
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public float[] Scores { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public float AverageScore => Scores.Average();

        public string FullAddress => $"{Address.AddressLine}, {Address.Street}, {Address.City}, {Address.Country}";
    }
}
