using System;
using System.Configuration;
using System.Data.SqlClient;

namespace KenRaeDVD
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDdbCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDID, DVDtitle, DVDartist, DVDrating, DVDprice FROM DVDtable", conn);
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                DVDRepeater.DataSource = reader;
                DVDRepeater.DataBind();
                reader.Close();
            }
            finally
            {
                conn.Close();
            }

        }

        protected void DVDRepeater_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            if (e.CommandName == "DVDdetails")
            {
                Response.Redirect("Details.aspx?id=" + e.CommandArgument);  // e.CommandArgument is DVDID as coded on aspx page
            }
            else if (e.CommandName == "BuyDVD")
            {
                Response.Redirect("BuyDVD.aspx?id=" + e.CommandArgument);   // e.CommandArgument is DVDID as coded on aspx page
            }

        }
    }
}