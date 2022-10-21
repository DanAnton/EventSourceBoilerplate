using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_create_label : Beersender_test
    {
        [Fact]
        public void Then_label_is_created()
        {
            var shippingLabel = new Shipping_label(Guid.NewGuid(),Shipping_provider.DHL, "test123");
            Given();


            When(
                new Add_shipping_label(shippingLabel)
                );

            Then(
                new Shipping_label_added(shippingLabel)
                );
        }
    }
}