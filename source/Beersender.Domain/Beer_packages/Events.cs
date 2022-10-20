using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.Beer_packages.Events;

public record struct Package_created(Guid Package_id) : Event;

public record struct Shipping_label_added(Guid Package_id, Shipping_label shipping_label) : Event;

public record struct Package_sent(Guid Package_id) : Event;

public record struct Package_failed_to_send(Guid Package_id, Send_fail_reason Fail_reason) : Event;

public enum Send_fail_reason
{
    No_shipping_label,
    No_beers_in_package
}