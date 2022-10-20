namespace Beersender.Domain.Beer_packages.Commands;

public record struct Deliver_package(Guid Package_id, Shipping_label Shipping_label);