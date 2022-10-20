using Beersender.Domain.Beer_packages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.tests
{
    public partial class When_add_shipping_label: Beersender_test
    {
        [Fact]
        public void Shipping_label_added()
        {
            Given();

            When(
                Add_shipping_label1()
                );

            Then(
                Shipping_label1_added()
                );
        }
    }
}
