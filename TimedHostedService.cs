using System.Threading;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using family_timer.Hubs;
using System.Threading.Tasks;
using System;

internal class TimedHostedService : IHostedService, IDisposable
{

    private Timer _timer;
    private IHubContext<TimerHub> _timerHubContext;

    public TimedHostedService(IHubContext<TimerHub> hubContext)
    {
        _timerHubContext = hubContext;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timerHubContext.Clients.All.SendAsync("ReceiveMessage", "Timed Background Service is starting.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, 
            TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        _timerHubContext.Clients.All.SendAsync("ReceiveMessage", "Timed Background Service is working.");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timerHubContext.Clients.All.SendAsync("ReceiveMessage", "Timed Background Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}