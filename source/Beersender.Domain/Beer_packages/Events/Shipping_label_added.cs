using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.Domain.Beer_packages.Events
{
    public record Shipping_label_added(Shipping_label Shipping_Label) : IEvent;
}
