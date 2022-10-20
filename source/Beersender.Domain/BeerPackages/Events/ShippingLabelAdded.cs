namespace Beersender.Domain.BeerPackages.Events;

public record struct ShippingLabelAdded(Guid PackageId);