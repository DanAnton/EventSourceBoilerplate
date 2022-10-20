namespace Beersender.Domain.Beer_packages.Events;

public record struct Package_sent_failed(Guid Package_id, string error);