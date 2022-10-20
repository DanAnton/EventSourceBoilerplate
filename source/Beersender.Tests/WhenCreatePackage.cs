using Beersender.Domain.BeerPackages.Commands;
using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Tests;

public partial class WhenCreatePackage : BeersenderTest
{
    [Fact]
    public void ThenPackageIsCreated()
    {
        Given(); // Occured events
        When(CreatePackage1); // Command
        Then(PackageCreated1); // New events
    }
    
    
}

public partial class WhenCreatePackage
{
    private readonly Guid _packageId1 = Guid.NewGuid();
    private CreatePackage CreatePackage1 => new CreatePackage(_packageId1);
    private PackageCreated PackageCreated1 => new PackageCreated(_packageId1);
}