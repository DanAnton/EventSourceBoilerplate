using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_add_shipping_label
    {
        private readonly Guid package1_id = Guid.NewGuid();
        private readonly Shipping_label shipping_label = new(Shipping_provider.DHL, "1234");

        private Add_shipping_label Add_shipping_label_for_package1()
        {
            return new Add_shipping_label(package1_id, shipping_label);
        }

        private Shipping_label_added Shipping_label_added_for_package1()
        {
            return new Shipping_label_added(package1_id, shipping_label);
        }
    }
}
