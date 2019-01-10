using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Service.Email.DTO;
using Service.Email.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Email.Controllers
{
    public class BaseController : Controller
    {
        #region [ EnviarEmail ]
        public void EnviarEmail(EmailDTO emailDTO, AppSettings appSettings)
        {

            //Valida os parametros de entrada
            if (string.IsNullOrEmpty(emailDTO.assunto))
                throw new Exception("O assunto deve ser informado para enviar o e-mail");

            if (emailDTO.destinatarios.Count() == 0)
                throw new Exception("O destinatário deve ser informado para enviar o e-mail");

            if (string.IsNullOrEmpty(emailDTO.html))
                throw new Exception("O assunto html do corpo do email deve ser informado");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Destinatário", appSettings.EmailFrom));
            message.Subject = emailDTO.assunto;

            foreach (var destinatario in emailDTO.destinatarios)
                message.To.Add(new MailboxAddress(destinatario));
           
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = emailDTO.html;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("Endereço do servidor", 123);
                client.Authenticate(appSettings.AwsAccessKeyIdSMTP, appSettings.AwsSecretAccessKeySMTP);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        #endregion
    }
}
