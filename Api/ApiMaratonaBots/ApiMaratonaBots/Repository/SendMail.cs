using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ApiMaratonaBots.Models;

namespace ApiMaratonaBots.Repository
{
    public class SendMail
    {
        public static bool _SendMail(MailModel value)
        {
            AppSettings appSettings = new AppSettings
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UserName = "rafaelestevaodeveloper@gmail.com",
                Password = "124094raissa",
                PathLog = "c:\\ConsoleSendMail",
                SSL = true,
                Sender = "rafaelestevaodeveloper@gmail.com"
            };

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(appSettings.Sender);
                mail.To.Add(value.To);
                mail.Subject = value.Subject;
                mail.Body = value.Body;
                value.Copy.ToList().ForEach(mail.CC.Add);
                //mail.Attachments.Add(new Attachment(@"C:\teste.txt"));

                using (var smtp = new SmtpClient(appSettings.Host))
                {
                    smtp.EnableSsl = appSettings.SSL;
                    smtp.Port = appSettings.Port;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;

                    // seu usuário e senha para autenticação
                    smtp.Credentials = new NetworkCredential(appSettings.UserName, appSettings.Password);

                    // envia o e-mail
                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Exception:");
                Console.Write($"Message: {ex.Message}, InnerException: {ex.InnerException}");
                return false;
            }


        }
    }
}
