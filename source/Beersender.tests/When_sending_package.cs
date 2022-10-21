using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_sending_package : Beersender_test
    {
        [Fact]
        public void Then_package_is_sent()

        {
            var packageId = Guid.NewGuid();
            var shippingId = Guid.NewGuid();

            Given();


            When(
                new Send_package(packageId, shippingId));

            Then(
                new Package_sent(packageId, shippingId));
        }

        [Fact]
        public void Then_package_is_not_sent()

        {
            var packageId = Guid.NewGuid();

            Given();


            When(
                new Send_package(packageId, Guid.Empty));

            Then(
                new Package_failed_to_send(packageId, Guid.Empty));
        }
    }
}