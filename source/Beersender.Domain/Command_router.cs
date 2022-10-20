using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Command_handlers;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<Event>> event_stream;
    private readonly Action<Event> publish_event;

    public Command_router(
        Func<Guid, IEnumerable<Event>> Event_stream,
        Action<Event> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle_command(object command)
    {
        switch (command)
        {
            case Create_package create_package:
                var handler = new Package_creator(event_stream, publish_event);
                handler.Handle(create_package);
                return;
        }
    }
}