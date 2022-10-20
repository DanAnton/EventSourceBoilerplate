using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_create_package
    {
        private Guid package1_id = Guid.NewGuid();

        private Create_package Create_package1()
        {
            return new Create_package(package1_id);
        }

        private Package_created Package1_created()
        {
            return new Package_created(package1_id);
        }
    }
}
