using Beersender.Domain.Events;

namespace Beersender.Data;

public class Sql_event_store
{
    private readonly EventContext _database;

    public Sql_event_store(EventContext database)
    {
        _database = database;
    }

    public IEnumerable<IEvent?> Get_events(Guid aggregate_id)
    {
        var persistedEvents = _database.PersistedEvents?.Where(e => e.AggregateId == aggregate_id)
            .OrderBy(e => e.Id);

        if (persistedEvents is not null)
        {
            return persistedEvents.Select(e => e.Event);
        }

        return Enumerable.Empty<IEvent>();
    }

    public void Publish(Guid aggregate_id, IEvent @event)
    {
        var persisted_event = new PersistedEvent
        {
            AggregateId = aggregate_id,
            DateTimeStamp = DateTimeOffset.UtcNow,
            Event = @event
        };

        _database.PersistedEvents?.Add(persisted_event);
        _database.SaveChanges();
    }
}
