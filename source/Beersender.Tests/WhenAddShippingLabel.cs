using Beersender.Domain.BeerPackages.Commands;
using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Tests;

public partial class WhenAddShippingLabel : BeersenderTest
{
    [Fact]
    public void ThenShippingLabelIsAdded()
    {
        Given(PackageCreated1); // Occured events
        When(AddShippingLabel); // Command
        Then(ShippingLabelAdded1); // New events
    }
}

public partial class WhenAddShippingLabel
{
    private readonly Guid _packageId1 = Guid.NewGuid();
    private PackageCreated PackageCreated1 => new (_packageId1);
    private AddShippingLabel AddShippingLabel => new (_packageId1);
    private ShippingLabelAdded ShippingLabelAdded1 => new (_packageId1);
}