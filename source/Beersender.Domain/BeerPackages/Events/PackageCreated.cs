namespace Beersender.Domain.BeerPackages.Events;

public record PackageCreated(Guid PackageId) : Event(PackageId);
