using Beersender.Domain.Beer_packages.Interfaces;
using Beersender.Domain.Beer_packages.Shared;

namespace Beersender.Domain.Beer_packages.Commands;

public record struct Add_shipping_label(Guid AggregateId, Shipping_label Shipping_label) : ICommand
{

    internal class Handler: CommandHandler<Add_shipping_label, Beer_package>
    {

        public Handler(Func<Guid, IEnumerable<object>> Event_stream, Action<object> Publish_event) 
            : base(Event_stream, Publish_event)
        {
        }
    }
}