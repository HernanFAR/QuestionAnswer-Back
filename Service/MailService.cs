using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Service
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _Configuration;

        public MailService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public async Task SendEmail(EmailInformation information)
        {
            SendGridConfiguration mailConfiguration = new SendGridConfiguration();

            _Configuration.GetSection("Mail").Bind(mailConfiguration);

            SendGridClient client = new SendGridClient(mailConfiguration.ApiKey);

            EmailAddress fromEmail = new EmailAddress(mailConfiguration.From);

            List<EmailAddress> tos = new List<EmailAddress>();

            foreach (var e in information.Tos)
                tos.Add(new EmailAddress(e));

            SendGridMessage email = MailHelper.CreateSingleEmailToMultipleRecipients(
                fromEmail,
                tos,
                information.Subject,
                information.Content,
                information.Content
            );

            if (information.Copies != null)
                if (information.Copies.Count != 0)
                {
                    List<EmailAddress> copies = new List<EmailAddress>();

                    foreach (var e in information.Copies)
                        copies.Add(new EmailAddress(e));

                    email.AddCcs(copies);
                }

            Response response = await client.SendEmailAsync(email);

            if (response.StatusCode != HttpStatusCode.Accepted)
                throw new InvalidOperationException(nameof(response.StatusCode));
        }
    }
}
