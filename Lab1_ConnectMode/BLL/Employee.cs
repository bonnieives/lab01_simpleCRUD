using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Lab1_ConnectMode.DAL;

namespace Lab1_ConnectMode.BLL
{
    // intance class
    public class Employee
    {
        // Class Variables
        private int employeeID;
        private string firstName;
        private string lastName;
        private string jobTitle;

        // Variables for Regex
        private string idPattern = @"^\d{4}";
        private string namePattern = @"^[A-Za-z]+(?:\s+[A-Za-z]+)*$";
        private string jobTitlePattern;

        // Properties
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        
        // default constructor
        public Employee()
        {
            employeeID = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            jobTitle = string.Empty;
        }

        // parameterized constructor
        public Employee(int employeeID, string firstName, string lastName, string jobTitle)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;
        }

        // custom methods
        public bool SaveEmployee(Employee emp)
        {

            // Setting the regex
            Regex regexId = new Regex(idPattern);
            Regex regexName = new Regex(namePattern);

            bool isMatchId = regexId.IsMatch(emp.EmployeeID.ToString());
            bool isMatchFirstName = regexName.IsMatch(emp.FirstName.ToString());
            bool isMatchLastName = regexName.IsMatch(emp.LastName.ToString());
            bool isMatchJobDescription = regexName.IsMatch(emp.JobTitle.ToString());

            bool isSaved = false;
            
            if (emp.EmployeeID.ToString() == "" || emp.FirstName == "" || emp.LastName == "" || emp.JobTitle == "")
            {
                EmptyField();
                return isSaved;
            }
            else if (!isMatchId || !isMatchFirstName || !isMatchLastName || !isMatchJobDescription)
            {
                NotMatchMessages(isMatchId, isMatchFirstName, isMatchLastName, isMatchJobDescription);
                return isSaved;
            }
            else if (isMatchId && isMatchFirstName && isMatchLastName && isMatchJobDescription)
            {
                isSaved = EmployeeDB.SaveRecord(emp); 
                return isSaved; 
            }            
            
            return isSaved;
        }
        public List<string> SearchEmployee(Employee emp)
        {
            // Setting the regex
            Regex regexId = new Regex(idPattern);

            bool isMatchId = regexId.IsMatch(emp.EmployeeID.ToString());

            string option = "id";

            MessageBox.Show("Search Employee: " + emp.employeeID);

            if (emp.EmployeeID == 0)
            {
                EmptyField();
                List<string> list =new List<string> { "false" };
                return list;
            }
            else if (!isMatchId)
            {
                NotMatchMessages(isMatchId, true, true, true);
                List<string> list = new List<string> { "false" };
                return list;
            }
            else
            {
                List<string> list = EmployeeDB.SearchRecord(emp,option);
                return list;
            }

        }

        public List<string> SearchEmployeeFirstName(Employee emp)
        {
            // Setting the regex
            Regex regexName = new Regex(namePattern);
            bool isMatchFirstName = regexName.IsMatch(emp.FirstName.ToString());

            string option = "firstName";

            if (emp.FirstName.ToString() == "")
            {
                EmptyField();
                List<string> list = new List<string> { "false" };
                return list;
            }
            else if (!isMatchFirstName)
            {
                NotMatchMessages(true, isMatchFirstName, true, true);
                List<string> list = new List<string> { "false" };
                return list;
            }
            else
            {
                List<string> list = EmployeeDB.SearchRecord(emp, option);
                return list;
            }

        }

        public List<string> SearchEmployeeLastName(Employee emp)
        {
            // Setting the regex
            Regex regexId = new Regex(idPattern);

            Regex regexName = new Regex(namePattern);
            bool isMatchLastName = regexName.IsMatch(emp.LastName.ToString());

            string option = "lastName";

            if (emp.LastName.ToString() == "")
            {
                EmptyField();
                List<string> list = new List<string> { "false" };
                return list;
            }
            else if (!isMatchLastName)
            {
                NotMatchMessages(true, true, isMatchLastName, true);
                List<string> list = new List<string> { "false" };
                return list;
            }
            else
            {
                List<string> list = EmployeeDB.SearchRecord(emp, option);
                return list;
            }

        }

        public bool DeleteEmployee(Employee emp)
        {
            bool isDeleted = EmployeeDB.DeleteRecord(emp);

            return isDeleted;
        }
        public List<Employee> ShowAllRecords()
        {
            List<Employee> allRecords = EmployeeDB.GetAllRecords();

            return allRecords;
        }
        public void NotMatchMessages(bool isMatchId, bool isMatchFirstName, bool isMatchLastName, bool isMatchJobTitle) 
        {
            if (!isMatchId) 
            {
                MessageBox.Show("Wrong input format for Employee ID:" +
                    "\nEmployee ID must me composed of a four digit number.\nExample: 1234.", "Wrong Input Format");
            }
            if (!isMatchFirstName)
            {
                MessageBox.Show("Wrong input format for First Name: \nLast Name must me composed of characters only." +
                " Composed names are allowed.\nExample: Bonnie, Bonnie Nunes.", "Wrong Input Format");
            }
            if (!isMatchLastName)
            {
                MessageBox.Show("Wrong input format for Last Name: \nLast Name must me composed of characters only." +
                " Composed names are allowed.\nExample: Castro, de Castro Nunes.", "Wrong Input Format");
            }
            if (!isMatchJobTitle)
            {
                MessageBox.Show("Wrong input format for Job Title: \nJob description must me composed of characters only." +
                " Composed are allowed.\nExample: Programmer, SQL Programmer.", "Wrong Input Format");
            }
        }
        public void EmptyField()
        {
            MessageBox.Show("Some field is empty.", "Empty Field Error");
        }
    }
}