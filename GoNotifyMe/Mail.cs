using MailKit.Net.Smtp;
using MailKit.Security;

using MimeKit;
using MimeKit.Text;

using GoMarket;
using GoNotifyMe.Template;

namespace GoNotifyMe
{
    internal class MailClient
    {
        private readonly bool _UseSSL;

        private readonly Options _Config;

        private readonly Generator templateGenerator;

        /**
        <summary>
        Mail client constructor
        </summary>
        <param name="config">Configuration</param>
        <param name="url">SMTP server url</param>
        <param name="port">SMTP server port</param>
        <param name="user">SMTP username for authentication</param>
        <param name="password">SMTP password for authentication</param>
        <param name="useSSL">Whether should the client use SSL for SMTP</param>
        */
        public MailClient(Configuration config)
        {
            _Config = config.Options!;

            templateGenerator = new Generator();
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_Config.Mail!.Server, _Config.Mail.Port, _Config.Mail.Method);

                client.Authenticate(_Config.Mail.Username, _Config.Mail.Password);

                client.Send(message);

                client.Disconnect(true);
            }
        }

        /// <summary>
        /// Generate a message using a list of products
        /// </summary>
        /// <param name="products"></param>
        /// <returns>A message</returns>
        public MimeMessage GenerateRestockMessage(List<ApiProductListItem> products)
        {
            var RestockMessage = new MimeMessage();

            RestockMessage.From.Add(new MailboxAddress("GoNotifyMe Automated", _Config.Mail!.Email));
            RestockMessage.To.Add(new MailboxAddress(null, _Config.TargetEmail));
            RestockMessage.Subject = $"[GoNotifyMe] {products.Count} product{(products.Count > 1 ? "s" : String.Empty)} need restock";

            RestockMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<h1>Some items require a restock</h1>\n<p>The following items need restock:</p>\n{templateGenerator.GenerateHtmlList(products)}"
            };

            return RestockMessage;
        }
    }
}
