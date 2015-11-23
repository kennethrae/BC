using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace KenRaeDVD.Admin
{
    public partial class AddDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxDVDtitle.Focus();
        }

        protected void ButtonAddDVD_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection conn;
                SqlCommand comm;
                string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
                conn = new SqlConnection(connectionString);
                comm = new SqlCommand(" INSERT INTO DVDtable                                  " +
                                      "        ( DVDtitle,  DVDartist,  DVDrating,  DVDprice) " +
                                      " VALUES (@DVDtitle, @DVDartist, @DVDrating, @DVDprice) ", conn);

                comm.Parameters.Add("@DVDtitle", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@DVDtitle"].Value = TextBoxDVDtitle.Text;

                comm.Parameters.Add("@DVDartist", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@DVDartist"].Value = TextBoxDVDartist.Text;

                comm.Parameters.Add("@DVDrating", System.Data.SqlDbType.Int);
                comm.Parameters["@DVDrating"].Value = TextBoxDVDrating.Text;

                comm.Parameters.Add("@DVDprice", System.Data.SqlDbType.Money);
                comm.Parameters["@DVDprice"].Value = TextBoxDVDprice.Text;

                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();             // Execute the SQL Insert Statement

                    LabelErrorMessage.Text = "";
                    TextBoxDVDartist.Text  = "";
                    TextBoxDVDtitle.Text   = "";
                    TextBoxDVDrating.Text  = "";
                    TextBoxDVDprice.Text   = "";
//                    Response.Redirect("AddDVD.aspx");
                }
                catch
                {
                    LabelErrorMessage.Text = "Error adding this DVD!  Please " +
                                          "try again later, and/or correct the entered data!";
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../default.aspx");
        }
    }
}