using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchool
{
    class Program
    {
        static string[] Students = new string[15];

        static void Main(string[] args)
        {
            //EnrollStudent();
            //UnEnrollStudent();
            //PrintStudentList();

            Console.WriteLine("Welcome, input the number that corresponds to your choice selection");

            Console.WriteLine();
            Console.WriteLine("1. Enroll a student");
            Console.WriteLine("2. Unenroll a student");
            Console.WriteLine("3. Print out the list of enrolled students");
            Console.WriteLine("4. Exit");
            Console.WriteLine();


            Console.ReadKey();

        }

        //private static void PrintStudentList()
        //{
        //    throw new NotImplementedException();
        //}

        //private static void UnEnrollStudent()
        //{
        //    throw new NotImplementedException();
        //}

        //private static void EnrollStudent()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
