using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages;

internal abstract class Aggregate
{
    public abstract void Apply(Package_event @event);
    public abstract IEnumerable<Package_event> Handle(Package_command command);
}

internal sealed class Beer_package : Aggregate
{
    private Guid Package_id;
    private Shipping_label Shipping_label;
    private bool Is_shipping_label_valid;
    public override void Apply(Package_event @event)
    {
        switch (@event)
        {
            case Package_created package_created_event: Package_id = package_created_event.Package_id; break;
            case Shipping_label_added shipping_label_added_event: 
                Shipping_label = shipping_label_added_event.Shipping_Label;
                Is_shipping_label_valid = shipping_label_added_event.isValid;
                break;
        }
    }

    public override IEnumerable<Package_event> Handle(Package_command command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
            case Add_shipping_label add_Shipping_Label:
                return Add_shipping_label(add_Shipping_Label);
            case Send_package send_Package:
                return Send_package(send_Package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<Package_event> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.Package_id);
    }

    private IEnumerable<Package_event> Add_shipping_label(Add_shipping_label command)
    {
        yield return new Shipping_label_added(command.Package_id, command.Shipping_Label);
    }
    private IEnumerable<Package_event> Send_package(Send_package command)
    {
        if (Is_shipping_label_valid)
        {
            yield return new Package_sent(command.Package_id);
        }
        else
        {
            yield return new Package_failed_to_send(command.Package_id);
        }
    }
}

