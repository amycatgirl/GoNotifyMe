using MailKit.Security;
using Tomlet;
using Tomlet.Attributes;
using Tomlet.Models;

namespace GoNotifyMe
{

    public class EmailOptions
    {
        /// <summary>
        /// Email address of the sender
        /// </summary>
        [TomlProperty("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Username of the sender
        /// </summary>
        [TomlProperty("username")]
        public string? Username { get; set;}

        /// <summary>
        /// Password of the sender
        /// </summary>
        [TomlProperty("password")]
        public string? Password { get; set; }
        
        /// <summary>
        /// SMTP server address
        /// </summary>
        [TomlProperty("server")]
        public string? Server { get; set; }
        /// <summary>
        /// SMTP server port
        /// </summary>
        [TomlProperty("port")]
        public int Port { get; set; }
        /// <summary>
        /// Connection method
        /// </summary>
        [TomlProperty("method")]
        public SecureSocketOptions Method { get; set; }
    }

    public class Options
    {
        /// <summary>
        /// GoMarket API Token
        /// </summary>
        [TomlProperty("token")]
        public string? Token { get; set; }
        
        /// <summary>
        /// Email address where the message should be sent to
        /// </summary>
        [TomlProperty("target")]
        public string? TargetEmail { get; set; }
        /// <summary>
        /// Amount of time (in days) to wait before checking for new alerts  
        /// </summary>
        [TomlProperty("interval")]
        public Int16 FetchInterval { get; set; }

        /// <summary>
        /// Mail Options
        /// </summary>
        [TomlProperty("mail")]
        public EmailOptions? Mail { get; set; }

    }

    public class Configuration
    {
        public string DefaultConfigurationPath { get; }
        public string CurrentConfigurationPath { get; } = "";

        public Configuration(string? ConfigurationPath)
        {
            // TODO: Normalize path to OS configuration path
            DefaultConfigurationPath = Path.GetFullPath(@".\Configuration\config.toml");
            CurrentConfigurationPath = ConfigurationPath ?? DefaultConfigurationPath;
        }

        

        public Options? Options { get; set; }

        public void ParseConfiguration()
        {
            TomlDocument configurationFile = TomlParser.ParseFile(CurrentConfigurationPath);
            this.Options = TomletMain.To<Options>(configurationFile);
        }

    }
}
