using Beersender.Domain.Commands.Models;

namespace Beersender.Domain.Events;

public readonly record struct Package_created(Guid Package_id) : IEvent;

public readonly record struct Shipping_label_added(Guid Package_id, Shipping_label Shipping_label) : IEvent;

public readonly record struct Package_sent(Guid Package_id) : IEvent;

public readonly record struct Package_failed_to_send(Guid Package_id, Send_fail_reason Fail_reason) : IEvent;

public enum Send_fail_reason
{
    No_shipping_label,
    No_beers_in_package
}