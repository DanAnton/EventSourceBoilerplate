using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.Beer_packages;

internal abstract class Aggregate
{
    public abstract void Apply(Event @event);
    public abstract IEnumerable<Event> Handle(Command command);
}

internal class Beer_package : Aggregate
{
    public override void Apply(Event @event)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Event> Handle(Command command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<Event> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.Package_id);
    }
}

