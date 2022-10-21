using Beersender.Domain.Command_handlers;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.BeerPackages;

public record struct CreatePackage(Guid PackageId) : ICommand
{
    public Guid AggregateId => PackageId;

    internal class PackageCreator : CommandHandler<CreatePackage, BeerPackage>
    {
        public PackageCreator(
            Func<Guid, IEnumerable<IEvent>> eventStream, Action<EventMessage> publishEvent)
            : base(eventStream, publishEvent)
        {
        }
    }
}

public record struct AddShippingLabel(Guid PackageId, ShippingLabel ShippingLabel) : ICommand
{
    public Guid AggregateId => PackageId;

    internal class ShippingLabelAdder : CommandHandler<AddShippingLabel, BeerPackage>
    {
        public ShippingLabelAdder(
            Func<Guid, IEnumerable<IEvent>> eventStream, Action<EventMessage> publishEvent)
            : base(eventStream, publishEvent)
        {
        }
    }
}

public record struct SendPackage(Guid PackageId) : ICommand
{
    public Guid AggregateId => PackageId;

    internal class PackageSender : CommandHandler<SendPackage, BeerPackage>
    {
        public PackageSender(
            Func<Guid, IEnumerable<IEvent>> eventStream, Action<EventMessage> publishEvent)
            : base(eventStream, publishEvent)
        {
        }
    }
}