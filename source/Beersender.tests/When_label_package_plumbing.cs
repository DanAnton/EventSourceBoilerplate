using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_label_package
    {
        private Guid package_id = Guid.NewGuid();
        private Shipping_label label = new Shipping_label(Shipping_provider.DHL, "123456789");

        private Label_package Label_package1()
        {
            return new Label_package(package_id, label);
        }

        private Shipping_label_added Add_shipping_label2()
        {
            return new Shipping_label_added(package_id, label);
        }
    }
}
