using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Command_handlers;

internal sealed class Package_sender : Package_command_handler
{
	public Package_sender(Func<Guid, IEnumerable<Package_event>> Event_stream, Action<object> Publish_event): base(Event_stream, Publish_event)
	{
	}
}
