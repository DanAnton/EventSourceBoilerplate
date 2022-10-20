using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;
using Beersender.Domain.Command_handlers;

namespace Beersender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<Package_event>> event_stream;
    private readonly Action<object> publish_event;

    public Command_router(
        Func<Guid, IEnumerable<Package_event>> Event_stream,
        Action<object> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle_command(object command)
    {
        Package_command_handler handler;
        switch (command)
        {
            case Create_package create_package:
                handler = new Package_creator(event_stream, publish_event);
                handler.Handle(create_package);
                return;
            case Add_shipping_label add_shipping_label:
                handler = new Shipping_label_contributor(event_stream, publish_event);
                handler.Handle(add_shipping_label);
                return;
            case Send_package send_package:
                handler = new Package_sender(event_stream, publish_event);
                handler.Handle(send_package);
                return;
        }
    }
}