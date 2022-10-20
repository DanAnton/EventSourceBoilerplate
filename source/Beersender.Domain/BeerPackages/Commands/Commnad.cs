using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Domain.BeerPackages.Commands;

public abstract record Command(Guid PackageId)
{
    public abstract IEnumerable<Event> CreateEvents();
}