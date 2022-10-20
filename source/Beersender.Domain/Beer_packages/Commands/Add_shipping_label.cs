using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.Domain.Beer_packages.Commands
{
    public record struct Add_shipping_label(Guid Label_id);

}
