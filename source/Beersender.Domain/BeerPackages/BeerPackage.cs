using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.BeerPackages;

internal abstract class Aggregate
{
    public abstract void Apply(IEvent @event);
    public abstract IEnumerable<IEvent> Handle(ICommand command);
}

internal class BeerPackage : Aggregate
{
    public override void Apply(IEvent @event)
    {
        switch (@event)
        {
            case PackageCreated packageCreated:
                ApplyEvent(packageCreated);
                return;
            case ShippingLabelAdded shippingLabelAdded:
                ApplyEvent(shippingLabelAdded);
                return;
            default:
                throw new NotImplementedException("Event type not implemented;");
        }
    }

    private void ApplyEvent(PackageCreated packageCreated)
    {
        _packageId = packageCreated.PackageId;
    }

    private void ApplyEvent(ShippingLabelAdded shippingLabelAdded)
    {
        _shippingLabel = shippingLabelAdded.ShippingLabel;
    }

    public override IEnumerable<IEvent> Handle(ICommand command)
    {
        return command switch
        {
            CreatePackage createPackage => Create_new_package(createPackage),
            AddShippingLabel addShippingLabel => Add_new_shipping_label(addShippingLabel),
            SendPackage sendPackage => Send_this_package(sendPackage),
            _ => throw new NotImplementedException("Command type not implemented;")
        };
    }


    private IEnumerable<IEvent> Create_new_package(CreatePackage command)
    {
        yield return new PackageCreated(command.PackageId);
    }

    private IEnumerable<IEvent> Add_new_shipping_label(AddShippingLabel command)
    {
        yield return new ShippingLabelAdded(command.PackageId, command.ShippingLabel);
    }

    private IEnumerable<IEvent> Send_this_package(SendPackage command)
    {
        if (_shippingLabel == null)
        {
            yield return new PackageFailedToSend(command.PackageId, SendFailReason.NoShippingLabel);
            yield break;
        }

        yield return new PackageSent(command.PackageId);
    }

    #region state

    private Guid? _packageId;
    private ShippingLabel? _shippingLabel;

    #endregion
}