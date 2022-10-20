using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests;

public abstract class Beer_package_test : Beersender_test
{
    // General test data
    protected Guid package1_id = Guid.NewGuid();

    protected Package_created Package1_created()
    {
        return new Package_created(package1_id);
    }
}
