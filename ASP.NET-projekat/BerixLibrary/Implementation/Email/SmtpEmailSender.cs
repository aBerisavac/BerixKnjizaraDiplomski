using Application.DTOs;
using Application.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void SendEmail(EmailOut emailOut)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("", "")
            };

            var subject = emailOut.Subject;
            var body = emailOut.Content;
        }
    }
}
