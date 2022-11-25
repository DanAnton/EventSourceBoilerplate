using Beersender.Domain.Infrastructure;

namespace Beersender.API.EventStream;

public class SqlEventStore
{
    private readonly EventContext _database;

    public SqlEventStore(EventContext database)
    {
        _database = database;
    }

    public IEnumerable<IEvent> GetEvents(Guid aggregateId)
    {
        var events = _database.Events!.Where(e => e.AggregateId == aggregateId)
            .OrderBy(e => e.Id);

        return events.Select(e => e.Event)!;
    }

    public void Publish(Guid aggregateId, IEvent @event)
    {
        var persistedEvent = new PersistedEvent
        {
            AggregateId = aggregateId,
            Timestamp = DateTime.UtcNow,
            Event = @event
        };

        _database.Events!.Add(persistedEvent);
        _database.SaveChanges();
    }
}