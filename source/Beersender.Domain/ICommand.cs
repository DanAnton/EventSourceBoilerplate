using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beersender.Domain
{
    public interface ICommand
    {
        public Guid Package_id { get; }
    }
}
