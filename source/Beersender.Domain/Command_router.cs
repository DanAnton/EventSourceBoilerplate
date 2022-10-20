using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.Domain;

public class Command_router
{
    private readonly Func<Guid, IEnumerable<object>> event_stream;
    private readonly Action<object> publish_event;

    public Command_router(
        Func<Guid, IEnumerable<object>> Event_stream,
        Action<object> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle_command(object command)
    {

    }
}