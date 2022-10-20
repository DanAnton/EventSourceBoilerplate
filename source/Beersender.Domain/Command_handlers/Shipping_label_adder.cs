using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;

namespace Beersender.Domain.Command_handlers;

internal class Shipping_label_adder : Command_handler<Add_shipping_label, Beer_package>
{
    public Shipping_label_adder(
        Func<Guid, IEnumerable<object>> event_stream, Action<object> publish_event)
        : base(event_stream, publish_event)
    {
    }
}