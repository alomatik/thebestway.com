using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TheBestWayShared.SharedForWorkerService.Dtos;

namespace TheBestWayServerWorkerServices.EmailWorkerService.MailServices
{
    public class SendMailService
    {
        IConfiguration _configuration;
        string _Host;
        int _Port;
        string _SenderName;
        string _SenderEmail;
        string _Username;
        string _Password;

        public SendMailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _Host = _configuration["SmtpSettings:Host"];
            _Port = Convert.ToInt32(_configuration["SmtpSettings:Port"]);
            _SenderName = _configuration["SmtpSettings:SenderName"];
            _SenderEmail = _configuration["SmtpSettings:SenderEmail"];
            _Username = _configuration["SmtpSettings:Username"];
            _Password = _configuration["SmtpSettings:Password"];
        }

        public void SendMail(MailandResetPasswordUrlDto mailandPasswordResetUrl)
        {

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _Host,
                Port = _Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(_Username, _Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            MailMessage message = new MailMessage
            {
                From = new MailAddress(_SenderEmail), 
                To = { new MailAddress(mailandPasswordResetUrl.Mail) }, 
                Subject = _SenderName, 
                IsBodyHtml = true,
                Body = $"<h2>Click on the link below to reset the password.</h2> <br> <a href='{mailandPasswordResetUrl.PasswordResetUrl}'> Password Reset Link </a>"
            };

            smtpClient.Send(message);
        }

    }
}
