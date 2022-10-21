using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Beersender.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Beersender.API.Event_stream;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options) : base(options)
    {
        
    }
    public DbSet<PersistedEvent> Events { get; set; }
}

public class PersistedEvent
{
    public int Id { get; set; }
    public Guid AggregateId { get; set; }
    [MaxLength(256)]
    public string EventType { get; set; }
    public string EventBody { get; set; }
    public DateTime Timestamp { get; set; }

    Event _event;
    [NotMapped]
    [JsonIgnore]
    public Event Event
    {
        get
        {
            if (_event == null)
            {
                var type = Type.GetType(EventType);
                _event = (Event)JsonSerializer.Deserialize(EventBody,type);
            }
            return _event;
        }
        set
        {
            if (!(_event?.Equals(value) ?? false))
            {
                _event = value;

                EventType = _event.GetType().AssemblyQualifiedName;
                EventBody = JsonSerializer.Serialize(_event);
            }
        }
    }
}

