using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W7Demo
{
    public class Student
    {
        public string XH { get; set; }
        public string XM { get; set; }

        public double Chinese { get; set; }
        public double Math { get; set; }
        public double English { get; set; }


        public double CalcAvgScore() => (Chinese + Math + English) / 3;
        //{
        //    return (Chinese + Math + English) / 3;
        //}


        public double AvgScore
        {
            get
            {
                return (Chinese + Math + English) / 3;
            }
        }

        public double Average => (Chinese + Math + English) / 3;

    }

    public class StudentArray
    {
        private Student[] students = new Student[100];
        private int index = 0;
        public void Add(Student student)
        {
            students[index++] = student;
        }

        public double CalcAvgByCourse(string course)
        {
            double sum = 0;
            foreach (var s in students)
            {
                switch (course.ToLower())
                {
                    case "chinese":
                        sum += s.Chinese; break;
                }
            }
            return sum / index;
        }

    }

    public class StudentList0
    {
        private List<Student> students = new List<Student>();

        public void Add(Student student) => students.Add(student);

        public double CalcAvgByCourse(string course)
        {
            double sum = 0;
            foreach (var s in students)
            {
                switch (course.ToLower())
                {
                    case "chinese":
                        sum += s.Chinese; break;
                }
            }
            return sum / students.Count;
        }
    }

    public class StudentList : List<Student>
    {
        public double CalcAvgByCourse(string course)
        {
            double sum = 0;
            foreach (var s in this)
            {
                switch (course.ToLower())
                {
                    case "chinese":
                        sum += s.Chinese; break;
                }
            }
            return sum / this.Count;
        }

        public Student FindByXh(string xh)
        {
            foreach (var s in this)
                if (s.XH == xh) return s;

            return null;
        }

        public Student this[string xh, bool isXh = true]
        {
            get
            {
                foreach (var s in this)
                    if (isXh && s.XH == xh) return s;
                    else if (s.XM == xh) return s;
                return null;
            }
        }

    }



}
