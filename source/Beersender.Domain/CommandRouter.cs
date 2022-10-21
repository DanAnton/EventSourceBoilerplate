using Beersender.Domain.BeerPackages;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain;

public class CommandRouter
{
    private readonly Func<Guid, IEnumerable<IEvent>> _eventStream;
    private readonly Action<EventMessage> _publishEvent;

    public CommandRouter(
        Func<Guid, IEnumerable<IEvent>> eventStream,
        Action<EventMessage> publishEvent)
    {
        _eventStream = eventStream;
        _publishEvent = publishEvent;
    }

    public void Handle_command(object command)
    {
        switch (command)
        {
            case CreatePackage createPackage:
                var packageCreator = new CreatePackage.PackageCreator(_eventStream, _publishEvent);
                packageCreator.Handle(createPackage);
                break;
            case AddShippingLabel addShippingLabel:
                var shippingLabelAdder = new AddShippingLabel.ShippingLabelAdder(_eventStream, _publishEvent);
                shippingLabelAdder.Handle(addShippingLabel);
                break;
            case SendPackage sendPackage:
                var handler = new SendPackage.PackageSender(_eventStream, _publishEvent);
                handler.Handle(sendPackage);
                break;
        }
    }
}