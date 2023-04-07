using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int GroupSize = Students.Count / 5;

            List<Student> Sorted = Students.OrderByDescending(s => s.AverageGrade).ToList();

            int Position = Sorted.FindIndex(s => s.AverageGrade == averageGrade);

            if (Position < 0)
            {
                throw new ArgumentException("The specified average grade is not found in the list of students");
            }

            if (Position < GroupSize)
            {
                return 'A';
            }
            else if (Position < GroupSize * 2)
            {
                return 'B';
            }
            else if (Position < GroupSize * 3)
            {
                return 'C';
            }
            else if (Position < GroupSize * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        public override void  CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string derp)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(derp);
        }
    }
}