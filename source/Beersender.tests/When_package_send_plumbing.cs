using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.tests
{
    public partial class When_package_send
    {
        private Guid package1_id = Guid.NewGuid();

        private Send_Package Send_package1()
        {
            return new Send_Package(package1_id);
        }

        private Package_sended Package1_sended()
        {
            return new Package_sended(package1_id);
        }
    }
}
