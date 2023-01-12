using System.Diagnostics;
using Lesson35MVC.Data;

// ReSharper disable NotAccessedField.Local

namespace Lesson35MVC;

// measure app memory consumption every 3 sec
public sealed class CustAppService : IHostedService
{
    private Timer _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(StateCallback, null, TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(3));
        return Task.CompletedTask;
    }

    private static void StateCallback(object state) =>
        Settings.AppMemoryState =
            $"Current app pool: {Process.GetCurrentProcess().WorkingSet64 / 1000000}mb";


    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}