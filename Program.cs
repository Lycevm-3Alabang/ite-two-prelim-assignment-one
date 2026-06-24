List<Student> students = new List<Student>();

while (true)
{
    Console.WriteLine("");
    Console.WriteLine("===== STUDENT SYSTEM =====");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Compute Average Grade");
    Console.WriteLine("4. Find Highest Grade");
    Console.WriteLine("5. Exit");
    Console.WriteLine("==========================");
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

        Student student = new Student();

        student.SetStudent(
            add_student,
            add_grade_1,
            add_grade_2,
            add_grade_3
            );

        students.Add(student);

        Console.WriteLine("Student added successfully");
    }
    else if (user_input == "2")
    {
        Console.WriteLine("");

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine("");
            Console.WriteLine($"Name: {students[i].GetName()}");
            Console.WriteLine($"Grades: {students[i].GetGrades()}");
            Console.WriteLine($"Average: {students[i].ComputeAverage()}");
        }
    }
    else if (user_input == "3")
    {
        if (students.Count == 0)
        {
            Console.WriteLine("");
            Console.WriteLine("No students found");
            continue;
        }
        Console.WriteLine("");
        Console.WriteLine("===== CLASS AVERAGE =====");

        double total = 0;

        for (int i = 0; i < students.Count; i++)
        {
            total += students[i].ComputeAverage();
        }

        double overall_average = total / students.Count;

        Console.WriteLine($"Overall Average Grade: {overall_average}");
    }
    else if (user_input == "4")
    {
        if (students.Count == 0)
        {
            Console.WriteLine("");
            Console.WriteLine("No students found");
            Console.WriteLine("Add student first to use this option");
            continue;
        }

        double highest_grade = students[0].GetHighestGrade();
        string highest_student = students[0].GetName();

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].GetHighestGrade() > highest_grade)
            {
                highest_grade = students[i].GetHighestGrade();
                highest_student = students[i].GetName();
            }
        }
        Console.WriteLine("");
        Console.WriteLine("===== HIGHEST GRADE =====");
        Console.WriteLine($"Top Student: {highest_student}");
        Console.WriteLine($"Highest grade: {highest_grade}");
    }
    else
    {
        Console.WriteLine("Invalid Input");
    }
}