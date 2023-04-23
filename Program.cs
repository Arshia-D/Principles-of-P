using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principles_of_P
{
    internal class Program
    {
        static List<Student> students = new List<Student>();
        
        static void Main(string[]args)
        {
            // Initialize sample data
            for (int i = 1; i <= 20; i++)
            {
                Address address = new Address
                {
                    AddressLine = $"Address Line {i}",
                    Street = $"Street {i}",
                    City = $"City {i}",
                    Country = $"Country {i}"
                };

                float[] scores = new float[] { 80 + i, 70 + i, 90 + i };

                Student student = new Student
                {
                    FirstName = $"First Name {i}",
                    LastName = $"Last Name {i}",
                    StudentNumber = $"S{i:000000}",
                    Age = 18 + i % 5,
                    Address = address,
                    Scores = scores
                };

                students.Add(student);
            }
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Student Management System");
                Console.ResetColor();
                Console.WriteLine("1. View All Students");
                Console.WriteLine("2. Add New Student");
                Console.WriteLine("3. View Specific Student");
                Console.WriteLine("4. Clear All Students");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAllStudents();
                        break;
                    case "2":
                        AddNewStudent();
                        break;
                    case "3":
                        ViewStudentInformation();
                        break;
                    case "4":
                        ClearAllStudents();
                        break;
                    case "5":
                        exit = true;
                        break;
                    
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        static void ClearAllStudents()
        {
            students.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All students have been cleared.");
            Console.ResetColor();
        }

        static void ViewAllStudents()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("All Students:");
            Console.ResetColor();
            foreach (var student in students)
            {
                Console.WriteLine($"- {student.FullName}, Score: {student.AverageScore}, City: {student.Address.City}, Address: {student.FullAddress}");
            }
        }

        static void AddNewStudent()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter new student information:");
            Console.ResetColor();

            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Student number: ");
            string studentNumber = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Address line: ");
            string addressLine = Console.ReadLine();

            Console.Write("Street: ");
            string street = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("Country: ");
            string country = Console.ReadLine();

            Console.Write("Number of scores: ");
            int numScores = int.Parse(Console.ReadLine());

            float[] scores = new float[numScores];
            for (int i = 0; i < numScores; i++)
            {
                Console.Write($"Score {i + 1}: ");
                scores[i] = float.Parse(Console.ReadLine());
            }

            // Create new student object
            Address address = new Address
            {
                AddressLine = addressLine,
                Street = street,
                City = city,
                Country = country
            };

            Student student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                StudentNumber = studentNumber,
                Age = age,
                Address = address,
                Scores = scores
            };

            // Add new student to list
            students.Add(student);

            // Display success message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New student added successfully:");
            Console.ResetColor();
            Console.WriteLine($"- {student.FullName}, Score: {student.AverageScore}, City: {student.Address.City}, Address: {student.FullAddress}");
        }

        static void ViewStudentInformation()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter student full name: ");
            Console.ResetColor();
            string fullName = Console.ReadLine();

            var student = students.FirstOrDefault(s => s.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                Console.WriteLine($"Student {student.FullName} score is {student.AverageScore}");
                Console.WriteLine($"Student {student.FullName} is living in {student.Address.City}");
                Console.WriteLine($"Student {student.FullName} address is {student.FullAddress}");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found.");
                Console.ResetColor();
            }
        }
    }
}