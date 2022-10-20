using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Command_handlers;

namespace Beersender.Domain;

public class Command_router
{
    public readonly Func<Guid, IEnumerable<object>> _event_stream;
    public readonly Action<object> _publish_event;

    public Command_router(
        Func<Guid, IEnumerable<object>> Event_stream,
        Action<object> Publish_event)
    {
        _event_stream = Event_stream;
        _publish_event = Publish_event;
    }

    public void Handle_command(object command)
    {
        var handler = new Package_creator(_event_stream, _publish_event);
        switch (command)
        {
            case Create_package create_package:
                handler.Handle(create_package);              
                return;
            case Add_shipping_label add_shipping_label:
                handler.Handle(add_shipping_label);
                return;
            case Send_package send_Package:
                handler.Handle(send_Package);
                return;
        }
    }
}