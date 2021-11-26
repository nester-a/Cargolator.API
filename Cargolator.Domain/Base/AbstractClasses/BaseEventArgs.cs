using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.AbstractClasses
{
    public abstract class BaseEventArgs : IEventArgs
    {
        public string Message { get; set; }
        public bool EventResult { get; set; }
        public BaseEventArgs(string message, bool eventResult)
        {
            Message = message;
            EventResult = eventResult;
        }
    }
}
