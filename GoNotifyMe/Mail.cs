using MailKit.Net.Smtp;
using MailKit.Security;

using MimeKit;
using MimeKit.Text;

using GoMarket;
using GoNotifyMe.Template;

namespace GoNotifyMe
{
    internal class Mail
    {
        private readonly string _ServerURL;
        private readonly int _Port;
        private readonly bool _UseSSL;

        private readonly string _User;
        private readonly string _Password;

        private readonly Configuration _Config;

        private readonly Generator templateGenerator;

        public Mail(Configuration config, string url, int port, string user, string password, bool useSSL = true)
        {
            _ServerURL = url;
            _Port = port;
            _User = user;
            _Password = password;
            _UseSSL = useSSL;
            _Config = config;

            templateGenerator = new Generator();
        }

        public void SendMessage(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_ServerURL, _Port, SecureSocketOptions.SslOnConnect);

                client.Authenticate(_User, _Password);

                client.Send(message);

                client.Disconnect(true);
            }
        }

        public MimeMessage GenerateRestockMessage(List<ApiProduct> products)
        {
            var RestockMessage = new MimeMessage();

            RestockMessage.From.Add(new MailboxAddress(null, _Config.Options!.Mail!.Email));
            RestockMessage.To.Add(new MailboxAddress(null, _Config.Options!.TargetEmail));
            RestockMessage.Subject = $"[GoNotifyMe] {products.Count} product{(products.Count > 1 ? "s" : String.Empty)} need restock";

            RestockMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<h1>Some items require a restock</h1>\n<p>The following items need restock:</p>\n{templateGenerator.GenerateHtmlList(products)}"
            };

            return RestockMessage;
        }
    }
}
