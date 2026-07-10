using System;
using System.Collections.Generic;
using System.Linq;

namespace BSIT31E1_PRELIM_H1_Mescallado_Judiel_Meguiel
{
    public class Student
    {
        private string _name;
        private List<double> _grades;

        public Student(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _grades = new List<double>();
        }

        public void AddGrade(double grade) => _grades.Add(grade);
        public string GetName() => _name;
        public double GetAverage() => _grades.Count == 0 ? 0 : _grades.Average();
        public double GetHighestGrade() => _grades.Any() ? _grades.Max() : 0;
        public bool HasGrade(double value) => _grades.Contains(value);
    }

    public class StudentSystem
    {
        private readonly List<Student> _students;

        public StudentSystem() => _students = new List<Student>();

        public void AddStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            _students.Add(new Student(name));
        }

        public int GetStudentCount() => _students.Count;
        public Student? GetStudentByIndex(int index) => index >= 0 && index < _students.Count ? _students[index] : null;

        public void DisplayAllStudents()
        {
            foreach (var s in _students)
                Console.WriteLine($"Name: {s.GetName()} | Average: {s.GetAverage():F2}");
        }

        public double GetClassAverage() => _students.Count == 0 ? 0 : _students.Average(s => s.GetAverage());
        public Student? GetTopStudent() => _students.OrderByDescending(s => s.GetAverage()).FirstOrDefault();
        public double GetHighestGradeInClass() => _students.Any() ? _students.Max(s => s.GetHighestGrade()) : 0;
        public List<string> GetStudentsWithGrade(double grade) => _students.Where(s => s.HasGrade(grade)).Select(s => s.GetName()).ToList();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var system = new StudentSystem();

            while (true)
            {
                Console.WriteLine("===== STUDENT SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade");
                Console.WriteLine("3. View Students & Average");
                Console.WriteLine("4. Class Average");
                Console.WriteLine("5. Top Student");
                Console.WriteLine("6. Highest Grade");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter student name: ");
                        string? name = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(name))
                        {
                            Console.Write("Invalid name, try again: ");
                            name = Console.ReadLine();
                        }
                        system.AddStudent(name);
                        Console.WriteLine($"Student '{name}' added!\n");
                        break;

                    case "2":
                        if (system.GetStudentCount() == 0)
                        {
                            Console.WriteLine("No students yet.\n");
                            break;
                        }
                        Console.WriteLine("Select student:");
                        for (int i = 0; i < system.GetStudentCount(); i++)
                            Console.WriteLine($"{i + 1}. {system.GetStudentByIndex(i)!.GetName()}");

                        Console.Write("Enter number: ");
                        if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > system.GetStudentCount())
                        {
                            Console.WriteLine("Invalid selection.\n");
                            break;
                        }

                        Console.Write("Enter grade: ");
                        if (!double.TryParse(Console.ReadLine(), out double grade))
                        {
                            Console.WriteLine("Invalid grade.\n");
                            break;
                        }

                        system.GetStudentByIndex(num - 1)!.AddGrade(grade);
                        Console.WriteLine("Grade added!\n");
                        break;

                    case "3":
                        if (system.GetStudentCount() == 0)
                        {
                            Console.WriteLine("No students.\n");
                            break;
                        }
                        system.DisplayAllStudents();
                        Console.WriteLine();
                        break;

                    case "4":
                        if (system.GetStudentCount() == 0)
                        {
                            Console.WriteLine("No students.\n");
                            break;
                        }
                        Console.WriteLine($"Class Average: {system.GetClassAverage():F2}\n");
                        break;

                    case "5":
                        if (system.GetStudentCount() == 0)
                        {
                            Console.WriteLine("No students.\n");
                            break;
                        }
                        var top = system.GetTopStudent()!;
                        Console.WriteLine($"Top Student: {top.GetName()} | Average: {top.GetAverage():F2}\n");
                        break;

                    case "6":
                        if (system.GetStudentCount() == 0)
                        {
                            Console.WriteLine("No students.\n");
                            break;
                        }
                        double highest = system.GetHighestGradeInClass();
                        var owners = system.GetStudentsWithGrade(highest);
                        Console.WriteLine($"Highest Grade: {highest} | Student(s): {string.Join(", ", owners)}\n");
                        break;

                    case "7":
                        Console.WriteLine("Program ended.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Try again.\n");
                        break;
                }
            }
        }
    }
}