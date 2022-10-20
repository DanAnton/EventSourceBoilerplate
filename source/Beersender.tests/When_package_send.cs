using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.tests
{
    public partial class When_package_send: Beersender_test
    {
        [Fact]
        public void Then_package_is_sended()
        {
            Given();


            When(
                Send_package1()
                );

            Then(
                Package1_sended()
                );
        }
    }
}
