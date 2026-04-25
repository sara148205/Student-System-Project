using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_systemPro 
{
    //انشاء الواجهة : التجريد 
    interface IStudentActions
    {
        void DisplayInfo();
        void CalculateAverage();
    }
    //انشاء الفئة المجردة : التجريد 
    abstract class Student : IStudentActions
    {
        //التغليف 
        private string _name;
        private int _ID;

        public string Name
        {
            get { return _name; }
            set { if (!string.IsNullOrEmpty(value)) _name = value; }
        }
         
       
        public int ID
        {
            get { return _ID; }
            set { if (value > 0) _ID = value; }
            
        }
        public void SetStudentID(int initialID)
        {
            this.ID = initialID;
        }

        public static int TotalStudentsCount { get; private set; } 

        public Student()
        {
            TotalStudentsCount++;
        }
        public abstract void CalculateAverage();

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, ID: {ID}");
        }
    }
    // الوراثة وتعدد الاشكال 
    class ScienceStudent : Student
    {
        public override void CalculateAverage()
        {
            Console.WriteLine("Science Average:85");
        }
    }
    class LiteratureStudent: Student
    {
        public override void CalculateAverage()
        {
            Console.WriteLine("literature Average:75");
                }
    }
    class ArtStudent : Student
    {
        public override void CalculateAverage()
        {
            Console.WriteLine("Art Average:65");
        }
    }
    //التفويض والاحداث 
    public delegate void NotifyDelegate(string message);

    class NotificationSystem
    {
        public event NotifyDelegate OnProcessCompleted;
        public void StartProcessing()
        {
            Console.WriteLine("processing student data...");
            OnProcessCompleted?.Invoke("Student data processing finished successfully!");
        }
    }
    static class Validator
    {
        public static bool IsValidName (string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length > 2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            if (Validator.IsValidName("Sara"))
            {
                var s1 = new ScienceStudent();
                s1.Name = "Sara";
                s1.ID = 101;
                students.Add(s1);
            }
            var s2 = new LiteratureStudent();
            s2.Name = "Sedra";
            s2.ID = 102;
            students.Add(s2);

            var s3 = new ArtStudent();
            s3.Name = "laila";
            s3.ID = 103; 
            students.Add(s3);

            NotificationSystem notifier = new NotificationSystem();
            notifier.OnProcessCompleted += (msg) => Console.WriteLine("\n[NOTIFICATION]: " + msg);

            Console.WriteLine("---Student Management System Output ---");
            foreach(var Std in students)
            {
                Std.DisplayInfo();
                Std.CalculateAverage();
                Console.WriteLine("-------------------");
            }
            Console.WriteLine($" Total Student Registerd:{Student.TotalStudentsCount}");
            //اطلاق الحدث 
            notifier.StartProcessing();
            Console.ReadKey();
        }
    }
}
\\Edited by Sedra
\\Edited by sara
