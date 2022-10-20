using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Command_handlers;

namespace Beersender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<IEvent>> event_stream;
    private readonly Action<IEvent> publish_event;

    public Command_router(
        Func<Guid, IEnumerable<IEvent>> Event_stream,
        Action<IEvent> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle_command(ICommand command)
    {
        switch (command)
        {
            case Create_package create_package:
                new Package_creator(event_stream, publish_event).Handle(create_package);
                return;

            case Label_package label_package:
	            new Package_labeler(event_stream, publish_event).Handle(label_package);
	            return;
        }
    }
}