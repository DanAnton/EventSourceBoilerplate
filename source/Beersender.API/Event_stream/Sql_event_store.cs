using Beersender.Domain.Infrastructure;

namespace Beersender.API.Event_stream;

public class Sql_event_store
{
    public IEnumerable<Event> Get_events(Guid aggregate_id)
    {
        yield break;
    }

    public void Publish(Guid aggregate_id, Event @event)
    {

    }
}

