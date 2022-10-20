using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Command_handlers
{
    internal sealed class Shipping_label_contributor : Package_command_handler
    {
        public Shipping_label_contributor(
            Func<Guid, IEnumerable<Package_event>> Event_stream,
            Action<object> Publish_event) : base(Event_stream, Publish_event) { }

    }
}
