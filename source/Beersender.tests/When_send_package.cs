namespace Beersender.tests;

public partial class When_send_package : Beersender_test
{
    [Fact]
    public void And_no_shipping_label_Then_package_failed_to_send()
    {
        Given();

        When(
            Send_package()
            );

        Then(
            Package_failed_to_send()
            );
    }
    [Fact]
    public void And_shipping_label_Then_package_sent()
    {
        Given(
            Shipping_label_added()
            );

        When(
            Send_package()
            );

        Then(
            Package_sent()
            );
    }
}
