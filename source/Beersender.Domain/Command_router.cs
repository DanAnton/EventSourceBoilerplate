using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Command_handlers;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<Event>> event_stream;
    private readonly Action<Event_message> publish_event;

    public Command_router(
        Func<Guid, IEnumerable<Event>> Event_stream,
        Action<Event_message> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle_command(object command)
    {
        switch (command)
        {
            case Create_package create_package:
                var package_creator = new Package_creator(event_stream, publish_event);
                package_creator.Handle(create_package);
                return;
            case Add_shipping_label add_shipping_label:
                var shipping_label_adder = new Shipping_label_adder(event_stream, publish_event);
                shipping_label_adder.Handle(add_shipping_label);
                return;
            case Send_package send_package:
                var handler = new Package_sender(event_stream, publish_event);
                handler.Handle(send_package);
                return;
        }
    }
}