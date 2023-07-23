using Tomlet;
using Tomlet.Attributes;
using Tomlet.Models;

namespace GoNotifyMe
{

    public class EmailOptions
    {
        [TomlProperty("email")]
        public string? Email { get; set; }
        [TomlProperty("password")]
        public string? Password { get; set; }
        [TomlProperty("server")]
        public string? Server { get; set; }
        [TomlProperty("port")]
        public int Port { get; set; }
    }

    public class Options
    {
        [TomlProperty("token")]
        internal string? Token { get; set; }
        [TomlProperty("target")]
        internal string? Target { get; set; }
        [TomlProperty("interval")]
        internal Int16 FetchInterval { get; set; }
        [TomlProperty("mail")]
        internal EmailOptions? Mail { get; set; }

    }

    internal class Configuration
    {
        public Configuration(string? ConfigurationPath)
        {
            DefaultConfigurationPath = Path.GetFullPath(@".\Configuration\config.toml");
            CurrentConfigurationPath = ConfigurationPath ?? DefaultConfigurationPath;
        }

        public string DefaultConfigurationPath { get; }
        public string CurrentConfigurationPath { get; }

        public Options? Options { get; set; }

        public void ParseConfiguration()
        {
            TomlDocument configurationFile = TomlParser.ParseFile(CurrentConfigurationPath);
            this.Options = TomletMain.To<Options>(configurationFile);
        }

    }
}
