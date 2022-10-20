namespace Beersender.Domain.BeerPackages.Events;

public record PackageUnsent(Guid PackageId) : Event(PackageId);
