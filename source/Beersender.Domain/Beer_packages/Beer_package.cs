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
    public Guid? Package_id { get; private set; }
    public Shipping_label? Shipping_label { get; private set; }
    public bool? Sent;
    public override void Apply(object @event)
    {
        switch (@event)
        {
            case Package_created package_created:
                Package_id = package_created.Package_id;
                break;
            case Shipping_label_added shipping_label_added:
                Shipping_label = shipping_label_added.Shipping_label;
                break;
            case Package_sent package_sent:
                Sent = true;
                break;
            case Package_failed_to_send package_failed_to_send:
                Sent = false;
                break;
            default:
                throw new NotImplementedException("Event type not implemented;");
        }
    }

    public override IEnumerable<object> Handle(object command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
            case Add_shipping_label add_shipping_label:
                return Add_shipping_label(add_shipping_label);
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
    private IEnumerable<object> Add_shipping_label(Add_shipping_label command)
    {
        yield return new Shipping_label_added(command.Shipping_label);
    }
    private IEnumerable<object> Send_package(Send_package command)
    {
        if (Shipping_label!=null)
        {
            yield return new Package_sent(command.Package_id);
            yield break;
        }
        yield return new Package_failed_to_send(command.Package_id);
    }
}

