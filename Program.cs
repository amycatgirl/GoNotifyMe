using GoNotifyMe;
using GoNotifyMe.Clients;

Configuration configuration = new Configuration(@"C:\Users\rauly\source\repos\GoNotifyMe\Configuration\config.toml");

configuration.ParseConfiguration();

ApiClient client = new ApiClient(configuration.Options!.Token!, null);

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

var productsFromAPI = client.GetAllProducts();

Console.WriteLine(productsFromAPI.Products!.Count);

var firstProduct = productsFromAPI.Products[0];

Console.WriteLine(firstProduct!.Name);
Console.WriteLine(firstProduct!.Price.GetType());

var a = Console.ReadLine();
