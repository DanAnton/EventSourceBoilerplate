using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_send_package
    {
        private readonly Guid package1_id = Guid.NewGuid();
        private readonly Shipping_label shipping_label = new(Shipping_provider.DHL, "12345543543543");
        private readonly Shipping_label failing_shipping_label = new(Shipping_provider.DHL, "12312");

        private Send_Package Send_package1()
        {
            return new Send_Package(package1_id, shipping_label);
        }

        private Send_Package Send_package1_with_invalid_label()
        {
            return new Send_Package(package1_id, failing_shipping_label);
        }
        
        private Package_sent Package_was_sent_successfully()
        {
            return new Package_sent(package1_id, true);
        }

        private Package_sent Failed_Sending_package1()
        {
            return new Package_sent(package1_id, false);
        }
    }
}
