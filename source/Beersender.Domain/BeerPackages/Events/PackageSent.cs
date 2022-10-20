namespace Beersender.Domain.BeerPackages.Events;

public record PackageSent(Guid PackageId) : Event(PackageId);