namespace Beersender.tests;

public partial class WhenCreatePackage : BeerPackageTest
{
    [Fact]
    public void Then_package_is_created()
    {
        Given();

        When(CreatePackage1());

        Then(Package1Created());
    }
}