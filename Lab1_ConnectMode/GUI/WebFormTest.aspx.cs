using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Lab1_ConnectMode.DAL;
using System.Windows.Forms;

namespace Lab1_ConnectMode.GUI
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonConnectDatabase_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = UtilityDB.GetDBConnection();
            MessageBox.Show(Convert.ToString(connDB.State), "Database Connection");
        }
    }
}