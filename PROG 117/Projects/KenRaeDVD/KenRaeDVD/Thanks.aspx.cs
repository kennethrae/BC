using System;
using System.Net.Mail;

namespace KenRaeDVD
{
    public partial class Thanks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the value of these parameters from the URL
            LabelCustNum.Text = Request.QueryString["id"];
            LabelFirstName.Text = Request.QueryString["fname"];
            LabelLastName.Text = Request.QueryString["lname"] + ",";
            LabelTitle.Text = Request.QueryString["title"];
            LabelPaid.Text =  Request.QueryString["price"];

            //use the built in mail object, and set up its properties
            MailMessage mail = new MailMessage();        // using System.Net.Mail;
//          mail.From = new MailAddress("fjrkurt@gmail.com", "Kurt’s Super DVD Store");
            mail.From = new MailAddress("realwork60@gmail.com", "Ken’s Super DVD Store");

            // next address SHOULD be from user’s login, we’ll hardcode instead
            mail.To.Add(new MailAddress("kenneth.rae@bellevuecollege.edu"));

            mail.Subject = "Your DVD is on the way!";

            // not the most eloquent way of setting up the body!
            mail.Body = "Thank you "+ LabelFirstName.Text + " " + LabelLastName.Text + " for your order. \r\n " +
                        "You ordered: " + LabelTitle.Text + 
                        "\r\n You paid: " + LabelPaid.Text +
                        "\r\n  Your customer number is: " + LabelCustNum.Text +
                        "\r\n  \r\n  Thank you for your order." +
                        "\r\n The Super DVD Store Team";

            // use built in SMTP mail client to send email to the purchaser
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // using gmail as my client, port 587
            // note you have to reduce the security setting on your mail account for this to work

            // or you could do it this way Ken.
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = "smtp.gmail.com";
            //smtpClient.Port = 587;

            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("realwork60@gmail.com", "hiddenPassword");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mail);
                LabelStatus.Text = "A Confirmation Email was sent successfully.  Thanks again.";
            }
            catch (Exception ex)
            {
                LabelStatus.Text = "Unfortunately, we could not send you a Confirmation Email, but rest assured, we will ship you the product you ordered.  Thanks again.<br />" + ex.Message;
            }

        }
    }
}