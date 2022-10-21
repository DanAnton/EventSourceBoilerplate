using Beersender.Domain.Infrastructure;

namespace Beersender.API.ReadProjections
{
    public class Event_router
    {
        private readonly IEnumerable<Projection> _allProjections;

        public Event_router(IEnumerable<Projection> allProjections)
        {
            _allProjections = allProjections;
        }

        public void Dispatch(Event @event)
        {
            foreach (var projection in _allProjections)
            {
                projection.Dispatch(@event);
            }
        }
    }
}
