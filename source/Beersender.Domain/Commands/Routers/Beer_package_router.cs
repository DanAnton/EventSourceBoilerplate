using Beersender.Domain.Events;
using Beersender.Domain.Commands.Handlers;

namespace Beersender.Domain.Commands.Routers;

public class Beer_package_router
{
    private readonly Func<Guid, IEnumerable<IEvent>> event_stream;
    private readonly Action<IEvent> publish_event;

    public Beer_package_router(
        Func<Guid, IEnumerable<IEvent>> Event_stream,
        Action<IEvent> Publish_event)
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