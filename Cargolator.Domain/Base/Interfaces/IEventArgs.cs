using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface IEventArgs
    {
        string Message { get; }
        bool EventResult { get; }
    }
}
