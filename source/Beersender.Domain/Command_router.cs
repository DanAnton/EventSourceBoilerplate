using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Command_handlers;

namespace Beersender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<object>> event_stream;
    private readonly Action<object> publish_event;

    public Command_router(
        Func<Guid, IEnumerable<object>> Event_stream,
        Action<object> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle_command(object command)
    {
        switch (command)
        {
            case Create_package create_package:
                {
                    var handler = new Package_creator(event_stream, publish_event);
                    handler.Handle(create_package);
                    return;
                }
                case Label_package label_package:
                {
                    var handler = new Package_labelor(event_stream, publish_event);
                    handler.Handle(label_package);
                    return;
                }
                case Send_package send_package:
                {
                    var handler = new Package_sender(event_stream, publish_event);
                    handler.Handle(send_package);
                    return;
                }
        }
    }
}