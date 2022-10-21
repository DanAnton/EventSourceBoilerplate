using Beersender.API.Event_stream;

namespace Beersender.API.ReadProjections;

public class EventPollingService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Event_router _router;

    public EventPollingService(IServiceProvider serviceProvider, Event_router router)
    {
        _serviceProvider = serviceProvider;
        _serviceProvider = serviceProvider;
        _router = router;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // TODO: this value should be persisted for checkpoints.
        var last_event_id = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<EventContext>();

            var newEvents = context.Events
                .Where(e => e.Id > last_event_id)
                .OrderBy(e => e.Id);
            foreach (var persistedEvent in newEvents)
            {
                _router.Dispatch(persistedEvent.Event);
                last_event_id = persistedEvent.Id;
            }

            await Task.Delay(1000);
        }
    }
}