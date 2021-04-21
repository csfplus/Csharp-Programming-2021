//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace W7Demo
//{
//    public class Student
//    {

//        public string XM { get; set; }
//        public string XH { get; set; }

//        public double Chinese { get; set; }
//        public double Math { get; set; }
//        public double English { get; set; }

//        public double CalcAvg()
//        {
//            return (Chinese + Math + English) / 3;
//        }

//        public double Avg
//        {
//            get
//            {
//                return (Chinese + Math + English) / 3;
//            }
//        }

//        public double Average => (Chinese + Math + English) / 3;
//    }

//    public class StudentArray
//    {
//        private Student[] students = new Student[100];
//        private int index = 0;

//        public void Add(Student student)
//        {
//            students[index++] = student;
//        }
//    }

//    public class StudentList0
//    {
//        private List<Student> students = new List<Student>();


//        public void Add(Student student)
//        {
//            students.Add(student);
//        }

//        public double CalcAvg(string course)
//        {
//            double sum = 0;
//            foreach (var student in students)
//            {
//                switch (course.ToLower())
//                {
//                    case "chinese":
//                        sum += student.Chinese;
//                        break;
//                }
//            }
//            return sum / students.Count;

//        }
//        public Student FindByXh(string xh)
//        {
//            foreach (var student in students)
//                if (student.XH == xh) return student;

//            return null;
//        }

//        public Student this[string xh]
//        {
//            get
//            {
//                foreach (var student in students)
//                    if (student.XH == xh) return student;

//                return null;
//            }
//        }

//    }

//    public class StudentList : List<Student>
//    {

//        public double CalcAvg(string course)
//        {
//            double sum = 0;
//            foreach (var student in this)
//            {
//                switch (course.ToLower())
//                {
//                    case "chinese":
//                        sum += student.Chinese;
//                        break;
//                }
//            }
//            return sum / Count;

//        }

//        public Student this[string xh, string type]
//        {
//            get
//            {
//                foreach (var student in this)
//                    if (student.XH == xh) return student;

//                return null;
//            }
//        }


//    }


//}
