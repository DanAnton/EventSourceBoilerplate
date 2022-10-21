using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.Domain.Command_handlers
{
    public abstract class HandlerBase
    {
        protected readonly Func<Guid, IEnumerable<IEvent>> event_stream;
        protected readonly Action<IEvent> publish_event;

        protected HandlerBase(Func<Guid, IEnumerable<IEvent>> Event_stream, Action<IEvent> Publish_event)
        {
            event_stream = Event_stream;
            publish_event = Publish_event;
        }

        protected void Handle(ICommand command)
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
