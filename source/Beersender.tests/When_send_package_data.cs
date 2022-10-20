using Beersender.Domain.Commands;

namespace Beersender.Tests
{
    public partial class When_send_package
    {
        protected Send_package Send_package1()
        {
            return new Send_package(package1_id);
        }
    }
}
