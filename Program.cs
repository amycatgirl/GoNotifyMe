using GoNotifyMe;

Configuration configuration = new Configuration(@"C:\Users\rauly\source\repos\GoNotifyMe\Configuration\config.toml");

configuration.ParseConfiguration();

Console.WriteLine("Configuration Path");
Console.WriteLine(configuration.DefaultConfigurationPath);
Console.WriteLine(configuration.CurrentConfigurationPath);

Console.WriteLine("\nConfiguration Options");
Console.WriteLine($"Token: {configuration.Options?.Token}");
Console.WriteLine($"Target Email: { configuration.Options?.Target}");
Console.WriteLine($"Interval {configuration.Options?.FetchInterval}");
Console.WriteLine("\nEmail Configuration");
Console.WriteLine(configuration.Options?.Mail?.Email);
Console.WriteLine(configuration.Options?.Mail?.Password);
Console.WriteLine(configuration.Options?.Mail?.Server);
Console.WriteLine(configuration.Options?.Mail?.Port);

var a = Console.ReadLine();
