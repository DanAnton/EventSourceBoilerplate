using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;

public class When_adding_shipping_label : Beersender_test
{
	private Guid package1_id = Guid.NewGuid();
	private Shipping_label shipping_label1 = new(Shipping_provider.FedEx, "1234567");

	[Fact]
	public void Then_shipping_label_is_added()
	{
		Given();

		When(
			Add_shipping_label1()
			);

		Then(
			Shipping_label1_added()
			);
	}

	private Add_shipping_label Add_shipping_label1()
	{
		return new Add_shipping_label(package1_id);
	}

	private Shipping_label_added Shipping_label1_added()
	{
		return new Shipping_label_added(package1_id, shipping_label1);
	}
}
