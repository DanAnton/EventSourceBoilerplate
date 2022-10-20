using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;

public partial class When_label_package : Beersender_test
{
	private readonly Guid package1_id = Guid.NewGuid();
	private readonly Shipping_label package1_label = new Shipping_label(Shipping_provider.DHL, "123456");

	private Create_package Create_package1()
	{
		return new Create_package(package1_id);
	}

	private Package_created Package1_created()
	{
		return new Package_created(package1_id);
	}

	private Label_package Label_package1()
	{
		return new Label_package(package1_id, package1_label);
	}

	private Package_labeled Package1_labeled()
	{
		return new Package_labeled(package1_id, package1_label);
	}
}