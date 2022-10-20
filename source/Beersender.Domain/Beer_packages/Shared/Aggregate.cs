namespace Beersender.Domain.Beer_packages.Shared;

public abstract class Aggregate
{
    public abstract void Apply(object @event);
    public abstract IEnumerable<object> Handle(object command);
}