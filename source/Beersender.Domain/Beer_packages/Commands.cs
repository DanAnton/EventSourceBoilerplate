using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.Beer_packages.Commands;

public record struct Create_package(Guid Package_id) : Command
{
    public Guid Aggregate_id => Package_id;
};

public record struct Add_shipping_label(Guid Package_id, Shipping_label Shipping_label) : Command
{
    public Guid Aggregate_id => Package_id;
};

public record struct Send_package(Guid Package_id) : Command
{
    public Guid Aggregate_id => Package_id;
};