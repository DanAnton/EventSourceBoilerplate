using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;

namespace Beersender.tests
{
    public partial class When_label_package : Beersender_test
    {
        [Fact]
        public void Then_label_is_applied()
        {
            Given(Package1_created());
            
            When(
                Label_package1()
                );

            Then(
                Package1_labeled()
                );
        }

		[Fact]
		public void Created_and_label_applied()
		{
			Given(
				);
			
			When(
				Create_package1(),
				Label_package1()
			);

			Then(
				Package1_created(),
				Package1_labeled()
			);
		}
	}
}