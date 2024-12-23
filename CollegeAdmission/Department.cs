using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class Department
    {
        /// <summary>
        /// Static integer to manage unique Department ID
        /// </summary>
        private static int s_departmentID = 100;
        /// <summary>
        /// Unique Department ID
        /// </summary>
        /// <value>DID1001</value>
        public string DepartmentID { get; set; }
        /// <summary>
        /// Department Name
        /// </summary>
        /// <value>CSE</value>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Number of Seats Available in the Deparment
        /// </summary>
        /// <value></value>
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        /// <param name="departmentName">Department Name</param>
        /// <param name="noOfSeats">Number of Seats Available</param>
        
        public Department(string values)
        {
            string[] value=values.Split(',');
            s_departmentID=int.Parse(value[0].Remove(0,3));
            DepartmentID=value[0];
            DepartmentName=value[1];
            NumberOfSeats=int.Parse(value[2]);
        }
        public Department(string departmentName, int noOfSeats)
        {
            DepartmentID = $"DID{++s_departmentID}";
            DepartmentName = departmentName;
            NumberOfSeats = noOfSeats;
        }
    }
}
