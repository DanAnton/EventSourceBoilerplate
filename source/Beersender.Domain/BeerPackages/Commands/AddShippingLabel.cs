using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Domain.BeerPackages.Commands;

public record AddShippingLabel(Guid PackageId) : Command(PackageId)
{
    public override IEnumerable<Event> CreateEvents()
    {
        yield return new ShippingLabelAdded(PackageId);
    }
}