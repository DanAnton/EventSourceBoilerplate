namespace Beersender.Domain.Infrastructure;

public interface IEvent
{
}

public record EventMessage(Guid AggregateId, IEvent Event);