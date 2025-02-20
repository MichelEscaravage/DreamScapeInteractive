using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;

namespace DreamScapeInteractive.Utility
{
    public static class MailSender
    {
        /*static string _companyName = "DreamScapeInteractive";
        static string _companyEmail = "schoolmailprojectssending@gmail.com";
        static string _companyPassword = "ujok gckm hvpr lkwu";*/


        static string _companyName = "DreamScapeInteractive";
        static string _companyEmail = "schoolprojectsmailserver@gmail.com";
        static string _companyPassword = "qxcx vzht wzdj ipcq";

        public static void SendEmail(string email, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_companyName, _companyEmail));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                // Validate SSL certificate properly
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                {
                    if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                        return true;

                    // Optionally, log or inspect the certificate if needed
                    Console.WriteLine($"SSL Certificate Error: {sslPolicyErrors}");
                    return false;
                };
                /*client.CheckCertificateRevocation = false;*/
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate(_companyEmail, _companyPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
