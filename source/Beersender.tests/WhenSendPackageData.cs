using Beersender.Domain.BeerPackages;

namespace Beersender.tests;

public partial class WhenSendPackage
{
    protected SendPackage SendPackage1()
    {
        return new SendPackage(Package1Id);
    }
}