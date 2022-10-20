using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages;

internal abstract class Aggregate
{
    public abstract void Apply(IEvent @event);
    public abstract IEnumerable<IEvent> Handle(ICommand command);
}

internal class Beer_package : Aggregate
{
	private class BeerPackage
	{
		public Guid Package_id { get; set; }
		public Shipping_label Shipping_label { get; set; }
	}

	private BeerPackage _beerPackage = new ();

    public override void Apply(IEvent @event)
    {
        // rebuild beer package
        switch (@event)
        {
	        case Package_created package_created:
		        _beerPackage.Package_id = package_created.Package_id;
                return;

	        case Package_labeled package_labeled:
		        _beerPackage.Shipping_label = package_labeled.Shipping_label;
		        return;

	        default:
		        throw new NotImplementedException("Event type not implemented;");
        }
    }

    public override IEnumerable<IEvent> Handle(ICommand command)
    {
        switch (command)
        {
            case Create_package create_package:
                return Create_new_package(create_package);
            
            case Label_package label_package:
	            return Label_package(label_package);
            default:
                throw new NotImplementedException("Command type not implemented;");
        }
    }

    private IEnumerable<IEvent> Create_new_package(Create_package command)
    {
	    _beerPackage.Package_id = command.Package_id;
        yield return new Package_created(command.Package_id);
    }

    private IEnumerable<IEvent> Label_package(Label_package command)
    {
	    if (_beerPackage.Package_id != command.Package_id)
		    throw new ArgumentException("Label package id is different from beer package");

	    yield return new Package_labeled(command.Package_id, command.Shipping_label);
    }
}

