namespace Beersender.Domain.Beer_packages.Events;

public record struct Package_sent(Guid Package_id, bool success);