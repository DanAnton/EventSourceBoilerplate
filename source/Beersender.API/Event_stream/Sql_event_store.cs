using Beersender.Domain.Infrastructure;

namespace Beersender.API.Event_stream;

public class Sql_event_store
{
    private readonly EventContext _database;

    public Sql_event_store(EventContext database)
    {
        _database = database;
    }

    public IEnumerable<Event> Get_events(Guid aggregate_id)
    {
        var events = _database.Events.Where(e => e.AggregateId == aggregate_id)
            .OrderBy(e => e.Id);

        return events.Select(e => e.Event);
    }

    public void Publish(Guid aggregate_id, Event @event)
    {
        var persisted_event = new PersistedEvent
        {
            AggregateId = aggregate_id,
            Timestamp = DateTime.UtcNow,
            Event = @event
        };

        _database.Events.Add(persisted_event);
        _database.SaveChanges();
    }
}

