using System;

namespace KenRaeDVD
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelDVDID.Text = Request.QueryString["id"];    // Retrieve the value of the id parameter from the URL
        }
    }
}