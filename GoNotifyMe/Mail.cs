using MailKit.Net.Smtp;
using MailKit.Security;

using MimeKit;
using MimeKit.Text;

using GoMarket;
using GoNotifyMe.Template;

namespace GoNotifyMe
{
    public class MailClient
    {
        private readonly bool _UseSSL;

        private readonly Options _Config;

        private readonly Generator templateGenerator;

        /**
        <summary>
        Mail client constructor
        </summary>
        <param name="config">Configuration</param>
        */
        public MailClient(Options config)
        {
            _Config = config;

            templateGenerator = new Generator();
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="message"></param>
        public async Task SendMessage(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_Config.Mail!.Server, _Config.Mail.Port, _Config.Mail.Method);

                client.Authenticate(_Config.Mail.Username, _Config.Mail.Password);

                await client.SendAsync(message);

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
