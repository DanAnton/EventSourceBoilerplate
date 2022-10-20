using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages;

namespace Beersender.Domain.Command_handlers
{
    internal class Shipping_label_addition
    {
        private readonly Func<Guid, IEnumerable<object>> event_stream;
        private readonly Action<object> publish_event;

        public Shipping_label_addition(
            Func<Guid, IEnumerable<object>> Event_stream,
            Action<object> Publish_event)
        {
            event_stream = Event_stream;
            publish_event = Publish_event;
        }

        public void Handle(Add_shipping_label command)
        {
            var previous_events = event_stream(command.Label_id);

            var aggregate = new Beer_package();

            foreach (var previous_event in previous_events)
            {
                aggregate.Apply(previous_event);
            }

            var resulting_events = aggregate.Handle(command);

            foreach (var resulting_event in resulting_events)
            {
                publish_event(resulting_event);
            }
        }
    }
}