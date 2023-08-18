using MailKit.Net.Smtp;
using MailKit.Security;

using MimeKit;
using MimeKit.Text;

using GoMarket;

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

        public Mail(Configuration config, string url, int port, string user, string password, bool useSSL = true)
        {
            _ServerURL = url;
            _Port = port;
            _User = user;
            _Password = password;
            _UseSSL = useSSL;
            _Config = config;
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

        private string generateTemplate(List<ApiProduct> products)
        {
            string HtmlList = "<ul>" + products.ToArray().Select(product => $"<li>{product.Name}: {product.InStock} in Stock</li>") + "</ul>";

            return @$"
            <h1>Some items require a restock</h1>
            
            <p>The following items need restock:</p>
            
            {HtmlList}
            ";

        }

        public MimeMessage GenerateRestockMessage(List<ApiProduct> products)
        {
            // 1. Get products
            // 2. Get current app configuration
            // 3. Set mail recipients
            // 4. Return a RestockMessage


            var RestockMessage = new MimeMessage();



            RestockMessage.From.Add(new MailboxAddress(null, _Config.Options!.Mail!.Email));
            RestockMessage.To.Add(new MailboxAddress(null, _Config.Options!.TargetEmail));
            RestockMessage.Subject = $"[GoNotifyMe] {products.Count} product{(products.Count > 1 ? "s" : String.Empty)} need restock";

            RestockMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = generateTemplate(products)
            };

            return RestockMessage;
        }
    }
}
