using Beersender.Domain.Commands.Models;

namespace Beersender.Domain.Commands;

public readonly record struct Create_package(Guid Package_id) : ICommand
{
    public Guid Aggregate_id => Package_id;
};

public readonly record struct Add_shipping_label(Guid Package_id, Shipping_label Shipping_label) : ICommand
{
    public Guid Aggregate_id => Package_id;
};

public readonly record struct Send_package(Guid Package_id) : ICommand
{
    public Guid Aggregate_id => Package_id;
};