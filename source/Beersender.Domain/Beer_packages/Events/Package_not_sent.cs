using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.Domain.Beer_packages.Events
{
    public record Package_not_sent(Guid packageId) : IEvent
    {
    }
}
