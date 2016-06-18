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
        static double[] StudentsAccountBalance = new double[15];

        static void Main(string[] args)
        {
            Menu();
            Console.WriteLine("You are now Signed Out!");

            Console.ReadKey();

        }

        private static int CheckEnrollmentStatus()
        {
            int counter = 0;
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static void PrintStudentList()
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    Console.WriteLine();
                    Console.Write( i+1 + ". " + Students[i] + " ");
                    Console.Write("(£" + StudentsAccountBalance[i] + ")");
                }
            }
            Console.WriteLine();
        }

        private static void UnEnrollStudent()
        {
            string[] tempArray = new string[15];
            double[] tempArrayBal = new double[15];
            PrintStudentList();
            Console.WriteLine();
            Console.WriteLine("Which student would you like to unenroll?");
            int StudentToUnenroll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            string StudentName = Students[StudentToUnenroll - 1];         

            for (int i = 0, j = 0; i < 15; i++)
            {

                if (i == StudentToUnenroll - 1)
                {
                    Students[i] = null;
                    StudentsAccountBalance[i] = 0;
                }

                if(Students[i] != null)
                {
                    tempArray[j] = Students[i];
                    tempArrayBal[j] = StudentsAccountBalance[i];
                    j++;
                }
            }

            Students = tempArray;
            StudentsAccountBalance = tempArrayBal;
            Console.WriteLine(StudentName + " has been unenrolled.");
            Console.WriteLine();
        }

        private static void EnrollStudent()
        {
            int EnrollmentCost = 200;
            Console.WriteLine();
            Console.WriteLine("Please enter student's name");
            string StudentName = Console.ReadLine();
            Console.WriteLine();

            var splitNames = StudentName.Split(' ');
            string Fname = splitNames[0];
            string Lname = splitNames[1];


            if (StudentName.ToLower().Contains("malfoy"))
            {
                Console.WriteLine("Enrollment declined. The Malfoy family has been BANNED from our institution.");
            }
            else if (StudentName.ToLower().Contains("potter"))
            {

                for (int i = 0; i < 15; i++)
                {
                    if (Students[i] == null)
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost * .5;
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                        break;
                    }
                }

            }
            else if (StudentName.ToLower().Contains("longbottom"))
            {

                for (int i = 0; i < 15; i++)
                {
                    if (Students[i] == null && CheckEnrollmentStatus() < 10)
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost * 0;
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: £{1}", StudentName, StudentsAccountBalance[i]);
                        break;
                    }
                    else
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost;
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                        break;
                    }
                }

            } 
            else if (Fname.ToLower().First() == Lname.ToLower().First())
            {

                for (int i = 0; i < 15; i++)
                {
                    if (Students[i] == null)
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost * .90;
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                        break;
                    }
                }

            }
            else
            {

                for (int i = 0; i < 15; i++)
                {
                    if (Students[i] == null)
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost;
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                        break;
                    }
                }

            }
           
        }

        private static void Menu()
        {
            Console.WriteLine("Welcome, input the number that corresponds to your choice selection");
            int selection;
            do
            {
                Console.WriteLine();
                if (CheckEnrollmentStatus() == 15)
                {
                    Console.WriteLine("2. Unenroll a student");
                    Console.WriteLine("3. Print out the list of enrolled students");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine();
                }
                else if (CheckEnrollmentStatus() == 0)
                {
                    Console.WriteLine("1. Enroll a student");
                    Console.WriteLine("3. Print out the list of enrolled students");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("1. Enroll a student");
                    Console.WriteLine("2. Unenroll a student");
                    Console.WriteLine("3. Print out the list of enrolled students");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine();
                }



                selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1 && CheckEnrollmentStatus() != 15)
                {
                    EnrollStudent();
                }
                else if (selection == 2 && CheckEnrollmentStatus() != 0)
                {
                    UnEnrollStudent();

                }
                else if (selection == 3)
                {
                    PrintStudentList();
                }
                else
                {
                    continue;
                }



            } while (selection != 4);
        }
    }
}
