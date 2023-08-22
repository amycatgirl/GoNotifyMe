using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

using GoNotifyMe;
using GoMarket;

namespace NotifyService.TimerHostedService;

public sealed class TimerService : IHostedService, IAsyncDisposable
{
    private readonly Task _completedTask = Task.CompletedTask;
    private readonly ILogger<TimerService> _logger;

    private readonly ApiClient _client;
    private readonly Options _config;
    private readonly MailClient _mail;

    private int _executionCount = 0;
    private Timer? _timer;

    public TimerService(ILogger<TimerService> logger, ApiClient client, Options config)
    {
        _logger = logger;
        _client = client;
        _config = config;
        _mail = new MailClient(config);
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("{Service} is running.", nameof(TimerHostedService));
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(_config.FetchInterval));

        return _completedTask;
    }

    private async void DoWork(object? state)
    {
        int count = Interlocked.Increment(ref _executionCount);

        _logger.LogInformation(
            "{Service} is working, execution count: {Count:#,0}",
            nameof(TimerHostedService),
            count);

        _logger.LogInformation("Fetching products...");

        var products = _client.GetProductList().Products;

        // TODO: Read info from CSV File
        var needRestock = products!.Where(p => p.TotalOnHand < 5).ToList();

        var message = _mail.GenerateRestockMessage(needRestock);

        await _mail.SendMessage(message);
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "{Service} is stopping.", nameof(TimerHostedService));

        _timer?.Change(Timeout.Infinite, 0);

        return _completedTask;
    }

    public async ValueTask DisposeAsync()
    {
        if (_timer is IAsyncDisposable timer)
        {
            await timer.DisposeAsync();
        }

        _timer = null;
    }

}
