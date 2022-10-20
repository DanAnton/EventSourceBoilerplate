namespace Beersender.tests
{
    public partial class When_add_shipping_label : Beersender_test
    {
        [Fact]
        public void Then_package_label_is_added()
        {
            Given();
            
            When(Add_shipping_label_for_package1());

            Then(Shipping_label_added_for_package1());
        }
    }
}