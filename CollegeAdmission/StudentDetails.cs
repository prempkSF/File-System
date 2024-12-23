using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class StudentDetails
    {
        /// <summary>
        /// static integer to manage Unique Student ID
        /// </summary>
        private static int s_studentID = 1000;
        /// <summary>
        /// Unique Student ID
        /// </summary>
        /// <value>SF1001</value>
        public string StudentID { get; set; }
        /// <summary>
        /// Enrolled Student Name
        /// </summary>
        /// <value></value>
        public string StudentName { get; set; }
        /// <summary>
        /// Enrolled Student's Father Name
        /// </summary>
        /// <value></value>
        public string FatherName { get; set; }
        /// <summary>
        /// Enrolled Student Date of Birth dd/MM/yyyy
        /// </summary>
        /// <value></value>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Enrolled Student Gender Male,Female,Transgender
        /// </summary>
        /// <value></value>
        public GenderDetails Gender { get; set; }
        /// <summary>
        /// Enrolled Student Physics Mark
        /// </summary>
        /// <value>0 to 100</value>
        public int Physics { get; set; }
        /// <summary>
        /// Enrolled Student Chemistry Mark
        /// </summary>
        /// <value>0 to 100</value>
        public int Chemistry { get; set; }
        /// <summary>
        /// Enrolled Student Maths Mark
        /// </summary>
        /// <value>0 to 100</value>
        public int Maths { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public StudentDetails()
        {

        }

        public StudentDetails(string values)
        {
            string[] value=values.Split(',');
            s_studentID=int.Parse(value[0].Remove(0,2));
            StudentID = value[0];
            StudentName = value[1];
            FatherName = value[2];
            DateOfBirth = DateTime.ParseExact(value[3],"dd/MM/yyyy",null);
            Gender = Enum.Parse<GenderDetails>(value[4],true);
            Physics = int.Parse(value[5]);
            Chemistry =int.Parse(value[6]);
            Maths = int.Parse(value[7]);
        }
        /// <summary>
        /// Parmeterised Constructor
        /// </summary>
        /// <param name="studentName">Enrolled Student's Name</param>
        /// <param name="fatherName">Enrolled Student's Father Name</param>
        /// <param name="dob">Enrolled Student's Date of Birth</param>
        /// <param name="gender">Enrolled Student's Gender</param>
        /// <param name="physics">Enrolled Student's Physics Mark</param>
        /// <param name="chemistry">Enrolled Student's Chemistry Mark</param>
        /// <param name="maths">Enrolled Student's Maths Mark</param>
        public StudentDetails(string studentName, string fatherName, DateTime dob, GenderDetails gender, int physics, int chemistry, int maths)
        {
            StudentID = $"SF{++s_studentID}";
            StudentName = studentName;
            FatherName = fatherName;
            DateOfBirth = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }
        /// <summary>
        /// <see cref="TotalMarks()"/>
        /// </summary>
        /// <returns>Total Marks of Maths, Physics, Chemistry</returns>
        public int TotalMarks()
        {
            return Physics + Chemistry + Maths;
        }
        /// <summary>
        /// <see cref="Average()"/> will return the Average of Physics, Chemistry, Maths Marks
        /// </summary>
        /// <returns>Physics, Chemistry, Maths Average Marks</returns>
        public double Average()
        {
            return (double)TotalMarks() / 3;
        }
        /// <summary>
        /// <see cref="checkEligibility()"/> will check weather a Student is or not Eligible for the Admission
        /// </summary>
        /// <param name="cutOff">Cut Off Required for the Admission</param>
        /// <returns>Eligibily for Admission True or False</returns>
        public bool checkEligibility(double cutOff)
        {
            return Average() >= cutOff;
        }
    }
}