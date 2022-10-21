using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.BeerPackages;

public record struct PackageCreated(Guid PackageId) : IEvent;

public record struct ShippingLabelAdded(Guid PackageId, ShippingLabel ShippingLabel) : IEvent;

public record struct PackageSent(Guid PackageId) : IEvent;

public record struct PackageFailedToSend(Guid PackageId, SendFailReason FailReason) : IEvent;

public enum SendFailReason
{
    NoShippingLabel,
    NoBeersInPackage
}