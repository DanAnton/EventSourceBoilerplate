using Beersender.Domain.Beer_packages.Commands;

namespace Beersender.Tests
{
    public partial class When_create_package
    {
        protected Create_package Create_package1()
        {
            return new Create_package(package1_id);
        }
    }
}
