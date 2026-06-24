using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class StudentManager
    {
        private List<string> Lnames = new List<string>();
        private List<int[]> Lgrades = new List<int[]>();

        public void AddStudent(string name, int g1, int g2, int g3)
        {
            Lnames.Add(name);
            Lgrades.Add(new int[] { g1, g2, g3 });
        }

        public void ViewAllStudents()
        {
            if (Lnames.Count == 0)
            {
                Console.WriteLine("No students recorded yet.");
                return;
            }

            for (int i = 0; i < Lnames.Count; i++)
            {
                double average = GetAverage(Lgrades[i]);

                Console.WriteLine("Name: " + Lnames[i]);
                Console.WriteLine("Grades: " + Lgrades[i][0] + ", " + Lgrades[i][1] + ", " + Lgrades[i][2]);
                Console.WriteLine("Average: " + average.ToString("F2"));
                Console.WriteLine();
            }
        }

        public void ComputeClassAverage()
        {
            if (Lgrades.Count == 0)
            {
                Console.WriteLine("No students recorded yet.");
                return;
            }

            double total = 0;
            int count = 0;

            for (int i = 0; i < Lgrades.Count; i++)
            {
                total += Lgrades[i][0] + Lgrades[i][1] + Lgrades[i][2];
                count += 3;
            }

            Console.WriteLine("===== CLASS AVERAGE =====");
            Console.WriteLine("Overall Average Grade: " + (total / count).ToString("F2"));
        }

        public void FindHighestGrade()
        {
            if (Lgrades.Count == 0)
            {
                Console.WriteLine("No students recorded yet.");
                return;
            }

            int highestGrade = Lgrades[0][0];
            string topStudent = Lnames[0];

            for (int i = 0; i < Lnames.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Lgrades[i][j] > highestGrade)
                    {
                        highestGrade = Lgrades[i][j];
                        topStudent = Lnames[i];
                    }
                }
            }

            Console.WriteLine("===== HIGHEST GRADE =====");
            Console.WriteLine("Top Student: " + topStudent);
            Console.WriteLine("Highest Grade: " + highestGrade);
        }

        private double GetAverage(int[] grades)
        {
            int total = 0;

            for (int i = 0; i < grades.Length; i++)
            {
                total += grades[i];
            }

            return (double)total / grades.Length;
        }
    }
}