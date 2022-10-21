namespace Beersender.tests;

public partial class WhenSendPackage : BeerPackageTest
{
    [Fact]
    public void And_label_is_added_then_package_is_sent()
    {
        Given(
            Package1Created(),
            ValidShippingLabelAddedToPackage1());

        When(
            SendPackage1());

        Then(
            Package1Sent());
    }

    [Fact]
    public void And_no_label_is_added_then_package_is_not_sent()
    {
        Given(
            Package1Created());

        When(
            SendPackage1());

        Then(
            Package1FailedToSendBecauseNoLabel());
    }
}