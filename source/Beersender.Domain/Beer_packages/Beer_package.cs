using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages;

internal abstract class Aggregate
{
    public abstract void Apply(object @event);
    public abstract IEnumerable<object> Handle(BaseCommand command);
}

internal class Beer_package : Aggregate
{
    public override void Apply(object @event)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<object> Handle(BaseCommand command)
    {
        return command.Execute();
    }
}

