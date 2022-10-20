using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;

public partial class When_add_shipping_label
{
    private Guid package1_id = Guid.NewGuid();
    private Shipping_label shipping_label = new Shipping_label(Shipping_provider.UPS,"1234567");
    private Add_shipping_label Add_shipping_label1()
    {
        return new Add_shipping_label(package1_id,shipping_label);
    }

    private Shipping_label_added Shipping_label_added()
    {
        return new Shipping_label_added(shipping_label);
    }
}
