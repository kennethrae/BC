using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace KenRaeDVD.Admin
{
    public partial class EditDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    // Run first time only
            {
                LoadDVDList();
            }
        }

        private void LoadDVDList()
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDID, DVDtitle FROM DVDtable ORDER BY DVDtitle", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                DropDownListDVD.DataSource = reader;
                DropDownListDVD.DataValueField = "DVDID";   // note the binding here so we can use the ID
                DropDownListDVD.DataTextField = "DVDtitle"; // but display the user friendly name
                DropDownListDVD.DataBind();
                reader.Close();
            }
            catch
            {
                LabelErrorMessage.Text = "Error loading the list of DVDs! <br />";
            }
            finally
            {
                conn.Close();
            }
            ButtonUpdateDVD.Enabled = false;
            ButtonDeleteDVD.Enabled = false;

            LabelErrorMessage.Text = "";
            TextBoxDVDtitle.Text   = "";
            TextBoxDVDartist.Text  = "";
            TextBoxDVDrating.Text  = "";
            TextBoxDVDprice.Text   = "";
        }

        protected void ButtonDVDselect_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDtitle, DVDartist, DVDrating, DVDprice " +
                                  "  FROM DVDtable                                 " +
                                  " WHERE DVDID = @DVDID", conn);
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = DropDownListDVD.SelectedItem.Value;    // value = DVD ID primary key
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())              // if reader successfully read next row
                {
                    TextBoxDVDtitle.Text  = reader["DVDtitle"].ToString();
                    TextBoxDVDartist.Text = reader["DVDartist"].ToString();
                    TextBoxDVDrating.Text = reader["DVDrating"].ToString();

                    string tempString = reader["DVDprice"].ToString();
                    TextBoxDVDprice.Text  = Convert.ToString(Math.Round(Convert.ToDecimal(tempString), 2));
                }
                reader.Close();

                ButtonUpdateDVD.Enabled = true;
                ButtonDeleteDVD.Enabled = true;
            }
            catch
            {
                LabelErrorMessage.Text = "Error loading the DVD details! < br />";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonUpdateDVD_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("UPDATE DVDtable SET DVDtitle = @DVDtitle, DVDartist = @DVDartist, " +
                                  "                    DVDrating = @DVDrating, DVDprice = @DVDprice  " +
                                  " WHERE DVDID = @DVDID", conn);
            comm.Parameters.Add("@DVDtitle", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@DVDtitle"].Value = TextBoxDVDtitle .Text;
            comm.Parameters.Add("@DVDartist", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@DVDartist"].Value = TextBoxDVDartist.Text;
            comm.Parameters.Add("@DVDrating", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDrating"].Value = TextBoxDVDrating.Text;
            comm.Parameters.Add("@DVDprice", System.Data.SqlDbType.Money);
            comm.Parameters["@DVDprice"].Value = TextBoxDVDprice.Text;
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = DropDownListDVD.Text;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();     // Execute the SQL Update Statement
                LoadDVDList();
            }
            catch
            {
                LabelErrorMessage .Text = "Error updating the DVD details! <br/>";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonDeleteDVD_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("DELETE FROM DVDtable WHERE DVDID = @DVDID", conn);
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = DropDownListDVD.SelectedItem.Value;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();     // Execute the SQL Delete Statement
                LoadDVDList();
            }
            catch
            {
                LabelErrorMessage.Text = "Error deleting DVD! <br />";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../default.aspx");
        }

    }
}