using System;
using System.Collections.Generic;

List<string> names = new List<string>();
List<int> grades = new List<int>();

while (true)
{
    Console.WriteLine("\n===== STUDENT SYSTEM =====");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View Students");
    Console.WriteLine("3. Class Average");
    Console.WriteLine("4. Highest Grade");
    Console.WriteLine("5. Exit");
    Console.Write("Choose: ");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Grade: ");
        int grade = Convert.ToInt32(Console.ReadLine());

        names.Add(name);
        grades.Add(grade);

        Console.WriteLine("Student Added!");
    }
    else if (choice == "2")
    {
        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine("Name: " + names[i]);
            Console.WriteLine("Grade: " + grades[i]);
        }
    }
    else if (choice == "3")
    {
        int total = 0;

        for (int i = 0; i < grades.Count; i++)
        {
            total += grades[i];
        }

        if (grades.Count > 0)
        {
            double average = (double)total / grades.Count;
            Console.WriteLine("Class Average: " + average);
        }
        else
        {
            Console.WriteLine("No students found.");
        }
    }
    else if (choice == "4")
    {
        if (grades.Count > 0)
        {
            int highest = grades[0];
            string topStudent = names[0];

            for (int i = 1; i < grades.Count; i++)
            {
                if (grades[i] > highest)
                {
                    highest = grades[i];
                    topStudent = names[i];
                }
            }

            Console.WriteLine("Top Student: " + topStudent);
            Console.WriteLine("Highest Grade: " + highest);
        }
        else
        {
            Console.WriteLine("No students found.");
        }
    }
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
}