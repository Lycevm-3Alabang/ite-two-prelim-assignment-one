using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Program
    {
        // Parallel lists to store student data
        static List<string> names   = new List<string>();
        static List<double> grade1s = new List<double>();
        static List<double> grade2s = new List<double>();
        static List<double> grade3s = new List<double>();

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

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewAllStudents();
                        break;
                    case "3":
                        ComputeClassAverage();
                        break;
                    case "4":
                        FindHighestGrade();
                        break;
                    case "5":
                        Console.WriteLine("Exiting program...");
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter grade 1: ");
            double g1 = double.Parse(Console.ReadLine());

            Console.Write("Enter grade 2: ");
            double g2 = double.Parse(Console.ReadLine());

            Console.Write("Enter grade 3: ");
            double g3 = double.Parse(Console.ReadLine());

            names.Add(name);
            grade1s.Add(g1);
            grade2s.Add(g2);
            grade3s.Add(g3);

            Console.WriteLine("Student added successfully!");
        }

        static void ViewAllStudents()
        {
            if (names.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            for (int i = 0; i < names.Count; i++)
            {
                double average = (grade1s[i] + grade2s[i] + grade3s[i]) / 3.0;
                Console.WriteLine($"Name: {names[i]}");
                Console.WriteLine($"Grades: {grade1s[i]}, {grade2s[i]}, {grade3s[i]}");
                Console.WriteLine($"Average: {average:F2}");
            }
        }

        static void ComputeClassAverage()
        {
            if (names.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            double total = 0;
            for (int i = 0; i < names.Count; i++)
            {
                total += (grade1s[i] + grade2s[i] + grade3s[i]) / 3.0;
            }

            double classAverage = total / names.Count;

            Console.WriteLine("===== CLASS AVERAGE =====");
            Console.WriteLine($"Overall Average Grade: {classAverage:F2}");
        }

        static void FindHighestGrade()
        {
            if (names.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            double highest = grade1s[0];
            string topStudent = names[0];

            for (int i = 0; i < names.Count; i++)
            {
                double[] grades = { grade1s[i], grade2s[i], grade3s[i] };
                foreach (double g in grades)
                {
                    if (g > highest)
                    {
                        highest = g;
                        topStudent = names[i];
                    }
                }
            }

            Console.WriteLine("===== HIGHEST GRADE =====");
            Console.WriteLine($"Top Student: {topStudent}");
            Console.WriteLine($"Highest Grade: {highest}");
        }
    }
}
