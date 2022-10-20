using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;

public class When_deliver_package : Beersender_test
{
    private Guid package1_id = Guid.NewGuid();
    private Shipping_label shipping_label1 = new(Shipping_provider.FedEx, "1234567");
    private Guid package2_id = Guid.NewGuid();
    private Shipping_label shipping_label2 = new(Shipping_provider.FedEx, "1234");

    [Fact]
	public void Then_package1_is_delivered_succesfully()
	{
        Given();


        When(
            Deliver_package1()
            );

        Then(
            Package1_delivered()
            );
    }

    [Fact]
    public void Then_package1_is_delivered_unsuccesfully()
    {
        Given();


        When(
            Deliver_package2()
            );

        Then(
            Package2_not_delivered()
            );
    }

    private Deliver_package Deliver_package1()
    {
        return new Deliver_package(package1_id, shipping_label1);
    }

    private Package_delivered_succesfully Package1_delivered()
    {
        return new Package_delivered_succesfully(package1_id);
    }

    private Deliver_package Deliver_package2()
    {
        return new Deliver_package(package2_id, shipping_label2);
    }

    private Package_delivered_unsuccesfully Package2_not_delivered()
    {
        return new Package_delivered_unsuccesfully(package2_id);
    }
}
