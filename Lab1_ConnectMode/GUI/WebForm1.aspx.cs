using Lab1_ConnectMode.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Lab1_ConnectMode.BLL;
using Lab1_ConnectMode.DAL;

namespace Lab1_ConnectMode.GUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            MessageBox.Show("Database connection is " + conn.State.ToString());
        }

        protected void ButtonSaveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee(int.Parse(idTextBox.Text), firstNameTextBox.Text, lastNameTextBox.Text, jobDescriptionTextBox.Text);
                bool isSaved = emp.SaveEmployee(emp);

                if (isSaved)
                {
                    MessageBox.Show("Employee Saved:\n- " + emp.EmployeeID + "\n- " + emp.FirstName + "\n- " + emp.LastName + "\n- " + emp.JobTitle, "Saved");
                }
                else
                {
                    MessageBox.Show("Employee NOT Saved", "Not Saved");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                Employee emp = new Employee(0, "", "", "");

                if (DropDownList.SelectedIndex == 0)
                {
                    emp.EmployeeID = int.Parse(TextBoxSearch.Text.ToString());
                    list = emp.SearchEmployee(emp);

                }
                else if (DropDownList.SelectedIndex == 1)
                {
                    emp.FirstName = TextBoxSearch.Text.ToString();
                    list = emp.SearchEmployeeFirstName(emp);

                }
                else if (DropDownList.SelectedIndex == 2)
                {
                    emp.LastName = TextBoxSearch.Text.ToString();
                    list = emp.SearchEmployeeLastName(emp);
                }

                if (list[0] == "false")
                {
                    MessageBox.Show("Employee NOT Found", "Not Found");
                }
                else
                {
                    MessageBox.Show("Employee Found:\n- " + list[0] + "\n- " + list[1] + "\n- " + list[2] + "\n- " + list[3], "Found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee(int.Parse(idTextBox.Text), firstNameTextBox.Text, lastNameTextBox.Text, jobDescriptionTextBox.Text);
            bool isDeleted = emp.DeleteEmployee(emp);

            if (isDeleted)
            {
                MessageBox.Show("Employee Deleted", "Deleted");
            } else
            {
                MessageBox.Show("Employee not found", "Not Deleted");
            }
        }

        protected void listAllButton_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee(); 
            List<Employee> allRecords = emp.ShowAllRecords();

            if (allRecords.Count > 0)
            {
                GridView1.DataSource = allRecords;
                GridView1.DataBind();
            }
            else
            {
                MessageBox.Show("No records found", "Empty table");
            }
        }

        protected void SearchFirstName_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee(0, firstNameTextBox.Text, null, null);
                List<string> list = emp.SearchEmployeeFirstName(emp);

                if (list[0] == "false")
                {
                    MessageBox.Show("Employee NOT Found", "Not Found");
                }
                else
                {
                    MessageBox.Show("Employee Found:\n- " + list[0] + "\n- " + list[1] + "\n- " + list[2] + "\n- " + list[3], "Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected void ButtonSearchLastName_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee(0, null, lastNameTextBox.Text, null);
                List<string> list = emp.SearchEmployeeLastName(emp);

                if (list[0] == "false")
                {
                    MessageBox.Show("Employee NOT Found", "Not Found");
                }
                else
                {
                    MessageBox.Show("Employee Found:\n- " + list[0] + "\n- " + list[1] + "\n- " + list[2] + "\n- " + list[3], "Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}