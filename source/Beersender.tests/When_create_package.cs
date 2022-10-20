using Beersender.Domain.Beer_package.Commands;
using Beersender.Domain.Beer_package.Events;

namespace Beersender.tests
{
    public partial class When_create_package : Beersender_test
    {
        [Fact]
        public void Then_package_is_created()
        {
            Given();


            When(
                Create_package1()
                );

            Then(
                Package1_created()
                );
        }
    }
}