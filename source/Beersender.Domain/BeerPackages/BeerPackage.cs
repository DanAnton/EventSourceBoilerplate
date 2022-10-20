using Beersender.Domain.BeerPackages.Commands;
using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Domain.BeerPackages;

public abstract class Aggregate
{
    public void Apply(Event @event)
    {
        @event.Apply();
    }

    public IEnumerable<Event> Handle<TCommand>(TCommand command) where TCommand : Command
    {
        return command.CreateEvents();
    }
}

public class BeerPackage : Aggregate {}
