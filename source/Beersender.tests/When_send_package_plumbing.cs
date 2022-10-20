using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;

public partial class When_send_package
{
    private Guid package1_id = Guid.NewGuid();
    private Shipping_label shipping_label = new Shipping_label(Shipping_provider.UPS, "1234567");
    private Send_package Send_package()
    {
        return new Send_package(package1_id);
    }
    private Shipping_label_added Shipping_label_added()
    {
        return new Shipping_label_added(shipping_label);
    }
    private Package_sent Package_sent()
    {
        return new Package_sent(package1_id);
    }
    private Package_failed_to_send Package_failed_to_send()
    {
        return new Package_failed_to_send(package1_id);
    }
}
