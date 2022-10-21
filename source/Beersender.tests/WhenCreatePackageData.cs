using Beersender.Domain.BeerPackages;

namespace Beersender.tests;

public partial class WhenCreatePackage
{
    protected CreatePackage CreatePackage1()
    {
        return new CreatePackage(Package1Id);
    }
}