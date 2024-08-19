using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        IList<string> strlist = new List<string>()
       { "One", "Two", "Three", "Two", "Three" };

        IList<int> intlist = new List<int>()
        { 1, 2, 3, 2, 4, 4, 3, 5 };

        var distinctList1 = strlist.Distinct();
        foreach (var str in distinctList1)
        {
            Console.WriteLine(str);
        }



        var distinctList2 = intlist.Distinct();
        foreach (var i in distinctList2)
        {

            Console.WriteLine(i);
        }



        Console.WriteLine("----------------------------");

        IList<Student> studentsList = new List<Student>()
        {

            new Student(){StudentID = 1 , StudentName ="John " , Age =18},
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
        };

        var distinictStudents = studentsList.Distinct(new StudentComparer());
        foreach (var student in distinictStudents)
        {
            Console.WriteLine(student.StudentName);
        }






    }

    //Distinct extension method doesn't compare values of complex type objects.
    //You need to implement IEqualityComparer<T> interface in order to compare
    //the values of complex types


    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID
                    && x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.StudentID.GetHashCode();
        }
    }
}