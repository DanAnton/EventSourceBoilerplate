namespace Beersender.tests;
public partial class When_send_package : Beersender_test
{
    [Fact]
    public void And_label_is_valid_Then_package_sent()
    {
        Given(
            Package_is_created_and_valid_shipping_label_is_added()
            );

        When(
            Send_package()
            );

        Then(
            Package_has_been_sent()
            );
    }

    [Fact]
    public void And_label_is_invalid_Then_package_failed_to_send()
    {
        Given(
            Package_is_created_and_invalid_shipping_label_is_added()
            );

        When(
            Send_package()
            );

        Then(
            Package_failed_to_send()
            );
    }
}

