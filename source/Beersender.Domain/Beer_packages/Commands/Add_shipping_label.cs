namespace Beersender.Domain.Beer_packages.Commands
{
    public sealed record Add_shipping_label(Guid Package_id, Shipping_label Shipping_Label) : Package_command(Package_id);
}
