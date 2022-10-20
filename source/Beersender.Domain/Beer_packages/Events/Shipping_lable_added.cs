namespace Beersender.Domain.Beer_packages.Events;

public record struct Shipping_label_added(Guid Package_id, Shipping_label Shipping_label);