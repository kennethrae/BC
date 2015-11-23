using System;
using System.Configuration;
using System.Data.SqlClient;

namespace KenRaeDVD
{
    public partial class BuyDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUserID.Visible = false;                    // only show this label after we populate it
            DVDIDlabel.Text = Request.QueryString["id"];    // Retrieve the value of the id parameter from the URL

            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDtitle, DVDprice FROM DVDtable WHERE DVDID = @DVDID", conn);
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = Convert.ToInt32(Request.QueryString["id"]);  // Retrieve the passed DVDID from the URL
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())      // If there is something to read
                {
                    TitleLabel.Text = reader["DVDtitle"].ToString();
                    PriceLabel.Text = "$" + Convert.ToString(Math.Round(Convert.ToDecimal(reader["DVDprice"]), 2));
                }
                else
                {
                    dbErrorLabel.Text = "DVD ID " + Request.QueryString["id"] + " does not exist.";
                }
                reader.Close();
            }
            catch
            {
                dbErrorLabel.Text = "Error reading the DVD info";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void PurchaseButton_Click(object sender, EventArgs e)
        {
            bool errorOccurred = false;
            long insertedId = 0;

            SqlConnection conn;
            SqlCommand comm;
            SqlCommand comm1;
            SqlCommand comm2;
            SqlCommand comm3;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);


            if (InputCustNumberTextBox.Text.Length > 0)   // If customer number is populated
            {
                insertedId = Convert.ToInt64(InputCustNumberTextBox.Text);

                // Read FirstName and LastName of existing Customer from Customer Table
                SqlDataReader reader;
                comm = new SqlCommand("SELECT FirstName, LastName FROM Customers WHERE CustomerID = @CustomerID", conn);
                comm.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int);
                comm.Parameters["@CustomerID"].Value = insertedId;
                try
                {
                    conn.Open();
                    reader = comm.ExecuteReader();
                    if (reader.Read())      // If there is something to read
                    {
                        FirstNameTextBox.Text = reader["FirstName"].ToString();
                        LastNameTextBox.Text = reader["LastName"].ToString();
                    }
                    else
                    {
                        dbErrorLabel.Text = "Customer ID " + InputCustNumberTextBox.Text + " does not exist.";
                        errorOccurred = true;
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                // Insert New Customer into the Customers table
                comm1 = new SqlCommand("INSERT INTO Customers (FirstName, LastName)" +
                                     " VALUES (@FirstName, @LastName ); SELECT SCOPE_IDENTITY()", conn);
                comm1.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50);
                comm1.Parameters["@FirstName"].Value = FirstNameTextBox.Text;
                comm1.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50);
                comm1.Parameters["@LastName"].Value = LastNameTextBox.Text;
                try
                {
                    conn.Open();
                    insertedId = Convert.ToInt64(comm1.ExecuteScalar());    // retrieve the value of the new primary key, Customer ID.
                    LabelUserID.Text = "Your customer ID is: " + Convert.ToString(insertedId);
                    LabelUserID.Visible = true;
                }
                catch
                {
                    dbErrorLabel.Text = "Database error adding customer. <br/>";
                    errorOccurred = true;
                }
                finally
                {
                    conn.Close();
                }
                InputCustNumberTextBox.Text = Convert.ToString(insertedId);     // Display the newly assigned Customer ID on the screen.
            }


            if (!errorOccurred)        // false == errorOccurred
            {
                // Insert New Order into the Orders table
                comm2 = new SqlCommand("INSERT INTO Orders (CustomerID)" +
                                      " VALUES (@CustomerID); SELECT SCOPE_IDENTITY()", conn);
                comm2.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int);
                comm2.Parameters["@CustomerID"].Value = insertedId;
                try
                {
                    conn.Open();
                    insertedId = Convert.ToInt64(comm2.ExecuteScalar());    // retrieve the value of the new primary key, Order ID.
                }
                catch
                {
                    dbErrorLabel.Text = "Database error adding order. <br/>";
                    errorOccurred = true;
                }
                finally
                {
                    conn.Close();
                }
            }


            if (!errorOccurred)        // false == errorOccurred
            {
                // Insert New DVD Ordered into the DVDsOrdered table
                comm3 = new SqlCommand("INSERT INTO DVDsOrdered (OrderID, DVDID)" +
                                      " VALUES (@OrderID, @DVDID); SELECT SCOPE_IDENTITY()", conn);
                comm3.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
                comm3.Parameters["@OrderID"].Value = insertedId;
                comm3.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
                comm3.Parameters["@DVDID"].Value = Convert.ToInt32(DVDIDlabel.Text);
                try
                {
                    conn.Open();
                    comm3.ExecuteScalar();
                }
                catch
                {
                    dbErrorLabel.Text = "Database error adding DVD ordered. <br/>";
                    errorOccurred = true;
                }
                finally
                {
                    conn.Close();
                }
            }


            if (!errorOccurred)        // false == errorOccurred
            {
                Response.Redirect("Thanks.aspx?id=" + InputCustNumberTextBox.Text +
                                  "&title=" + TitleLabel.Text + "&price=" + PriceLabel.Text +
                                  "&fname=" + FirstNameTextBox.Text + "&lname=" + LastNameTextBox.Text);
            }

        }
    }
}