using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    // This entire class was added by Harry
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            double numberOfStudents = Students.Count;

            if (numberOfStudents < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            //Array.Sort();
            //Students.Reverse();
;
            double twentyPercentOfNumberOfStudents = Math.Round(numberOfStudents / 5d);

            int studentsWithHigherGrade = 0;
            for(int i = 0; i < numberOfStudents; i++)
            {
                if(Students[i].AverageGrade >= averageGrade)
                    studentsWithHigherGrade++; ;
            }

            if (studentsWithHigherGrade <= twentyPercentOfNumberOfStudents)
                return 'A';
            else if (studentsWithHigherGrade <= twentyPercentOfNumberOfStudents * 2)
                return 'B';
            else if (studentsWithHigherGrade <= twentyPercentOfNumberOfStudents * 3)
                return 'C';
            else if (studentsWithHigherGrade <= twentyPercentOfNumberOfStudents * 4)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            else
                base.CalculateStudentStatistics(name);
        }
    }
}
