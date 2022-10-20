namespace Beersender.Domain.Beer_packages.Events;

public record struct Package_sent_failled(Guid Package_id, string errorMessage);