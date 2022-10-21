using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;

namespace Beersender.Domain.Command_handlers;

internal class Package_creator : HandlerBase
{

    public Package_creator(
        Func<Guid, IEnumerable<IEvent>> Event_stream,
        Action<IEvent> Publish_event) : base(Event_stream, Publish_event)
    {
    }

    public void Handle(Create_package command)
    {
        base.Handle(command);
    }
}