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
            Console.WriteLine("Press Any Key To Close");
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

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enrolled Students");
            Console.ResetColor();
            Console.WriteLine();

            // Loops through and prints name if current index is not null
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    // If student current balance is less than full enrollment cost, student text is red to stand out
                    // Also calculates total sum of all students 
                    if (StudentsAccountBalance[i] < 200)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i + 1 + ". " + Students[i] + " ");
                        Console.Write("(£" + StudentsAccountBalance[i] + ")");
                        Console.ResetColor();

                        sum = sum + StudentsAccountBalance[i];
                    }
                    // If balance is == to full enrollment cost, print normally in white text
                    // Also calculates total sum of all students
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
            Console.WriteLine();
            Console.WriteLine("Total: £" + sum);
            Console.WriteLine();

        }

        // This method is used to unenroll student and re-order the list make sure no gaps 
        private static void UnEnrollStudent()
        {
            // Temporary arrays to reorganize the static arrays
            string[] tempArray = new string[15];
            double[] tempArrayBal = new double[15];
            bool[] tempArrayDiscount = new bool[15];

            // Prints out list of curently enrolled students
            PrintStudentList();
            Console.WriteLine();

            // Asks and Gets what student the user would like to unenroll (User selects by number)
            Console.WriteLine("Which student would you like to unenroll?");
            int StudentToUnenroll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // Gets student name based on number selected by user ([StudentToUnenroll - 1] since array starts from 0)
            string StudentName = Students[StudentToUnenroll - 1];

            // Loop to find student in array and reset all information associated with the student
            for (int i = 0, j = 0; i < 15; i++)
            {
                // If the index of student is == index user selected this is excuted
                if (i == StudentToUnenroll - 1)
                {
                    Students[i] = null;
                    StudentsAccountBalance[i] = 0;
                    WeasleyGrangerDiscount[i] = false;
                }

                // If current index has student name this is executed
                if (Students[i] != null)
                {
                    tempArray[j] = Students[i]; // Takes the student name puts it in temporary array
                    tempArrayBal[j] = StudentsAccountBalance[i]; // Does same with balance
                    tempArrayDiscount[j] = WeasleyGrangerDiscount[i]; // Does same with discount (T or F)
                    j++; // This is associated to temp array moves to next spot
                }
            }

            // Dumps temp arrays back into static original arrays
            Students = tempArray;
            StudentsAccountBalance = tempArrayBal;
            WeasleyGrangerDiscount = tempArrayDiscount;

            // Informs user of successfull unenrollment
            Console.WriteLine(StudentName + " has been unenrolled.");
            Console.WriteLine();
        }

        // This method enrolls students and based on differnt conditions applies special cases
        private static void EnrollStudent()
        {
            double EnrollmentCost = 200;
            Console.WriteLine();
            Console.WriteLine("Please enter student's name");
            string StudentName = Console.ReadLine();
            Console.WriteLine();

            var splitNames = StudentName.Split(' ');
            string Fname = splitNames[0];
            string Lname = splitNames[1];

            int openSpot = OpenSpot();

            if(openSpot == -1)
            {
                Console.WriteLine("All spots are filled, Please try again next term");
            }
            else if (Lname.ToLower() == "malfoy")
            {
                Console.WriteLine("Enrollment declined. The Malfoy family has been BANNED from our institution.");
            }
            else if (WeasleyOrGranger(Lname))
            {

                Students[openSpot] = StudentName;
                StudentsAccountBalance[openSpot] = EnrollmentCost * 0;
                if (ProfessorMcgonagallSpecialNames(StudentName))
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: £{1}", SpecialMessage, StudentsAccountBalance[openSpot]);
                }
                else
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: £{1}", StudentName, StudentsAccountBalance[openSpot]);
                }

            }
            else if (StudentName.ToLower().Contains("potter"))
            {


                Students[openSpot] = StudentName;
                StudentsAccountBalance[openSpot] = EnrollmentCost * .5;
                if (ProfessorMcgonagallSpecialNames(StudentName))
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[openSpot]);
                }
                else
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[openSpot]);
                }



            }
            else if (StudentName.ToLower().Contains("longbottom"))
            {

                if (CheckEnrollmentStatus() < 10)
                {
                    Students[openSpot] = StudentName;
                    StudentsAccountBalance[openSpot] = EnrollmentCost * 0;
                    if (ProfessorMcgonagallSpecialNames(StudentName))
                    {
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[openSpot]);
                    }
                    if (!ProfessorMcgonagallSpecialNames(StudentName))
                    {
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: £{1}", StudentName, StudentsAccountBalance[openSpot]);
                    }
                }
                else
                {
                    Students[openSpot] = StudentName;
                    StudentsAccountBalance[openSpot] = EnrollmentCost;
                    if (ProfessorMcgonagallSpecialNames(StudentName))
                    {
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[openSpot]);
                    }
                    else
                    {
                        Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[openSpot]);
                    }
                }


            }
            else if (Fname.ToLower().First() == Lname.ToLower().First())
            {

                Students[openSpot] = StudentName;
                StudentsAccountBalance[openSpot] = EnrollmentCost * .90;
                if (ProfessorMcgonagallSpecialNames(StudentName))
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[openSpot]);
                }
                else
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[openSpot]);
                }



            }
            else if (CheckStudentConnectionToQuidditchTeam(Lname) == true)
            {

                Students[openSpot] = StudentName;
                StudentsAccountBalance[openSpot] = EnrollmentCost * .70;
                if (ProfessorMcgonagallSpecialNames(StudentName))
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[openSpot]);
                }
                else
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[openSpot]);
                }


            }
            else
            {
                Students[openSpot] = StudentName;
                StudentsAccountBalance[openSpot] = EnrollmentCost;
                if (ProfessorMcgonagallSpecialNames(StudentName))
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", SpecialMessage, StudentsAccountBalance[openSpot]);
                }
                else
                {
                    Console.WriteLine("Thank you for choosing us {0}.\nYour currently balance is an amount of: -£{1}", StudentName, StudentsAccountBalance[openSpot]);
                }
            }

        }

        // This method is the menu and displays differnt options based on enrollment status
        private static void Menu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Welcome, input the number that corresponds to your choice selection     |");
            Console.ResetColor();

            int selection; // Initiated outside of the loop

            // Loop to display a modified menu choice to user depending on how many students enrolled
            do
            {
                //Console.WriteLine("                                                                        |");
                if (CheckEnrollmentStatus() == 15)
                {
                    //Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine();
                    Console.WriteLine("2. Unenroll a student                                                   |");
                    Console.WriteLine("3. Print out the list of enrolled students                              |");
                    Console.WriteLine("4. Exit                                                                 |");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (CheckEnrollmentStatus() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine();
                    Console.WriteLine("1. Enroll a student                                                     |");
                    Console.WriteLine("3. Print out the list of enrolled students                              |");
                    Console.WriteLine("4. Exit                                                                 |");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("1. Enroll a student                                                     |");
                    Console.WriteLine("2. Unenroll a student                                                   |");
                    Console.WriteLine("3. Print out the list of enrolled students                              |");
                    Console.WriteLine("4. Exit                                                                 |");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();

                }


                // Collects selection from user
                selection = Convert.ToInt32(Console.ReadLine());

                // Conditional States to execute tasks based on user selection
                if (selection == 1 && CheckEnrollmentStatus() < 15)
                {
                    EnrollStudent();
                }
                else if (selection == 2 && CheckEnrollmentStatus() > 0)
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
            // Compares last name of user to those listed in the wuidditch team array
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
            // Checks to see if any part of student's name contains any of names Professor McGonagall Privacy List
            if (StudentName.ToLower().Contains("tom") || StudentName.ToLower().Contains("riddle") || StudentName.ToLower().Contains("voldemort"))
            {
                return true;
            }
            return false;
        }

        // This method is used to see if any of the students are related to Weasley or Granger if true applies special case
        private static bool WeasleyOrGranger(String Lname)
        {
            // Used to see if students enrolled qualify for the WeasleyGranger Scholarship
            if (Lname.ToLower() == "weasley" || Lname.ToLower() == "granger")
            {
                //loops through students account balance to apply WeasleyGranger Scholarship
                for (int i = 0; i < StudentsAccountBalance.Length; i++)
                {
                    // Checks to see if student already recieved this schorlarship before applying it
                    if (!WeasleyGrangerDiscount[i])
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
            bool DiscountForAll = false; // To see if all students are elligible for the WeasleyOrGranger Scholarship
            string Lname = null;

            // Look to check to see if any one in the Weasley or Granger family is enrolled
            for (int i = 0; i < Students.Length; i++)
            {
                // Gets the students lastname
                if (Students[i] != null)
                {
                    var splitNames = Students[i].Split(' ');
                    Lname = splitNames[1];

                }

                // Check lastname to see if they are indeed a member for the Weasley or Granger family
                if (WeasleyOrGranger(Lname))
                {
                    DiscountForAll = true; // If atleast one member is found EVERYONE GETS A DISCOUNT YAY
                    break;
                }
            }

            // Loops through student balance array
            for (int i = 0; i < StudentsAccountBalance.Length; i++)
            {

                // Makes sure if student got the discount it is recorded
                if (Students[i] != null && DiscountForAll && !WeasleyGrangerDiscount[i])
                {
                    WeasleyGrangerDiscount[i] = true;
                }
            }

        }

        private static int OpenSpot()
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] == null)
                    return i;
            }
            return -1;
        }
    }
}
