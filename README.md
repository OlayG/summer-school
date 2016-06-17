# summer-school
A program that implements a wild set of business rules for a summer program at a very special school.


## Details

In this project, you will write a console-based system that will take in and process student enrollments.

Your program will start by showing a menu of choices, and doing different things based upon what the user chooses.

Here is an example of what the menu might look like:

```
1. Enroll a student
2. Unenroll a student
3. Print out the list of enrolled students
4. Exit
>
```

Enrollment is limited to 15 students. If the maximum number of enrolled students has been reached, then don't show the "Enroll a student" option. Likewise, if no students are enrolled yet, don't show the "Unenroll a student" option.

Enrollment costs `£200`. When a student is enrolled, a message needs to be printed out saying how much money the student will owe.

When you display the list of students, put the amount each student will owe next to the student's name, and display the overall total of the enrollment fees at the end of the list.

```
1. Angelina	Thornton (£200)
2. Pam Barnett (£200)
3. Carol Gomez (£190)
4. Marty Marshall (£180)
5. Gordon Griffith (£180)
6. Alison Gomez (£190)
7. Kyle Lawson (£200)

Total: £1360
```

When a user chooses to enroll a student, ask them for the name of the student, and save it to whatever data structure you are using.

```
1. Enroll a student
2. Unenroll a student
3. Print out the list of enrolled students
4. Exit
> 1
What is the name of the student to enroll?
> Angelina Thornton
Angelina Thornton is now enrolled and will need to pay £200.
```

When a user chooses to unenroll a student, display a list of the enrolled students, and let them choose the student to unenroll by typing the number next to them. Confirm their choice after they make it.

```
1. Enroll a student
2. Unenroll a student
3. Print out the list of enrolled students
4. Exit
> 2
1. Angelina	Thornton (£200)
2. Pam Barnett (£200)
3. Carol Gomez (£190)
4. Marty Marshall (£180)
5. Gordon Griffith (£180)
6. Alison Gomez (£190)
7. Kyle Lawson (£200)
Which student would you like to unenroll?
> 5
Gordon Griffith has been unenrolled.
```

After any choice, you should return the user to the main menu.

### Special Cases

This school has a history with certain students, though, and has some rules that it needs to follow when enrolling students.

1. Students with the last name `Malfoy` are not to be admitted. If someone tries to enroll a `Malfoy`, print out an error message and do not add the student to the list.
1. Students with the last name `Potter` are to be charged a reduced rate. It should be 50% of the normal rate.
1. If `Tom`, `Riddle`, or `Voldemort` is in any part of a student's name, we need to do something special. Check with `@mcgonagall` on Slack to find out more information about what to do.
1. `Longbottom`s are to be admitted free of charge, as long as less than 10 students are enrolled.
1. Students with a last name that starts with the same letter as their first name receive a 10% discount.
