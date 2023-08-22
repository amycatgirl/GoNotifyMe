using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NotifyService.TimerHostedService;
using GoNotifyMe;
using Microsoft.Extensions.Logging;


Configuration configuration = new Configuration(@"../Configuration/config.toml");

configuration.ParseConfiguration();

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<TimerService>(serviceProvider => new TimerService(
    serviceProvider.GetService<ILogger<TimerService>>()!,
    new GoMarket.ApiClient(configuration.Options!.Token!, "GoNotifyMe Automated"),
    configuration.Options!
));

IHost host = builder.Build();
host.Run();