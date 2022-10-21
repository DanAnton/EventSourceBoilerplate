using Beersender.Domain;
using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_create_package : Beersender_test
    {
        [Fact]
        public void Then_package_is_created()
        {
            Given();

            When(Create_package1());

            Then(Package1_created());
        }

        [Fact]
        public void Then_shipping_label_is_added()
        {
            Given(Package1_created());

            var label = new Shipping_label(Shipping_provider.DHL, "96373");
            When(Add_Shipping_Label(label));

            Then(Label_Added(label));
        }

        [Fact]
        public void Then_package_is_sent()
        {
            var package = Package1_created();
            var label = new Shipping_label(Shipping_provider.DHL, "9637636");

            Given(package, Label_Added(label));

            When(new Send_package(package.Package_id));

            Then(new Package_sent(package.Package_id));
        }

        [Fact]
        public void Then_package_not_sent()
        {
            var package = Package1_created();
            var label = new Shipping_label(Shipping_provider.DHL, "9637");

            Given(package, Label_Added(label));

            When(new Send_package(package.Package_id));

            Then(new Package_not_sent(package.Package_id));
        }
    }
}