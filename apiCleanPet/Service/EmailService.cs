using apiCleanPet.Service.Interfaces;
using apiCleanPet.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace apiCleanPet.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> EnviarEmailAsync(string destinatario, string assunto, string mensagem)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Meu sistema", "jasmimandiara@gmail.com"));
            email.To.Add(MailboxAddress.Parse(destinatario));
            email.Subject = assunto;

            email.Body = new TextPart("plain") { Text = mensagem };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("jasmimandiara@gmail.com", "dlrj cmux ehfz llri"); // App Password
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar email: {ex.Message}");
                return false;
            }
        }
    }
}