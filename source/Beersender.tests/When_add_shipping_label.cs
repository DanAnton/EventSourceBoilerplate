using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_add_shipping_label : Beersender_test
    {
        [Fact]
        public void The_shipping_label_added()
        {
            Given();

            When(Add_shipping_label1()
                );

            Then(Label1_shipping_added());
        }
    }
}
