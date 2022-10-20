namespace Beersender.Domain.Beer_packages.Events;

public sealed record Package_created(Guid Package_id): Package_event(Package_id);