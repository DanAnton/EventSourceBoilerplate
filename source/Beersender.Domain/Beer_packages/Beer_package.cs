using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages;

internal abstract class Aggregate
{
    public abstract void Apply(object @event);
    public abstract IEnumerable<object> Handle(object command);
}

internal class Beer_package : Aggregate
{
    public override void Apply(object @event)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<object> Handle(object command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
            case Add_shipping_label add_Shipping_Label:
                return Add_shipping_label(add_Shipping_Label);
            case Send_Package send_package:
                return Send_Package(send_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<object> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.Package_id);
    }

    private IEnumerable<object> Add_shipping_label(Add_shipping_label command)
    {
        yield return new Shipping_label_added(command.Package_id);
    }

    private IEnumerable<object> Send_Package(Send_Package command)
    {
        yield return new Package_sended(command.Package_id);
    }
}

