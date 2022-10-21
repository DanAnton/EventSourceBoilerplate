using Beersender.Domain.Infrastructure;

namespace Beersender.API.ReadProjections;

public class EventRouter
{
    private readonly IEnumerable<IProjection> _allProjections;

    public EventRouter(IEnumerable<IProjection> allProjections)
    {
        _allProjections = allProjections;
    }


    public void Dispatch(IEvent @event)
    {
        foreach (var projection in _allProjections) projection.Dispatch(@event);
    }
}