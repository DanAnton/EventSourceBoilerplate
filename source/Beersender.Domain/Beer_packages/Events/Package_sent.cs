namespace Beersender.Domain.Beer_packages.Events
{
    public record Package_sent(Guid package_id, Guid shipping_id);
}
