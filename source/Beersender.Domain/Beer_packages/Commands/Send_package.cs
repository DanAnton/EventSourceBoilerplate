using Beersender.Domain.Beer_packages.Interfaces;
using Beersender.Domain.Beer_packages.Shared;

namespace Beersender.Domain.Beer_packages.Commands;

public record struct Send_Package(Guid AggregateId, Shipping_label shipping_label) : ICommand
{
    internal class Handler : CommandHandler<Send_Package, Beer_package>
    {
        public Handler(Func<Guid, IEnumerable<object>> Event_stream, Action<object> Publish_event)
            : base(Event_stream, Publish_event)
        {
        }
    }
}