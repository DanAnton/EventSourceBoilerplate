using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Beersender.Domain.Events;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options) : base(options)
    {
    }

    public DbSet<PersistedEvent>? PersistedEvents {get; set;}
}

public class PersistedEvent
{
    public int Id {get; set; }
    public Guid AggregateId {get; set;}
    public string? EventType {get; set;}
    public string? EventBody {get; set;}
    public DateTimeOffset DateTimeStamp {get; set;}

    // TODO
    [NotMapped]
    public IEvent? Event { get; set; }
}
