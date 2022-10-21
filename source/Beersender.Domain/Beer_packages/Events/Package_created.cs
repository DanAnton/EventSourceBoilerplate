namespace Beersender.Domain.Beer_packages.Events;

public record Package_created(Guid Package_id) : IEvent;