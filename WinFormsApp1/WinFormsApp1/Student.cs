using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public GradeLevel? Year { get; set; }
        public List<int> ExamScores { get; set; }

        public Student(string FirstName, string LastName, int ID, GradeLevel Year, List<int> ExamScores)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ID = ID;
            this.Year = Year;
            this.ExamScores = ExamScores;
        }

        public Student(string FirstName, string LastName, int StudentID, List<int>? ExamScores = null)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            ID = StudentID;
            this.ExamScores = ExamScores ?? Enumerable.Empty<int>().ToList();
        }

    }

    enum GradeLevel
    {
        FirstYear = 1,
        SecondYear,
        ThirdYear,
        FourthYear
    };
}
