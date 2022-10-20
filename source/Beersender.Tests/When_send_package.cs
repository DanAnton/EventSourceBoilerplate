namespace Beersender.tests
{
    public partial class When_send_package : Beersender_test
    {
        [Fact]
        public void Then_package_is_sent()
        {
            Given();
            
            When(Send_package1());

            Then(Package_was_sent_successfully());
        }

        [Fact]
        public void Then_package_is_not_sent()
        {
            Given();

            When(Send_package1_with_invalid_label());

            Then(Failed_Sending_package1());
        }
    }
}