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
                var package_Creator = new Package_creator(event_stream, publish_event);
                package_Creator.Handle(create_package);
                return;
            case Add_shipping_label add_shipping_label:
                var shipping_label_adder = new Shipping_label_adder(event_stream, publish_event);
                shipping_label_adder.Handle(add_shipping_label);
                return;
            case Deliver_package deliver_Package:
                var package_Deliver = new Package_deliver(event_stream, publish_event);
                package_Deliver.Handle(deliver_Package);
                return;
        }
    }
}