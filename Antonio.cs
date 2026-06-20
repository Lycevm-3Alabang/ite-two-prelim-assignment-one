public class Student
{
    private string name;
    private double grade1;
    private double grade2;
    private double grade3;

    public void SetStudent(string n, double g1, double g2, double g3)
    {
        name = n;
        grade1 = g1;
        grade2 = g2;
        grade3 = g3;
    }

    public string GetName()
    {
        return name;
    }

    public double ComputeAverage()
    {
        return (grade1 + grade2 + grade3) / 3;
    }

    public double GetHighestGrade()
    {
        double highest = grade1;

        if (grade2 > highest)
            highest = grade2;

        if (grade3 > highest)
            highest = grade3;

        return highest;
    }

    public string GetGrades()
    {
        return $"{(int)grade1}, {(int)grade2}, {(int)grade3}";
    }
}