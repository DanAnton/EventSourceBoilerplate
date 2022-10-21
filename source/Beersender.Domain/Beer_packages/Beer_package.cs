using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages;

internal abstract class Aggregate
{
    protected List<IEvent> recorded_events = new();
    public abstract void Apply(IEvent @event);
    public abstract IEnumerable<IEvent> Handle(ICommand command);
}

internal class Beer_package : Aggregate
{
    public override void Apply(IEvent @event)
    {
        recorded_events.Add(@event);
    }

    public override IEnumerable<IEvent> Handle(ICommand command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
            case Add_shipping_label add_shipping_label:
                return Add_new_shipping_label(add_shipping_label);
            case  Send_package send_package:
                return Send_Package(send_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<IEvent> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.Package_id);
    }

    private IEnumerable<IEvent> Add_new_shipping_label(Add_shipping_label command)
    {
        yield return new Shipping_label_added(command.Shipping_Label);
    }

    private IEnumerable<IEvent> Send_Package(Send_package command)
    {
        var shippingLabel = recorded_events.Where(x => x is Shipping_label_added).LastOrDefault() as Shipping_label_added;

        yield return shippingLabel != null && shippingLabel.Shipping_Label.Is_valid 
            ? new Package_sent(command.Package_id) 
            : new Package_not_sent(command.Package_id);
    }
}

