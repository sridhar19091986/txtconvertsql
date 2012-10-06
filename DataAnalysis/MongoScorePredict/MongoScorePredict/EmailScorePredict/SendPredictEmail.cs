using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MongoScorePredict.EmailScorePredict
{
    public static class SendPredictEmail
    {
        private static string ReadCsv(string filename)
        {
            string csv = null;
            StreamReader streamx = new StreamReader(filename, System.Text.Encoding.Default);
            csv = streamx.ReadToEnd();
            streamx.Close(); streamx.Dispose();
            return csv;
        }
        public static void SendMail(string filename)
        {
            if (SendPredictEmail.SendEmail("jc777777@163.com", "jc777",
                 "jc777777@163.com", "jc777",
                 DateTime.Now.ToLongDateString(), ReadCsv(filename), false, null,
                 "smtp.163.com", "jc777777", "123qweasd"))
                Console.WriteLine("Email sent successfully");
            else
                Console.WriteLine("Failed to send email");
        }
        /// <summary> 
        /// method to send email using SMTP server 
        /// </summary> 
        /// <param name="_FromEmail">From email address</param> 
        /// <param name="_FromName">From name</param> 
        /// <param name="_ToEmail">To email address</param> 
        /// <param name="_ToName">To name</param> 
        /// <param name="_Subject">Email subject</param> 
        /// <param name="_EmailBody">Email message body</param> 
        /// <param name="_IsBodyHtml">Is email message body HTML</param> 
        /// <param name="_Attachments">Email message file attachments</param> 
        /// <param name="_EmailServer">SMTP email server address</param> 
        /// <param name="_LoginName">SMTP email server login name</param> 
        /// <param name="_LoginPassword">SMTP email server login password</param> 
        /// <returns>TRUE if the email sent successfully, FALSE otherwise</returns> 
        private static bool SendEmail(string _FromEmail, string _FromName, string _ToEmail, string _ToName, string _Subject, string _EmailBody, bool _IsBodyHtml, string[] _Attachments, string _EmailServer, string _LoginName, string _LoginPassword)
        {
            try
            {
                // setup email header 
                System.Net.Mail.MailMessage _MailMessage = new System.Net.Mail.MailMessage();
                // Set the message sender 
                // sets the from address for this e-mail message 
                _MailMessage.From = new System.Net.Mail.MailAddress(_FromEmail, _FromName);
                // Sets the address collection that contains the recipients of this e-mail message 
                _MailMessage.To.Add(new System.Net.Mail.MailAddress(_ToEmail, _ToName));
                // sets the message subject
                _MailMessage.Subject = _Subject;
                // sets the message body 
                _MailMessage.Body = _EmailBody;
                // sets a value indicating whether the mail message body is in Html 
                // if this is false then ContentType of the Body content is "text/plain" 
                _MailMessage.IsBodyHtml = _IsBodyHtml;
                // add all the file attachments if we have any 
                if (_Attachments != null && _Attachments.Length > 0)
                    foreach (string _Attachment in _Attachments)
                        _MailMessage.Attachments.Add(new System.Net.Mail.Attachment(_Attachment));
                // SmtpClient Class Allows applications to send e-mail by using the Simple Mail Transfer Protocol (SMTP)
                System.Net.Mail.SmtpClient _SmtpClient = new System.Net.Mail.SmtpClient(_EmailServer);
                //Specifies how email messages are deliveredHere Email is sent through the network to an SMTP server
                _SmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                // Some SMTP server will require that you first authenticate against the server
                // Provides credentials for password-based authentication schemes such as basic, digest, NTLM, and Kerberos authentication
                System.Net.NetworkCredential _NetworkCredential = new System.Net.NetworkCredential(_LoginName, _LoginPassword);
                _SmtpClient.UseDefaultCredentials = true;
                _SmtpClient.Credentials = _NetworkCredential;
                //Let's send it 
                _SmtpClient.Send(_MailMessage);
                // Do cleanup 
                _MailMessage.Dispose();
                _SmtpClient = null;
            }
            catch (Exception _Exception)
            {
                // Error 
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                return false;
            }
            return true;
        }
    }
}
