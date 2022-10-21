using Beersender.Domain.Beer_packages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.Domain.Command_handlers
{
    public class Package_add_label : HandlerBase
    {
        public Package_add_label(
           Func<Guid, IEnumerable<IEvent>> Event_stream,
           Action<IEvent> Publish_event) : base(Event_stream, Publish_event)
        {
        }

        public void Handle(Add_shipping_label command)
        {
            base.Handle(command);
        }
    }
}
