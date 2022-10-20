using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;
public partial class When_send_package
{
    private Guid package1_id = Guid.NewGuid();
    private Shipping_label valid_shipping_label = new Shipping_label(Shipping_provider.DHL, "Tracking_code");
    private Shipping_label invalid_shipping_label = new Shipping_label(Shipping_provider.FedEx, "error");
    public IEnumerable<Package_event> Package_is_created_and_valid_shipping_label_is_added()
    {
        var created_event = new Package_created(package1_id);
        var shipping_label_added_event = new Shipping_label_added(package1_id, valid_shipping_label);

        return new Package_event[] { created_event, shipping_label_added_event };
    }

    public IEnumerable<Package_event> Package_is_created_and_invalid_shipping_label_is_added()
    {
        var created_event = new Package_created(package1_id);
        var shipping_label_added_event = new Shipping_label_added(package1_id, invalid_shipping_label);

        return new Package_event[] { created_event, shipping_label_added_event };
    }

    public Send_package Send_package()
    {
        return new Send_package(package1_id);
    }

    public Package_sent Package_has_been_sent()
    {
        return new Package_sent(package1_id);
    }

    public Package_failed_to_send Package_failed_to_send()
    {
        return new Package_failed_to_send(package1_id);
    }
}

