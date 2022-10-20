namespace Beersender.tests;

public partial class When_send_package : Beer_package_test
{
    [Fact]
    public void And_label_is_added_then_package_is_sent()
    {
        Given(
            Package1_created(),
            Valid_shipping_label_added_to_package1());

        When(
            Send_package1());

        Then(
            Package1_sent());
    }

    [Fact]
    public void And_no_label_is_added_then_package_is_not_sent()
    {
        Given(
            Package1_created());

        When(
            Send_package1());

        Then(
            Package1_failed_to_send_because_no_beers());
    }
}
