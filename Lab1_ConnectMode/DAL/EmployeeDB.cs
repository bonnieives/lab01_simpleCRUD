using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1_ConnectMode.BLL;
using Lab1_ConnectMode.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab1_ConnectMode.DAL
{
    public class EmployeeDB
    {
        // 1. A method to sabe an employee record to the database

        /// <summary>
        /// This method saves an employee record to the database
        /// </summary>
        /// <param name="emp"></param>
        /// 

        // Insert into Employees
        // values (8,'John','Doe','Java Programmer')

        // VERSION 01
        public static List<string> SearchRecord(Employee emp, String option)
        {
            List<string> employeeDataList = new List<string>();

            String command = "";
            String parameter = "";
            object parameterValue;

            if (option == "id")
            {
                command = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
                parameter = "@EmployeeID";
                parameterValue = emp.EmployeeID;
            } else if (option == "firstName")
            {
                command = "SELECT * FROM Employees WHERE FirstName = @FirstName";
                parameter = "@FirstName";
                parameterValue = emp.FirstName;

            } else
            {
                command = "SELECT * FROM Employees WHERE LastName = @LastName";
                parameter = "@LastName";
                parameterValue = emp.LastName;
            }


            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {

                using (SqlCommand cmdSelect = new SqlCommand(command, conn))
                {
                    cmdSelect.Parameters.AddWithValue(parameter, parameterValue);

                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string employeeId = reader["EmployeeID"].ToString();
                                string firstName = reader["firstName"].ToString();
                                string lastName = reader["lastName"].ToString();
                                string jobTitle = reader["jobTitle"].ToString();

                                employeeDataList.Add(employeeId);
                                employeeDataList.Add(firstName);
                                employeeDataList.Add(lastName);
                                employeeDataList.Add(jobTitle);
                            }
                        }
                        else
                        {
                            string isFound = "false";
                            employeeDataList.Add(isFound);
                        }
                    }
                }
            }

            return employeeDataList;
        }
        public static bool SaveRecord(Employee emp)
        {
            bool isSaved = false;

            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {

                using (SqlCommand cmdInsert = new SqlCommand("INSERT INTO Employees (EmployeeID, FirstName, LastName, JobTitle) " +
                    "VALUES (@EmployeeID, @FirstName, @LastName, @JobTitle)", conn))
                {
                    cmdInsert.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                    cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
                    cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);

                    int rowsAffected = cmdInsert.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        isSaved = true;
                    }
                }
            }

            return isSaved;
        }

        public static bool DeleteRecord(Employee emp)
        {
            bool isDeleted = false;

            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {

                using (SqlCommand cmdDelete = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", conn))
                {
                    cmdDelete.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);

                    int rowsAffected = cmdDelete.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        isDeleted = true;
                    }
                }

            }

            return isDeleted;
        }

        public static List<Employee> GetAllRecords()
        {
            List<Employee> allRecordsList = new List<Employee>();

            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                using (SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn))
                {
                    using (SqlDataReader reader = cmdSelectAll.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee();

                            emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                            emp.FirstName = reader["FirstName"].ToString();
                            emp.LastName = reader["LastName"].ToString();
                            emp.JobTitle = reader["JobTitle"].ToString();

                            allRecordsList.Add(emp);

                        }
                    }
                }
            }

            return allRecordsList;
        }
    }
}