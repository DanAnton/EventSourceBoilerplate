namespace Beersender.Domain.Infrastructure;

public interface Event
{
}

public record Event_message(Guid Aggregate_id, Event Event);