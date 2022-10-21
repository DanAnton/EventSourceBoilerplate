using Beersender.Domain.BeerPackages;

namespace Beersender.tests;

public abstract class BeerPackageTest : BeersenderTest
{
    protected Guid Package1Id = Guid.NewGuid();
    protected ShippingLabel ValidShippingLabel = new(ShippingProvider.PostNL, "ABCD1234");

    protected PackageCreated Package1Created()
    {
        return new PackageCreated(Package1Id);
    }

    protected ShippingLabelAdded ValidShippingLabelAddedToPackage1()
    {
        return new ShippingLabelAdded(Package1Id, ValidShippingLabel);
    }

    protected PackageSent Package1Sent()
    {
        return new PackageSent(Package1Id);
    }

    protected PackageFailedToSend Package1FailedToSendBecauseNoLabel()
    {
        return new PackageFailedToSend(Package1Id, SendFailReason.NoShippingLabel);
    }

    protected PackageFailedToSend Package1FailedToSendBecauseNoBeers()
    {
        return new PackageFailedToSend(Package1Id, SendFailReason.NoBeersInPackage);
    }
}