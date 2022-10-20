namespace Beersender.tests;

public partial class When_add_shipping_label : Beer_package_test
{
    [Fact]
    public void And_label_is_valid_then_label_is_added()
    {
        Given(
            Package1_created());

        When(
            Add_valid_shipping_label_to_package1());

        Then(
            Valid_shipping_label_added_to_package1());
    }
}

