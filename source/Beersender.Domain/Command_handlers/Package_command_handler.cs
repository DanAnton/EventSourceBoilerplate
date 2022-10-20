using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Command_handlers
{
    internal abstract class Package_command_handler
    {
        protected readonly Func<Guid, IEnumerable<Package_event>> event_stream;
        protected readonly Action<object> publish_event;

        public Package_command_handler(Func<Guid, IEnumerable<Package_event>> Event_stream, Action<object> Publish_event)
        {
            event_stream = Event_stream;
            publish_event = Publish_event;
        }

        public void Handle<T>(T command)
            where T : Package_command
        {
            var previous_events = event_stream(command.Package_id);

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
