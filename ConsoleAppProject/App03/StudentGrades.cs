using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public const int MIN_FAIL = 0;
        public const int MIN_D = 40;
        public const int MIN_C = 50;
        public const int MIN_B = 60;
        public const int MIN_A = 70;
        public const int HighestMark = 100;
        public string[] Students { get; set; }
        public int[] Marks { get; set; }

        public int[] GradeProfile { get; set; }

        public double Mean { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        public int Total { get; set; }

        public void Run()
        {
            Students = new string[] { "Gupta", "Aaron", "Thierry", "Kapalu", "Mumba", "Edward", "Ashley", "Dickson", "Claudia", "Samson" };
            Marks = new int[Students.Length];
            ConsoleHelper.OutputHeading("App03 Student Marks");

            GradeProfile = new int[(int)Grades.A + 1];

            Marks = new int[]
            {
                80, 55, 42, 34, 63, 78, 91, 9, 57, 13
            };

            InputMarks();
            //ConvertToGrades();
            OutputGrades();
            CalculateStats();
            CalculateGradeProfile();
            OutputGradeProfile();
        }

        private void InputMarks()
        {
            Console.WriteLine("Please enter a mark for each student\n");
            int index = 0;

            foreach (string name in Students)
            {
                int mark = (int)ConsoleHelper.InputNumber($"{name} enter mark> ", 0, 100);
                Marks[index] = mark;
            }
        }

        private void OutputGrades()
        {
            for (int i = 0; i < Marks.Length; i++)
            {
                int mark = Marks[i];
                Grades grade = ConvertToGrades(mark);
                Console.WriteLine($"{Students[i]} mark = {Marks} Grade = {grade} ");
            }
        }

        public Grades ConvertToGrades(int mark)
        {
            if (mark >= 0 && mark < MIN_D)
            {
                return Grades.F;
            }

            else if (mark <= MIN_D && mark < MIN_C)
            {
                return Grades.D;
            }

            else if (mark <= MIN_C && mark < MIN_B)
            {
                return Grades.C;
            }

            else if (mark <= MIN_B && mark < MIN_A)
            {
                return Grades.B;
            }

            else if (mark <= MIN_A && mark <= HighestMark)
            {
                return Grades.A;
            }
            else return Grades.X;
        }

        public void CalculateStats()
        {
            double total = 0;

            Minimum = HighestMark;
            Maximum = 0;

            foreach (int mark in Marks)
            {
                total += mark;
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
            }

            Mean = total / Marks.Length;

            Console.WriteLine($"Mean = {Mean} Min = {Minimum} Max = {Maximum}");
        }

        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrades(mark);
                GradeProfile[(int)grade]++;
            }

            OutputGradeProfile();

        }

        private void OutputGradeProfile()
        {
            Grades grade = Grades.X;
            Console.WriteLine();

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($"Grade {grade} {percentage}% Count {count}");
                grade++;
            }

            Console.WriteLine();

        }
    }
}