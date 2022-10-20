using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_label_package
    {
        private Guid label1_id = Guid.NewGuid();
        private Shipping_label label = new Shipping_label(Shipping_provider.DHL, "123456789");

        private Label_package Label_package1()
        {
            return new Label_package(label1_id, label);
        }

        private Package_labeled Package1_labeled()
        {
            return new Package_labeled(label1_id, label);
        }
    }
}
