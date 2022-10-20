using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_add_shipping_label
    {
        private Guid label_id = Guid.NewGuid();

        private Add_shipping_label Add_shipping_label1()
        {
            return new Add_shipping_label(label_id);
        }

        private Shipping_label_added Label1_shipping_added()
        {
            return new Shipping_label_added(label_id);
        }
    }
}
