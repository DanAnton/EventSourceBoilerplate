using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Tests;

public abstract class Beer_package_test : Beersender_test
{
    protected Guid package1_id = Guid.NewGuid();
    protected Shipping_label valid_shipping_label = new Shipping_label(Shipping_provider.PostNL, "ABCD1234");

    protected Package_created Package1_created()
    {
        return new Package_created(package1_id);
    }

    protected Shipping_label_added Valid_shipping_label_added_to_package1()
    {
        return new Shipping_label_added(package1_id, valid_shipping_label);
    }

    protected Package_sent Package1_sent()
    {
        return new Package_sent(package1_id);
    }

    protected Package_failed_to_send Package1_failed_to_send_because_no_label()
    {
        return new Package_failed_to_send(package1_id, Send_fail_reason.No_shipping_label);
    }

    protected Package_failed_to_send Package1_failed_to_send_because_no_beers()
    {
        return new Package_failed_to_send(package1_id, Send_fail_reason.No_beers_in_package);
    }
}
