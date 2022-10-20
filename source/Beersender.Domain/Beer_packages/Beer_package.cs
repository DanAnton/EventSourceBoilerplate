using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages;

internal abstract class Aggregate
{
    public abstract void Apply(object @event);
    public abstract IEnumerable<object> Handle(object command);
}

internal class Beer_package : Aggregate
{
    public override void Apply(object @event)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<object> Handle(object command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
                case Label_package label_package:
                return Label_existing_package(label_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<object> Create_new_package(Create_package command)
    {
        yield return new Package_created(command.Package_id);
    }

    private IEnumerable<object> Label_existing_package(Label_package command)
    {
        yield return new Package_labeled(command.Package_id, command.Shipping_label);
    }
}

