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
			case Add_shipping_label add_shipping_label:
				return Add_new_shipping_labbel(add_shipping_label);
			case Deliver_package deliver_package:
				return Deliver_new_package(deliver_package);
			default:
				throw new NotImplementedException("Command type not implemented;");
		}
	}

	private IEnumerable<object> Create_new_package(Create_package command)
	{
		yield return new Package_created(command.Package_id);
	}

	private IEnumerable<object> Add_new_shipping_labbel(Add_shipping_label command)
	{

		yield return new Shipping_label_added(command.Package_id, new Shipping_label(Shipping_provider.FedEx, "1234567"));
	}

	private IEnumerable<object> Deliver_new_package(Deliver_package command)
	{
		if (command.Shipping_label.Is_valid())
		{
			yield return new Package_delivered_succesfully(command.Package_id);
		}
		else
		{
			yield return new Package_delivered_unsuccesfully(command.Package_id);
		}

	}

	public Shipping_label Get_shipping_label(Guid Package_id)
	{
		return new Shipping_label(Shipping_provider.DHL, "1234567");
	}
}
