namespace Beersender.tests;

public partial class WhenAddShippingLabel : BeerPackageTest
{
    [Fact]
    public void And_label_is_valid_then_label_is_added()
    {
        Given(Package1Created());

        When(Add_valid_shipping_label_to_package1());

        Then(ValidShippingLabelAddedToPackage1());
    }
}