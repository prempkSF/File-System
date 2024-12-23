using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class Admission
    {
        /// <summary>
        /// static integer to manage Admission ID
        /// </summary>
        private static int s_admissionID = 1000;
        /// <summary>
        /// Unique Admission ID
        /// </summary>
        /// <value>AID1001</value>
        public string AdmissionID { get; set; }
        /// <summary>
        /// Student's Unique ID
        /// </summary>
        /// <value>SF1001</value>
        public string StudentID { get; set; }
        /// <summary>
        /// Unique Department ID
        /// </summary>
        /// <value>DID1001</value>
        public string DepartmentID { get; set; }
        /// <summary>
        /// Date of Admission Booked dd/MM/yyyy
        /// </summary>
        /// <value>01/06/2024</value>
        public DateTime AdmissionDate { get; set; }
        /// <summary>
        /// Admission Status Booked, Cancelled
        /// </summary>
        /// <value></value>
        public AdmissionStatus AdmissionStatus { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Admission()
        {

        }
        public Admission(string values)
        {   
            string[] value=values.Split(',');
            s_admissionID=int.Parse(value[0].Remove(0,3));
            AdmissionID=value[0];
            StudentID=value[1];
            DepartmentID=value[2];
            AdmissionDate=DateTime.ParseExact(value[3],"dd/MM/yyyy",null);
            AdmissionStatus=Enum.Parse<AdmissionStatus>(value[4],true);
        }
        /// <summary>
        /// Parameterised Contructor
        /// </summary>
        /// <param name="studentID">Student's ID</param>
        /// <param name="departmentID">Department ID</param>
        /// <param name="admissionDate">Date of Admission</param>
        /// <param name="admissionStatus">Admission Status</param>
        public Admission(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            AdmissionID = $"AID{++s_admissionID}";
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }
    }
}