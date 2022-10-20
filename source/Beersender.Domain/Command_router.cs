using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Interfaces;

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
                var create = new Create_package.Handler(event_stream, publish_event);
                create.Handle(create_package);
                return;
            case Add_shipping_label add_shipping_label:
                var add_label = new Add_shipping_label.Handler(event_stream, publish_event);
                add_label.Handle(add_shipping_label);
                return;
            case Send_Package send_package:
                var send = new Send_Package.Handler(event_stream, publish_event);
                send.Handle(send_package);
                return;
        }
    }
}