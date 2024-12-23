using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    /// <summary>
    /// Static Operation Class to perform all the functionality
    /// </summary>
    public static class Operation
    {
        /// <summary>
        /// List of Student Details
        /// </summary>
        /// <typeparam name="StudentDetails"></typeparam>
        /// <returns></returns>
        public static List<StudentDetails> studentDetails = new List<StudentDetails>();
        /// <summary>
        /// List of Departments
        /// </summary>
        /// <typeparam name="Department"></typeparam>
        /// <returns></returns>
        public static List<Department> departments = new List<Department>();
        /// <summary>
        /// List of all Admissions
        /// </summary>
        /// <typeparam name="Admission"></typeparam>
        /// <returns></returns>
        public static List<Admission> admissions = new List<Admission>();

        /// <summary>
        /// Student Object Globally Currently LoggedIn Student
        /// </summary>
        static StudentDetails currentLoggedInStudent;
        /// <summary>
        /// To Load Default Data i.e Departments
        /// </summary>
        public static void LoadDeafaultData()
        {
            studentDetails.Add(new StudentDetails(studentName: "Ravichandran E", fatherName: "Ettapparajan", dob: new DateTime(11 / 11 / 1999), gender: GenderDetails.Male, physics: 95, chemistry: 95, maths: 95));
            studentDetails.Add(new StudentDetails(studentName: "Prem Kumar", fatherName: "Prithivi Rajan", dob: new DateTime(21 / 01 / 2003), gender: GenderDetails.Male, physics: 95, chemistry: 95, maths: 95));

            departments.Add(new Department(departmentName: "CSE", noOfSeats: 30));
            departments.Add(new Department(departmentName: "ECE", noOfSeats: 30));
            departments.Add(new Department(departmentName: "IT", noOfSeats: 30));

            FileHandling.WriteCSV();

        }

        /// <summary>
        /// <see cref="MainMenu()"/> which display Main Menu options
        /// </summary>
        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                // Code to be Repeated
                System.Console.WriteLine("************Main Menu************");
                System.Console.WriteLine("1.Student Registration\n2.Student Login\n3.Department wise seat availability\n4.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Department");
                            DepartmentAvaliblity();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Exit");
                            flag = false;
                            break;
                        }

                }
            } while (flag);
        }
        /// <summary>
        /// Student Registration
        /// </summary>
        public static void Registration()
        {
            try
            {
                System.Console.WriteLine("************Registration************");
                System.Console.WriteLine("Enter Student Name : ");
                string studentName = Console.ReadLine();
                System.Console.WriteLine("Enter Father Name : ");
                string fatherName = Console.ReadLine();
                System.Console.WriteLine("Enter Date of Birth dd/MM/yyyy : ");
                DateTime dob;
                while (!(DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob)))
                {
                    System.Console.WriteLine("Enter Valid Date of Birth : ");

                };
                System.Console.WriteLine("Enter Gender : ");
                GenderDetails gender;
                while (!Enum.TryParse<GenderDetails>(Console.ReadLine(), true, out gender))
                {
                    System.Console.WriteLine("Enter Valid Gender : ");
                };
                int physics, chemistry, maths;
                System.Console.WriteLine("Enter Physics Mark : ");
                while (!int.TryParse(Console.ReadLine(), out physics))
                {
                    System.Console.WriteLine("Enter Valid Physics Marks : ");
                }
                System.Console.WriteLine("Enter Chemistry Mark : ");
                while (!int.TryParse(Console.ReadLine(), out chemistry))
                {
                    System.Console.WriteLine("Enter Valid Chemistry Marks : ");
                }

                System.Console.WriteLine("Enter Maths Mark : ");
                while (!int.TryParse(Console.ReadLine(), out maths))
                {
                    System.Console.WriteLine("Enter Valid Maths Marks : ");
                }


                //Create Student Detail Object
                StudentDetails student = new StudentDetails(studentName: studentName, fatherName: fatherName, dob: dob, gender: gender, physics: physics, chemistry: chemistry, maths: maths);
                //Show Registered Student ID
                System.Console.WriteLine($"Your Student ID is {student.StudentID}");
                //Add the Student Object to List
                studentDetails.Add(student);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }

        }
        /// <summary>
        /// Student Login
        /// </summary>
        public static void Login()
        {
            try
            {
                System.Console.WriteLine("************Login************");
                //If Invalid show Invalid ID
                bool flag = false;
                //Get Student ID from user 
                System.Console.WriteLine("Enter Your Student ID : ");
                string studentID = Console.ReadLine();
                foreach (StudentDetails student in studentDetails)
                {
                    if (student.StudentID.Equals(studentID))
                    //Check StudentId is Valid
                    {
                        flag = true;
                        System.Console.WriteLine("************Login Successful************");
                        //If studentId matches set Student Object Globally
                        currentLoggedInStudent = student;
                        //Show SubMenu Option
                        SubMenu();
                        break;
                    }
                }
                if (!flag)
                {
                    System.Console.WriteLine("Invalid Student ID");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// <see cref="SubMenu()"/> SubMenu Options
        /// </summary>

        public static void SubMenu()
        {
            try
            {

                bool flag = true;
                do
                {
                    System.Console.WriteLine("************Sub Menu************");
                    System.Console.WriteLine("1.Check Eligibility | 2.Show Details       | 3.Take Admission");
                    System.Console.WriteLine("4.Cancel Admission  | 5.Admission History  | 7.Exit\n");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    //Get Option from User
                    //1. Check Eligibility 2. Show Details 3. Take Admission 4. Cancel Admission 5. Show Admission Details 6. Exit
                    switch (choice)
                    {
                        case 1:
                            {
                                checkEligibility();
                                break;
                            }
                        case 2:
                            {
                                ShowDetails();
                                break;
                            }
                        case 3:
                            {
                                TakeAdmission();
                                break;
                            }
                        case 4:
                            {
                                CancelAdmission();
                                break;
                            }
                        case 5:
                            {
                                AdmissionHistory();
                                break;
                            }
                        case 7:
                            {
                                flag = false;
                                break;
                            }
                    }
                }
                while (flag);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// <see cref="checkEligibility()"/> will check weather a Student is or not Eligible for the Admission
        /// </summary>
        /// <param name="cutOff">Cut Off Required for the Admission</param>
        /// <returns>Eligibily for Admission True or False</returns>
        public static void checkEligibility()
        {
            try
            {
                System.Console.WriteLine("************Check Eligibility************");
                //if Average is greater than 75 cutOff Student is Eligible
                //if Average below 75 Student not Eligible
                bool isEligible = currentLoggedInStudent.checkEligibility(75);
                if (isEligible)
                {
                    System.Console.WriteLine($"You are Eligible {currentLoggedInStudent.StudentName}");
                }
                else
                {
                    System.Console.WriteLine($"You are Not Eligible {currentLoggedInStudent.StudentName}");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// Display the Student Details
        /// </summary>
        public static void ShowDetails()
        {
            try
            {
                System.Console.WriteLine("************Show Details************");
                System.Console.WriteLine($"Name : {currentLoggedInStudent.StudentName}\nFather Name : {currentLoggedInStudent.StudentName}\nDate of Birth : {currentLoggedInStudent.DateOfBirth}\nGender : {currentLoggedInStudent.Gender}\nPhysics : {currentLoggedInStudent.Physics}\nChemistry : {currentLoggedInStudent.Chemistry}\nMaths : {currentLoggedInStudent.Maths}");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
        /// <summary>
        /// To Book Admission for the currently Logged Student
        /// </summary>
        public static void TakeAdmission()
        {
            try
            {
                System.Console.WriteLine("************Take Admission************");
                //Take Admission
                //Show Departmennt
                foreach (Department department in departments)
                {
                    System.Console.WriteLine($"Department ID : {department.DepartmentID}\nDepartment Name : {department.DepartmentName}\nNo of Seats : {department.NumberOfSeats}");
                    System.Console.WriteLine();
                }
                //Select a department using Department ID
                System.Console.WriteLine("Enter Department ID : ");
                string getDepartment = Console.ReadLine().ToUpper();
                //Check Department ID is Valid If not Show Invalid Department ID
                bool flag = true;
                foreach (Department department in departments)
                {
                    if (department.DepartmentID.Equals(getDepartment))
                    {
                        //Check Number of Seats if greater than zero if seat unavailable show seat is unavailable
                        if (department.NumberOfSeats > 0)
                        {
                            //Then Check Student is eligibe CheckEligibilty Average Marks>75
                            if (currentLoggedInStudent.checkEligibility(75))
                            {
                                bool admissionFlag = false;
                                foreach (Admission admission in admissions)
                                {
                                    //Check weather the student already taken admission if yes show  Already Booked
                                    if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Booked))
                                    {
                                        admissionFlag = true;
                                        break;
                                    }
                                }
                                if (admissionFlag)
                                {
                                    //Already Booked
                                    System.Console.WriteLine($"You have already taken Admission {currentLoggedInStudent.StudentName}");
                                }
                                else
                                {
                                    //If not booked Dedut the seat from the department
                                    department.NumberOfSeats--;
                                    //Create Admission
                                    Admission admission = new Admission(studentID: currentLoggedInStudent.StudentID, departmentID: department.DepartmentID, admissionDate: DateTime.Now, admissionStatus: AdmissionStatus.Booked);
                                    //Add Show Successful Message
                                    System.Console.WriteLine($"Admission Successful..! {currentLoggedInStudent.StudentName}");
                                    System.Console.WriteLine($"Admission ID : {admission.AdmissionID}");
                                    admissions.Add(admission);
                                }
                            }
                            else
                            {
                                System.Console.WriteLine($"Your Average is Not Eligible {currentLoggedInStudent.StudentName}");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Seats Not Available");
                        }
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid Department ID");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }

        }
        /// <summary>
        /// To Cancel an Already Booked Admission
        /// </summary>
        public static void CancelAdmission()
        {
            try
            {
                System.Console.WriteLine("************Cancel Admission************");
                bool admissionFlag = true;
                //Check if the student has already Booked Admission
                foreach (Admission admission in admissions)
                {
                    if (admission.StudentID.Equals(currentLoggedInStudent.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Booked))
                    {
                        foreach (Department department in departments)
                        {
                            if (department.DepartmentID.Equals(admission.DepartmentID))
                            {
                                //If yes Increase the department seat count
                                department.NumberOfSeats++;
                            }
                        }
                        //Change the Admission Status to Cancelled
                        admission.AdmissionStatus = AdmissionStatus.Cancelled;
                        //Show Admission Cancelled Sucessfully
                        System.Console.WriteLine("Admission Sucessfully Cancelled");
                        admissionFlag = false;
                        break;
                    }
                }
                //If not show Admission Not Found
                if (admissionFlag)
                {
                    System.Console.WriteLine("Admission Not Found !");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }

        /// <summary>
        /// To Display all the Admission History
        /// </summary>
        public static void AdmissionHistory()
        {
            try
            {
                System.Console.WriteLine("************Show Admission History************");
                bool admissionHistoryFlag = true;
                foreach (Admission admission in admissions)
                {
                    if (admission.StudentID.Equals(currentLoggedInStudent.StudentID))
                    {
                        admissionHistoryFlag = false;
                        System.Console.WriteLine($"Admission ID : {admission.AdmissionID}\nDepartment ID : {admission.DepartmentID}\nStudent ID : {admission.StudentID}\nAdmission Date : {admission.AdmissionDate.ToString("dd/MM/yyyy")}\nAdmission Status : {admission.AdmissionStatus}");
                        System.Console.WriteLine();
                    }
                }
                if (admissionHistoryFlag)
                {
                    System.Console.WriteLine("No Admission History Found..!");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }

        /// <summary>
        /// To Show the Department Name and Available Seats
        /// </summary>
        public static void DepartmentAvaliblity()
        {
            try
            {
                foreach (Department department in departments)
                {
                    System.Console.WriteLine($"Department ID : {department.DepartmentID}\nDepartment Name : {department.DepartmentName}\nNo of Seats : {department.NumberOfSeats}");
                    System.Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Try Again");
            }
        }
    }

}

