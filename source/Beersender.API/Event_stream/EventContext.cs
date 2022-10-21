using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Beersender.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Beersender.API.Event_stream;

// TODO migrations
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

    // TODO
    [NotMapped]
    public Event Event { get; set; }
}

