using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchool
{
    class Program
    {
        static string SpecialMessage = " RED ALERT!!! HE WHO MUST NOT BE NAMED!!! ";
        static string[] Students = new string[15];
        static string[] EnglishNationalQuidditchTeam = { "Vosper", "Hawksworth", "Flitney", "Withey",
                                                        "Choudry", "Frisby", "Parkin" };
        static bool[] WeasleyGrangerDiscount = new bool[15];

        static double[] StudentsAccountBalance = new double[15];

        static void Main(string[] args)
        {
            Menu();
            Console.WriteLine("You are now Signed Out!");

            Console.ReadKey();

        }

        // This method is used to count the number of students currently enrolled
        private static int CheckEnrollmentStatus()
        {
            int counter = 0;
            //loops through checks to see if array spot has a name; if so increase counter
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    counter++;
                }
            }

            return counter;
        }

        // This method is used to print out the student list (discounted students are highlighted)
        private static void PrintStudentList()
        {
            double sum = 0.0;

            //StudentsAccountBalance = BalanceCalculation();
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    if (StudentsAccountBalance[i] < 200)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i + 1 + ". " + Students[i] + " ");
                        Console.Write("(£" + StudentsAccountBalance[i] + ")");
                        Console.ResetColor();

                        sum = sum + StudentsAccountBalance[i];
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write(i + 1 + ". " + Students[i] + " ");
                        Console.Write("(£" + StudentsAccountBalance[i] + ")");

                        sum = sum + StudentsAccountBalance[i];

                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total: £" + sum);
            Console.WriteLine();

        }

        // This method is used to unenroll student and re-order the list make sure no gaps 
        private static void UnEnrollStudent()
        {
            string[] tempArray = new string[15];
            double[] tempArrayBal = new double[15];
            bool[] tempArrayDiscount = new bool[15];
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
                    WeasleyGrangerDiscount[i] = false;
                }

                if(Students[i] != null)
                {
                    tempArray[j] = Students[i];
                    tempArrayBal[j] = StudentsAccountBalance[i];
                    tempArrayDiscount[j] = WeasleyGrangerDiscount[i];
                    j++;
                }
            }

            Students = tempArray;
            StudentsAccountBalance = tempArrayBal;
            WeasleyGrangerDiscount = tempArrayDiscount;
            Console.WriteLine(StudentName + " has been unenrolled.");
            Console.WriteLine();
        }

        // This method enrolls students and based on differnt conditions applies special cases
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
            else if (WeasleyOrGranger(Lname))
            {
                for (int i = 0; i < 15; i++)
                {
                    if (Students[i] == null)
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost * 0;
                        if (ProfessorMcgonagallSpecialNames(StudentName))
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: £{1}", SpecialMessage, StudentsAccountBalance[i]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: £{1}", StudentName, StudentsAccountBalance[i]);
                            break;
                        }
                    }
                }
            }
            else if (StudentName.ToLower().Contains("potter"))
            {

                for (int i = 0; i < 15; i++)
                {
                    if (Students[i] == null)
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost * .5;
                        if (ProfessorMcgonagallSpecialNames(StudentName))
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[i]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                            break;
                        }
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
                        if (ProfessorMcgonagallSpecialNames(StudentName))
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[i]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: £{1}", StudentName, StudentsAccountBalance[i]);
                            break;
                        }
                    }
                    else
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost;
                        if (ProfessorMcgonagallSpecialNames(StudentName))
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[i]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                            break;
                        }
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
                        if (ProfessorMcgonagallSpecialNames(StudentName))
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[i]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                            break;
                        }
                    }
                }

            }
            else if (CheckStudentConnectionToQuidditchTeam(Lname) == true)
            {
                for (int i = 0; i < 15; i++)
                {

                    if (Students[i] == null)
                    {
                        Students[i] = StudentName;
                        StudentsAccountBalance[i] = EnrollmentCost * .70;
                        if (ProfessorMcgonagallSpecialNames(StudentName))
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[i]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                            break;
                        }
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
                        if (ProfessorMcgonagallSpecialNames(StudentName))
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[i]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[i]);
                            break;
                        }
                     
                    }
                }

            }
           
        }

        // This method is the menu and displays differnt options based on enrollment status
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

        // This method is used to check if student is related to member to sports team based on last name
        private static bool CheckStudentConnectionToQuidditchTeam(string Lname)
        {
            for (int i = 0; i < EnglishNationalQuidditchTeam.Length; i++)
            {
                if (Lname == EnglishNationalQuidditchTeam[i])
                {
                    return true;
                }
            }

            return false;

        }

        // This method is used to find special names and applie the corresponding case
        private static bool ProfessorMcgonagallSpecialNames(string StudentName)
        {
            if (StudentName.ToLower().Contains("tom") || StudentName.ToLower().Contains("riddle") || StudentName.ToLower().Contains("voldemort"))
            {
                return true;
            }
                return false;
        }

        // This method is used to see if any of the students are related to Weasley or Granger if true applies special case
        private static bool WeasleyOrGranger(String Lname)
        {
            if (Lname.ToLower() == "weasley" || Lname.ToLower() == "granger")
            {
                for(int i = 0; i < StudentsAccountBalance.Length; i++)
                {
                    if(!WeasleyGrangerDiscount[i])
                        StudentsAccountBalance[i] = StudentsAccountBalance[i] * .95;
                }
                return true;
            } 
            else
            {
                return false;
            }

        }

        //This method is used to keep track of students if they have benefited from WeasleyOrGranger discount 
        private static void BalanceCalculation()
        {
            bool DiscountForAll = false;
            string Lname = null;

            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    var splitNames = Students[i].Split(' ');
                    Lname = splitNames[1];

                }

                if (WeasleyOrGranger(Lname))
                {
                    DiscountForAll = true;
                    break;
                }
            }

            for (int i = 0; i < StudentsAccountBalance.Length; i++)
            {
                

                if (Students[i] != null && DiscountForAll && !WeasleyGrangerDiscount[i])
                {
                    WeasleyGrangerDiscount[i] = true;
                }
            }

        }
    }
}
