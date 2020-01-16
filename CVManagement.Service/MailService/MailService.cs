using CVManagement.Service.Extensions;
using CVManagement.Service.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CVManagement.Service.MailService
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SendMail(MailModel mailModel)
        {
            var host = _configuration.GetValue<string>("SmtpServer:Host");
            var port = _configuration.GetValue<int>("SmtpServer:Port");
            var userName = _configuration.GetValue<string>("SmtpServer:Username");
            var password = _configuration.GetValue<string>("SmtpServer:Password");
            var enableSSL = _configuration.GetValue<bool>("SmtpServer:EnableSsl");
            try
            {
                var credentials = new NetworkCredential(userName, password);
                var mail = new MailMessage()
                {
                    From = new MailAddress(userName),
                    Subject = mailModel.Subject,
                    Body = mailModel.Body
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(mailModel.EmailTo));
                if(!string.IsNullOrEmpty(mailModel.EmailCc))
                {
                    mail.CC.Add(new MailAddress(mailModel.EmailCc));
                }
                var client = new SmtpClient()
                {
                    Port = port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = host,
                    EnableSsl = enableSSL,
                    Credentials = credentials
                };
                client.Send(mail);
                return "Email Sent Successfully!";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }
        }
    }
}
