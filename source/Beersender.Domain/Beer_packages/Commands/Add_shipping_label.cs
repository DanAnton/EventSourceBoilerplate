namespace Beersender.Domain.Beer_packages.Commands;

public record struct Add_shipping_label(Guid package_id, Shipping_label Shipping_label); 
