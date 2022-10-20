using Beersender.Domain.Aggregates;
using Beersender.Domain.Events;

namespace Beersender.Domain.Commands.Handlers;

internal class Shipping_label_adder : Beer_package_handler<Add_shipping_label, Beer_package>
{
    public Shipping_label_adder(
        Func<Guid, IEnumerable<IEvent>> event_stream, Action<IEvent> publish_event)
        : base(event_stream, publish_event)
    {
    }
}