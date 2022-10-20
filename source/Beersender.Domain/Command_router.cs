using System.Diagnostics.CodeAnalysis;
using Beersender.Domain.Beer_package.Commands;
using Beersender.Domain.Beer_package.Events;

namespace Beersender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<object>> _event_stream;
    private readonly Action<object> _publish_event;

    public Command_router(
        Func<Guid, IEnumerable<object>> Event_stream,
        Action<object> Publish_event)
    {
        _event_stream = Event_stream;
        _publish_event = Publish_event;
    }

    public void Handle_command(object command)
    {
        switch (command)
        {
            case Create_package create_package:
                _publish_event(new Package_created(create_package.Package_id));
                return;
        }
    }
}