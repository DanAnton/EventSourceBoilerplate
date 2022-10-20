namespace Beersender.Domain.Beer_packages.Commands;

public record struct Label_package(Guid Package_id, Shipping_label Shipping_label);
