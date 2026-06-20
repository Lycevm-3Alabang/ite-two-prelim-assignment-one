List<string> students = new List<string>();
List<double> grades_1 = new List<double>();
List<double> grades_2 = new List<double>();
List<double> grades_3 = new List<double>();

while (true)
{
    Console.WriteLine("");
    Console.WriteLine("===== STUDENT SYSTEM =====");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Compute Average Grade");
    Console.WriteLine("4. Find Highest Grade");
    Console.WriteLine("5. Exit");
    Console.WriteLine("=========================");
    Console.Write("Choose an Option: ");
    string user_input = Console.ReadLine();

    if (user_input == "5")
    {
        Console.WriteLine("");
        Console.WriteLine("Exiting program...");
        Console.WriteLine("Goodbye!");
        break;
    }
    else if (user_input == "1")
    {
        Console.WriteLine("");
        Console.Write("Enter student name: ");
        string add_student = Console.ReadLine();

        Console.Write("Enter grade 1: ");
        double add_grade_1 = double.Parse(Console.ReadLine());

        Console.Write("Enter grade 2: ");
        double add_grade_2 = double.Parse(Console.ReadLine());

        Console.Write("Enter grade 3: ");
        double add_grade_3 = double.Parse(Console.ReadLine());

        Console.WriteLine("Student added successfully");

        students.Add(add_student);
        grades_1.Add(add_grade_1);
        grades_2.Add(add_grade_2);
        grades_3.Add(add_grade_3);
    }
    else if (user_input == "2")
    {
        Console.WriteLine("");

        for (int i = 0; i < students.Count; i++)
        {
            double average = (grades_1[i] + grades_2[i] + grades_3[i]) / 3;

            Console.WriteLine("");
            Console.WriteLine($"Name: {students[i]}");
            Console.WriteLine($"Grades: {(int)grades_1[i]}, {(int)grades_2[i]}, {(int)grades_3[i]}");
            Console.WriteLine($"Average: {average:F2}");
        }
    }
    else if (user_input == "3")
    {
        Console.WriteLine("");
        Console.WriteLine("===== CLASS AVERAGE =====");

        double total = 0;

        for (int i = 0; i < students.Count; i++)
        {
            total += grades_1[i];
            total += grades_2[i];
            total += grades_3[i];
        }

        double overall_average = total / (students.Count * 3);
        Console.WriteLine($"Overall Average Grade: {overall_average:F2}");
    }
    else if (user_input == "4")
    {
        if (students.Count == 0)
        {
            Console.WriteLine("");
            Console.WriteLine("No students found");
            Console.WriteLine("Add students first to use this option");
            Console.WriteLine("");
            Console.Write("Enter student name: ");
            string add_student = Console.ReadLine();

            Console.Write("Enter grade 1: ");
            double add_grade_1 = double.Parse(Console.ReadLine());

            Console.Write("Enter grade 2: ");
            double add_grade_2 = double.Parse(Console.ReadLine());

            Console.Write("Enter grade 3: ");
            double add_grade_3 = double.Parse(Console.ReadLine());

            Console.WriteLine("Student added successfully");

            students.Add(add_student);
            grades_1.Add(add_grade_1);
            grades_2.Add(add_grade_2);
            grades_3.Add(add_grade_3);
        }

        double highest_grade = grades_1[0];
        string highest_student = students[0];

        for (int i = 0; i < students.Count; i++)
        {
            if (grades_1[i] > highest_grade)
            {
                highest_grade = grades_1[i];
                highest_student = students[i];
            }
            if (grades_2[i] > highest_grade)
            {
                highest_grade = grades_2[i];
                highest_student = students[i];
            }
            if (grades_3[i] > highest_grade)
            {
                highest_grade = grades_3[i];
                highest_student = students[i];
            }
        }

        Console.WriteLine("");
        Console.WriteLine("===== HIGHEST GRADE =====");
        Console.WriteLine($"Top Student: {highest_student}");
        Console.WriteLine($"Highest Grade: {highest_grade}");
    }
    else 
    {
        Console.WriteLine("Invalid Input");
    }
}