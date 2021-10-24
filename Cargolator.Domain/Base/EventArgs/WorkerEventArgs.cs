using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base.EventArgs
{
    public class WorkerEventArgs
    {
        public string Message { get; }
        public bool EventResult { get; }
        public WorkerEventArgs(string message, bool eventResult)
        {
            Message = message;
            EventResult = eventResult;
        }
    }
}
