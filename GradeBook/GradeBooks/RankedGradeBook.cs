using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();
            List<Student> tempStudentList = new List<Student>();
            foreach (Student student in Students)
                tempStudentList.Add(student);
            for (int i = 0; i < tempStudentList.Count-1; i++)
            {
                if((tempStudentList[i].AverageGrade<tempStudentList[i+1].AverageGrade))
                {
                    Student studentHolder = tempStudentList[i];
                    tempStudentList[i] = tempStudentList[i + 1];
                    tempStudentList[i + 1] = studentHolder;
                   
                }
            }

            if (averageGrade > tempStudentList[(int)Math.Ceiling(tempStudentList.Count * 0.2)].AverageGrade)
                return 'A';
            else if (averageGrade > tempStudentList[(int)Math.Ceiling(tempStudentList.Count * 0.4)].AverageGrade)
                return 'B';
            else if (averageGrade > tempStudentList[(int)Math.Ceiling(tempStudentList.Count * 0.6)].AverageGrade)
                return 'C';
            else if (averageGrade > tempStudentList[(int)Math.Ceiling(tempStudentList.Count * 0.8)].AverageGrade)
                return 'D';
            else /*if (averageGrade >= tempStudentList[tempStudentList.Count].AverageGrade)*/
                return 'F';
           
        }
    }
}
