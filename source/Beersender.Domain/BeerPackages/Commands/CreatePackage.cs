using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Domain.BeerPackages.Commands;

public record CreatePackage(Guid PackageId) : Command(PackageId)
{
    public override IEnumerable<Event> CreateEvents()
    {
        yield return new PackageCreated(PackageId);
    }
}