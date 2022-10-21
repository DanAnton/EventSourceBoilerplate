using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Beersender.Domain.Events;
using System.Text.Json;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options) : base(options)
    {
    }

    public DbSet<PersistedEvent>? PersistedEvents { get; set; }
}

public class PersistedEvent
{
    public int Id { get; set; }
    public Guid AggregateId { get; set; }
    public string? EventType { get; set; }
    public string? EventBody { get; set; }
    public DateTimeOffset DateTimeStamp { get; set; }

    private IEvent? _event;
    [NotMapped]
    public IEvent Event
    {
        get
        {
            if (_event == null)
            {
                var type = Type.GetType(EventType);
                _event = (IEvent)JsonSerializer.Deserialize(EventBody, type);
            }
            return _event;
        }
        set
        {
            if (!(_event?.Equals(value) ?? false))
            {
                _event = value;

                EventType = _event.GetType().AssemblyQualifiedName;
                EventBody = JsonSerializer.Serialize(_event, _event.GetType());
            }
        }
    }
}
