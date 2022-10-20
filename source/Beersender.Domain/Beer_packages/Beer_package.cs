using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;
using Beersender.Domain.Beer_packages.Shared;

namespace Beersender.Domain.Beer_packages;

public class Beer_package : Aggregate
{
    private Guid _id;
    private bool _isValid;
    private Shipping_label _shippingLabel;
    private string _status;

    public override void Apply(object @event)
    {
        switch (@event)
        {
            case Package_created package_created:
                _id = package_created.Package_id;
                return;
            case Shipping_label_added shipping_label_added:
                _isValid = shipping_label_added.Shipping_label.Is_valid();
                _shippingLabel = shipping_label_added.Shipping_label;
                return;
            case Package_sent package_sent:
                _status = package_sent.success ? "Success" : "Failure";
                return;
            default:
                throw new NotImplementedException("Command type not implemented;");
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
            case Send_Package send_package:
                return Try_Send_package(send_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private static IEnumerable<object> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.AggregateId);
    }

    private static IEnumerable<object> Add_shipping_label(Add_shipping_label command)
    {
        yield return new Shipping_label_added(command.AggregateId, command.Shipping_label);
    }

    private static IEnumerable<object> Try_Send_package(Send_Package command)
    {
        yield return new Package_sent(command.AggregateId, command.shipping_label.Is_valid());
    }
}