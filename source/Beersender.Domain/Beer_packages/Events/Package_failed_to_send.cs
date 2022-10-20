namespace Beersender.Domain.Beer_packages.Events;

public sealed record Package_failed_to_send(Guid Package_id): Package_event(Package_id);
