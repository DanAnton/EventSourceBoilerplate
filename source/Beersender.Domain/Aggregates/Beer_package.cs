using Beersender.Domain.Commands;
using Beersender.Domain.Events;
using Beersender.Domain.Commands.Models;

namespace Beersender.Domain.Aggregates;

internal abstract class Aggregate
{
    public abstract void Apply(IEvent @event);
    public abstract IEnumerable<IEvent> Handle(ICommand command);
}

internal class Beer_package : Aggregate
{
    #region state

    private Guid? package_id = null;
    private Shipping_label? shipping_label = null;

    #endregion
    public override void Apply(IEvent @event)
    {
        switch (@event)
        {
            case Package_created package_created:
                ApplyEvent(package_created);
                return;
            case Shipping_label_added shipping_label_added:
                ApplyEvent(shipping_label_added);
                return;
            default:
                throw new NotImplementedException("Event type not implemented;");
        }
    }

    private void ApplyEvent(Package_created package_created)
    {
        package_id = package_created.Package_id;
    }

    private void ApplyEvent(Shipping_label_added shipping_label_added)
    {
        shipping_label = shipping_label_added.Shipping_label;
    }

    public override IEnumerable<IEvent> Handle(ICommand command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
            case Add_shipping_label add_shipping_label:
                return Add_new_shipping_label(add_shipping_label);
            case Send_package send_package:
                return Send_this_package(send_package);
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
        yield return new Shipping_label_added(command.Package_id, command.Shipping_label);
    }

    private IEnumerable<IEvent> Send_this_package(Send_package command)
    {
        if (shipping_label == null)
        {
            yield return new Package_failed_to_send(command.Package_id, Send_fail_reason.No_shipping_label);
            yield break;
        }

        yield return new Package_sent(command.Package_id);
    }
}

