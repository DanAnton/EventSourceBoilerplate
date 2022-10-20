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
    private Shipping_label _shippingLabel;
    private Guid _guid;
    private string _validationErrorMessage;
    private bool _vallidationError;

    public override void Apply(object @event)
    {
        switch (@event)
        {
            case Create_package create_package:
                _guid = create_package.Package_id;
                return;
            case Label_package label_package:
                _shippingLabel = label_package.Shipping_label;
                return;
            case Package_sent_failled package_sent_failled:
                _validationErrorMessage = package_sent_failled.errorMessage;
                _vallidationError = false;
                return;
            case Package_sent package_sent:
                _validationErrorMessage = string.Empty;
                _vallidationError = true;
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
            case Label_package label_package:
                return Label_existing_package(label_package);
            case Send_package send_package:
                return Send_existing_package(send_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<object> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.Package_id);
    }

    private IEnumerable<object> Label_existing_package(Label_package command)
    {
        yield return new Shipping_label_added(command.Package_id, command.Shipping_label);
    }

    private IEnumerable<object> Send_existing_package(Send_package command)
    {
        if (this._shippingLabel.Is_valid())
        {
            yield return new Package_sent(command.Package_id);
        }

        yield return new Package_sent_failled(command.Package_id, "VALIDATION FAILIEURE");
    }
}

