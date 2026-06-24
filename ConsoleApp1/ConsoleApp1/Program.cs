using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.WriteLine("===== STUDENT SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Compute Average Grade");
                Console.WriteLine("4. Find Highest Grade");
                Console.WriteLine("5. Exit");
                Console.WriteLine("==========================");
                Console.WriteLine("Choose an option:");

                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    Console.WriteLine("Enter student name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter grade 1:");
                    int g1 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter grade 2:");
                    int g2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter grade 3:");
                    int g3 = Convert.ToInt32(Console.ReadLine());

                    manager.AddStudent(name, g1, g2, g3);
                    Console.WriteLine("Student added successfully!");
                }
                else if (selection == "2")
                {
                    manager.ViewAllStudents();
                }
                else if (selection == "3")
                {
                    manager.ComputeClassAverage();
                }
                else if (selection == "4")
                {
                    manager.FindHighestGrade();
                }
                else if (selection == "5")
                {
                    Console.WriteLine("Exiting program...");
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!! Please Enter Again");
                }

                Console.WriteLine();
            }
        }
    }
}