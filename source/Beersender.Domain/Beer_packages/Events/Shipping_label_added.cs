namespace Beersender.Domain.Beer_packages.Events;

public sealed record Shipping_label_added(Guid Package_id, Shipping_label Shipping_Label): Package_event(Package_id);

