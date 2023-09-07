using Microsoft.AspNetCore.Identity.UI.Services;
using the_squad_server.Models;
using Microsoft.Graph;
using Azure.Identity;
using Microsoft.Graph.Models;

namespace the_squad_server.Services
{
    public class EmailSender : IEmailSender
    {
        // Settings object
        private static GraphSettings? _settings;
        // App-ony auth token credential
        private static ClientSecretCredential? _clientSecretCredential;
        // Client configured with app-only authentication
        private static GraphServiceClient? _appClient;

        public EmailSender(GraphSettings settings)
        {
            _settings = settings;

            // Ensure settings isn't null
            _ = settings ??
                throw new System.NullReferenceException("Settings cannot be null");

            _settings = settings;

            if (_clientSecretCredential == null)
            {
                _clientSecretCredential = new ClientSecretCredential(
                    _settings.TenantId, _settings.ClientId, _settings.ClientSecret);
            }

            if (_appClient == null)
            {
                _appClient = new GraphServiceClient(_clientSecretCredential,
                    new[] {"https://graph.microsoft.com/.default"});
            }
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var msg = new Message
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = htmlMessage
                },
                ToRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = email
                        }
                    }
                }
            };
            Microsoft.Graph.Users.Item.SendMail.SendMailPostRequestBody body = new()
            {
                Message = msg,
                SaveToSentItems = false
            };
            try
            {
                await _appClient.Users["web@the-squad.games"].SendMail.PostAsync(body);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Mail Send Failed: {0}", ex);
            }

        }
    }
}