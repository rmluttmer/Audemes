using System;
using System.Data;
using System.Configuration;
using System.IO;
//using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text; 
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

/// <summary>
/// emailManager sending emails based on form submissions.
///     -emailFormInfo takes a message to email based on form data.  
/// </summary>
public static class emailManager
{

    public static void emailFormInfo(string message)
    {        
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("mail-relay.iu.edu");

        mail.From = new MailAddress("no-reply@audeme.informatics.iupui.edu");
        mail.To.Add("jrhesch@umail.iu.edu");
        mail.Subject = "Audeme Request Form Submission";
        mail.Body = message;
        mail.IsBodyHtml = true;

        SmtpServer.Port = 25;
        
	SmtpServer.Send(mail);
    }   
}
