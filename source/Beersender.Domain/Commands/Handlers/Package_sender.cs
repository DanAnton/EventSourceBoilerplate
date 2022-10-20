using Beersender.Domain.Aggregates;
using Beersender.Domain.Events;

namespace Beersender.Domain.Commands.Handlers;

internal class Package_sender : Beer_package_handler<Send_package, Beer_package>
{
    public Package_sender(
        Func<Guid, IEnumerable<IEvent>> event_stream, Action<IEvent> publish_event)
        : base(event_stream, publish_event)
    {
    }
}