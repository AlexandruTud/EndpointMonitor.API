

using iTEC_Hackathon.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace iTEC_Hackathon
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string to, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(name: "EndPointMonitor", address: "serverionut@gmail.com"));
                message.To.Add(new MailboxAddress(name: "", address: to));
                message.Subject = subject;

                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(host: "smtp.gmail.com", port: 465, useSsl: true);
                    client.Authenticate(userName: "serverionut@gmail.com", password: "vamq kbsa vpot slie");
                    client.Send(message);

                    client.Disconnect(quit: true);

                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
