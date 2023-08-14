using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace GoNotifyMe
{
    internal class Mail
    {
        private readonly string _ServerURL;
        private readonly int _Port;
        private readonly bool _UseSSL;

        private readonly string _User;
        private readonly string _Password;

        public Mail(string url, int port, string user, string password, bool useSSL = true)
        {
            _ServerURL = url;
            _Port = port;
            _User = user;
            _Password = password;
            _UseSSL = useSSL;
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
    }
}
