using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;
using Beersender.Domain.Beer_packages.Shared;

namespace Beersender.Domain.Beer_packages;

public class Beer_package : Aggregate
{
    private Guid _id;
    private bool _isValid;
    private Shipping_label _shippingLabel;
    private string _validationErrorMessage;

    public override void Apply(object @event)
    {
        switch (@event)
        {
            case Package_created package_created:
                _id = package_created.Package_id;
                return;
            case Shipping_label_added shipping_label_added:
                if (shipping_label_added.Shipping_label.Is_valid())
                {
                    _shippingLabel = shipping_label_added.Shipping_label;
                    _isValid = true;
                }
                else
                {
                    _isValid = false;
                }
                return;
            case Package_sent package_sent:
                return;
            case Package_sent_failed package_sent_failed:
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

    private IEnumerable<object> Try_Send_package(Send_Package command)
    {
        if (!_isValid)
            yield return new Package_sent_failed(command.AggregateId, "Error");
        else
            yield return new Package_sent(command.AggregateId);
    }
}