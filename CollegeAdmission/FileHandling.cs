using System.IO;
using System.Linq;

namespace CollegeAdmission
{
    public static class FileHandling
    {
        public static void Create()
        {
            //Create Directory
            if(!Directory.Exists("CollegeAdmission"))
            {
                Directory.CreateDirectory("CollegeAdmission");
            }
            //Create StudentDetails csv
            if(!File.Exists("CollegeAdmission/StudentDetails.csv"))
            {
                File.Create("CollegeAdmission/StudentDetails.csv").Close();
            }
            //Create Admission csv
            if(!File.Exists("CollegeAdmission/Admission.csv"))
            {
                File.Create("CollegeAdmission/Admission.csv").Close();
            }
            //Create Department csv
            if(!File.Exists("CollegeAdmission/Department.csv"))
            {
                File.Create("CollegeAdmission/Department.csv").Close();
            }
        }

        public static void WriteCSV()
        {
            //To Write to CSV File
            //Student
            string [] students=new string[Operation.studentDetails.Count];
            for(int i=0;i<Operation.studentDetails.Count;i++)
            {
                students[i]=Operation.studentDetails[i].StudentID+","+Operation.studentDetails[i].StudentName+","+Operation.studentDetails[i].FatherName+","+Operation.studentDetails[i].DateOfBirth.ToString("dd/MM/yyyy")+","+Operation.studentDetails[i].Gender+","+Operation.studentDetails[i].Physics+","+Operation.studentDetails[i].Chemistry+","+Operation.studentDetails[i].Maths;
            }
            //To write in File with array
            File.WriteAllLines("CollegeAdmission/StudentDetails.csv",students);

            //Department
            string [] departments=new string[Operation.departments.Count];
            for(int i=0;i<Operation.departments.Count;i++)
            {
                departments[i]=Operation.departments[i].DepartmentID+","+Operation.departments[i].DepartmentName+","+Operation.departments[i].NumberOfSeats;
            }
            //To write in File with array
            File.WriteAllLines("CollegeAdmission/Department.csv",departments);

            //Admission
            string [] admissions=new string[Operation.admissions.Count];
            for(int i=0;i<Operation.admissions.Count;i++)
            {
                admissions[i]=Operation.admissions[i].AdmissionID+","+Operation.admissions[i].StudentID+","+Operation.admissions[i].DepartmentID+","+Operation.admissions[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operation.admissions[i].AdmissionStatus;

            }
            //To write in File with array
            File.WriteAllLines("CollegeAdmission/Admission.csv",admissions);
        }

        public static void ReadCSV()
        {
            //Student Details
            string[] students=File.ReadAllLines("CollegeAdmission/StudentDetails.csv");
            foreach(string student in students)
            {
                StudentDetails studentDetail=new StudentDetails(student);
                Operation.studentDetails.Add(studentDetail);
            }

            //Department
            string[] departments=File.ReadAllLines("CollegeAdmission/Department.csv");
            foreach(string department in departments)
            {
                Department departmentDetail=new Department(department);
                Operation.departments.Add(departmentDetail);
            }
            //Admission
            string[] admissions=File.ReadAllLines("CollegeAdmission/Admission.csv");
            foreach(string admission in admissions)
            {
                Admission admissionDetail=new Admission(admission);
                Operation.admissions.Add(admissionDetail);
            }
        }
    }
}