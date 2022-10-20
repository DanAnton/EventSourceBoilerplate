using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_label_package : Beersender_test
    {
        [Fact]
        public void Then_package_is_labeled()
        {
            Given();


            When(
                Label_package1()
                );

            Then(
                Package1_labeled()
                );
        }
    }
}