using Beersender.API.EventStream;

namespace Beersender.API.ReadProjections;

public class EventPollingService : BackgroundService
{
    private readonly EventRouter _router;
    private readonly IServiceProvider _serviceProvider;

    public EventPollingService(IServiceProvider serviceProvider, EventRouter router)
    {
        _serviceProvider = serviceProvider;
        _serviceProvider = serviceProvider;
        _router = router;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // TODO: this value should be persisted for checkpoints.
        var lastEventId = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<EventContext>();

            var newEvents = context!.Events!
                .Where(e => e.Id > lastEventId)
                .OrderBy(e => e.Id);
            foreach (var persistedEvent in newEvents)
            {
                _router.Dispatch(persistedEvent.Event!);
                lastEventId = persistedEvent.Id;
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}