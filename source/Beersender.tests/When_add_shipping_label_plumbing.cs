using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.tests
{
    public partial class When_add_shipping_label
    {

        private Guid package1_id = Guid.NewGuid();

        private Add_shipping_label Add_shipping_label1()
        {
            return new Add_shipping_label(package1_id);
        }

        private Shipping_label_added Shipping_label1_added()
        {
            return new Shipping_label_added(package1_id);
        }
    }
}
