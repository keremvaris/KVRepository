using System;
using System.Collections.Generic;
using System.Text;

namespace DWPR
{
	using System.Web.Mail;
	using System;
    using System.Net.Mail;

	public class SMTPSSender
	{
		public static bool SendEmail(string server, string from, string pwd, string to, string subject, string body)
		{
            SmtpClient smtp = new SmtpClient();
			try
			{
				System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
				myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", server);
				myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
				myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
             
                
				//sendusing: cdoSendUsingPort, value 2, for sending the message using         
				//the network.        
				//smtpauthenticate: Specifies the mechanism used when authenticating         
				//to an SMTP         
				//service over the network. Possible values are:        
				//- cdoAnonymous, value 0. Do not authenticate.        
				//- cdoBasic, value 1. Use basic clear-text authentication.         
				//When using this option you have to provide the user name and password         
				//through the sendusername and sendpassword fields.        
				//- cdoNTLM, value 2. The current process security context is used to         
				// authenticate with the service.        

				myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //Use 0 for anonymous        
				myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from);
				myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword",  pwd);
				myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                
				myMail.From = from;
				myMail.To = to;
				myMail.Subject = subject;
                myMail.BodyEncoding = Encoding.GetEncoding("windows-1254");    
				myMail.BodyFormat = MailFormat.Html;
				myMail.Body = body;
                smtp.Timeout = 20000;
				System.Web.Mail.SmtpMail.SmtpServer = server + ":465";
				System.Web.Mail.SmtpMail.Send(myMail); 
                
                
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(to,ex);
			}
		}
	}
}
