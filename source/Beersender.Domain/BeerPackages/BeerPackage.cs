using Beersender.Domain.BeerPackages.Commands;
using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Domain.BeerPackages;

public abstract class Aggregate
{
    public abstract void Apply(Event @event);
    public abstract IEnumerable<Event> Handle<TCommand>(TCommand command) where TCommand : Command;

}

public class BeerPackage: Aggregate
{
    public override void Apply(Event @event)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Event> Handle<TCommand>(TCommand command)
    {
        return command.CreateEvents();
    }
}