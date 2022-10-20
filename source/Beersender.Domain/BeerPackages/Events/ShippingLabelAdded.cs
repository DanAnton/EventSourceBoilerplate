namespace Beersender.Domain.BeerPackages.Events;

public record ShippingLabelAdded(Guid PackageId) : Event(PackageId);