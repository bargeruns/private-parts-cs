using System;
using System.Collections.Generic;

namespace private_parts_cs
{
    class Program
    {
        public class Person
        {
            public Person(string firstName, string lastName, DateTime dateOfBirth)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.DateOfBirth = dateOfBirth;
            }

            protected string FirstName { get; private set; }
            protected string LastName { get; private set; }
            public DateTime DateOfBirth { get; private set; }

            public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }

            public bool IsAdult()
            {
                return this.DateOfBirth > DateTime.Today.AddYears(-18);
            }

        }

        public class Student : Person
        {
            public Student(string firstName, string lastName, DateTime dateOfBirth)
                : base(firstName, lastName, dateOfBirth)
            { }

            public string SchoolName { get; set; }
            
            public string RosterName { get { return $"{this.LastName}, {this.FirstName}"; } }
        }

        public class Course
        {
            public Course(List<Student> enrolledStudents, string name)
            {
                this.EnrolledStudents = enrolledStudents;
                this.Name = name;
            }

            public string Name { get; private set; }

            protected List<Student> EnrolledStudents { get; private set; }

            public string CourseName()
            {
                return this.Name;
            }

            public void PrintRoster() {
                foreach(Student student in EnrolledStudents) {
                    Console.WriteLine(student.RosterName);
                }
            }
        }

        static void Main(string[] args)
        {
            Student John = new Student("John", "Doe", new DateTime(1992,04,24));
            Student Jane = new Student("Jane", "Says", new DateTime(1998,05,08));

            John.SchoolName = "Westview";
            Jane.SchoolName = "Chesterton";

            Course Eng101 = new Course(new List<Student> {John, Jane}, "Eng101");

            Eng101.PrintRoster();
        }
    }
}
