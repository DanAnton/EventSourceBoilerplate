using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;

public partial class When_add_shipping_label
{
    private Guid package1_id = Guid.NewGuid();
    private Shipping_label shipping_label1 = new Shipping_label(Shipping_provider.UPS, "Tracking_code");

    private Add_shipping_label Add_shipping_label1()
    {
        return new Add_shipping_label(package1_id, shipping_label1);
    }

    private Shipping_label_added Shipping_label1_added()
    {
        return new Shipping_label_added(package1_id, shipping_label1);
    }
}

