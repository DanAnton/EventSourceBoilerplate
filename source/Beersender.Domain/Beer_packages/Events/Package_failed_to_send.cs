namespace Beersender.Domain.Beer_packages.Events
{
    public record Package_failed_to_send(Guid package_id, Guid shipping_id);
}
