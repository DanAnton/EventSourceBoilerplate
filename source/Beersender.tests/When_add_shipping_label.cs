namespace Beersender.tests;

public partial class When_add_shipping_label : Beersender_test
{
    [Fact]
    public void Then_shipping_label_is_added()
    {
        Given();

        When(
            Add_shipping_label1()
            );

        Then(
            Shipping_label1_added()
            );
    }
}

