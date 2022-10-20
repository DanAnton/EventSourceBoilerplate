﻿using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;

namespace Beersender.Domain.Command_handlers;

internal class Package_creator : Command_handler<Create_package, Beer_package>
{
    public Package_creator(
        Func<Guid, IEnumerable<object>> event_stream, Action<object> publish_event)
        : base(event_stream, publish_event)
    {
    }
}