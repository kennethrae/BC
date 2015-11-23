using System;
using System.Web.Security;

namespace KenRaeDVD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxUsername.Focus();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(TextBoxUsername.Text, TextBoxPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(TextBoxUsername.Text, false);   // false = non-persistant cookie
            }
            else
            {
                LabelErrorMessage.Text = "Your Username and/or Password is invalid.";
            }

        }
    }
}