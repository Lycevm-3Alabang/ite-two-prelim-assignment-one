using System;
using System.Collections.Generic;
using System.Linq;
 
namespace StudentSystem
{
    class Student   
    {
        public string Name { get; set; }
        public List<int> Grades { get; set; }
 
        public double Average => Grades.Average();
    }
 
    class Program
    {
        static List<Student> students = new List<Student>();
 
        static void Main(string[] args)
        {
            bool running = true;
 
            while (running)
            {
                Console.WriteLine("===== STUDENT SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Compute Average Grade");
                Console.WriteLine("4. Find Highest Grade");
                Console.WriteLine("5. Exit");
                Console.WriteLine("==========================");
                Console.Write("Choose an option: ");
 
                string choice = Console.ReadLine();
                Console.WriteLine("________________________________________");
 
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewStudents();
                        break;
                    case "3":
                        ComputeClassAverage();
                        break;
                    case "4":
                        FindHighestGrade();
                        break;
                    case "5":
                        Console.WriteLine("Exit");
                        Console.WriteLine("Exiting program...");
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
 
        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
 
            List<int> grades = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Enter grade {i}: ");
                int grade = int.Parse(Console.ReadLine());
                grades.Add(grade);
            }
 
            students.Add(new Student { Name = name, Grades = grades });
            Console.WriteLine("Student added successfully!");
            Console.WriteLine("________________________________________");
        }
 
        static void ViewStudents()
        {
            Console.WriteLine("View Students");
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"Name: {student.Name}");
                    Console.WriteLine($"Grades: {string.Join(", ", student.Grades)}");
                    Console.WriteLine($"Average: {student.Average:F2}");
                    Console.WriteLine("________________________________________");
                }
            }
        }
 
        static void ComputeClassAverage()
        {
            Console.WriteLine("Class Average");
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
            }
            else
            {
                double classAverage = students.Average(s => s.Average);
                Console.WriteLine("===== CLASS AVERAGE =====");
                Console.WriteLine($"Overall Average Grade: {classAverage:F2}");
            }
            Console.WriteLine("________________________________________");
        }
 
        static void FindHighestGrade()
        {
            Console.WriteLine("Highest Grade");
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
            }
            else
            {
                var topStudent = students
                    .OrderByDescending(s => s.Grades.Max())
                    .First();
 
                Console.WriteLine("===== HIGHEST GRADE =====");
                Console.WriteLine($"Top Student: {topStudent.Name}");
                Console.WriteLine($"Highest Grade: {topStudent.Grades.Max()}");
            }
            Console.WriteLine("________________________________________");
        }
    }
}