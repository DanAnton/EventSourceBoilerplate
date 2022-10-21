using Microsoft.EntityFrameworkCore;

namespace Beersender.API.EventStream;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options) : base(options)
    {
    }

    public DbSet<PersistedEvent>? Events { get; set; }
}