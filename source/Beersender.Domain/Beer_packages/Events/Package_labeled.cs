namespace Beersender.Domain.Beer_packages.Events;

public record struct Package_labeled(Guid Package_id, Shipping_label Shipping_label) : IEvent;