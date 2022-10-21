namespace Beersender.Domain.Beer_packages.Commands
{
    public record Send_package(Guid package_id, Guid shipping_id);
}