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
            case Add_shipping_label add_label:
                return Create_label(add_label);
            case Send_package send_package:
                return Send_package(send_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<object> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.Package_id);
    }

    private IEnumerable<object> Create_label(Add_shipping_label command)
    {
        yield return new Shipping_label_added(command.label);
    }

    private IEnumerable<object> Send_package(Send_package command)
    {
        if (command.shipping_id == Guid.Empty)
            yield return new Package_failed_to_send(command.package_id, command.shipping_id);
        else
            yield return new Package_sent(command.package_id, command.shipping_id);
    }
}