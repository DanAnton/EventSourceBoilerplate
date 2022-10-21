using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.Command_handlers;

internal class Package_sender : Command_handler<Send_package, Beer_package>
{
    public Package_sender(
        Func<Guid, IEnumerable<Event>> event_stream, Action<Event_message> publish_event)
        : base(event_stream, publish_event)
    {
    }
}