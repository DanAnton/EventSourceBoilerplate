using Beersender.Domain;

namespace Beersender.tests;

public abstract class BeerSender_test {
    public BeerSender_test() { 

    }

    private object[] _events;
    protected void Given(params object[] events) {
        _events = events;
    }
    private List<object> _new_events = new();
    protected void When(object command)
    {
        new Command_router(_ => _events,@event => _new_events.Add(@event));
    }


    protected void Then(params object[] events)
    {
      //  expected_events.Should();
    }
}
public class When_create_package : BeerSender_test
{
    [Fact]
    public void The_package_is_created()
    {
        Guid package_id = Guid.NewGuid();
        Given();
       // When(new Create_package(package_id));
        Then();
    }
}
