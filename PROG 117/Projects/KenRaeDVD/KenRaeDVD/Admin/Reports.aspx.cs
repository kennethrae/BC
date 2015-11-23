using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace KenRaeDVD.Admin
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxCustNum.Focus();
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../default.aspx");
        }

        protected void ButtonCustomers_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT CustomerID, FirstName, LastName FROM Customers", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                CustomerRepeater.DataSource = reader;
                CustomerRepeater.DataBind();
                reader.Close();
            }
            finally
            {
                conn.Close();
            }

        }

        protected void ButtonOrders_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT Orders.OrderID, Orders.CustomerID, DVDsOrdered.DVDID, DVDtable.DVDtitle FROM Orders  " +
                                 " INNER JOIN DVDsOrdered ON DVDsOrdered.OrderID = Orders.OrderID " +
                                 " INNER JOIN DVDtable ON DVDsOrdered.DVDID = DVDtable.DVDID " +
                                 " WHERE CustomerID = @CustomerID", conn);
            comm.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int);
            comm.Parameters["@CustomerID"].Value = TextBoxCustNum.Text;
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                OrderRepeater.DataSource = reader;
                OrderRepeater.DataBind();
                reader.Close();
            }
            finally
            {
                conn.Close();
            }

        }
    }
}