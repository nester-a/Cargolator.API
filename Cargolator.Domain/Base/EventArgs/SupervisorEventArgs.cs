using Cargolator.API.Base.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.EventArgs
{
    public class SupervisorEventArgs : BaseEventArgs
    {
        public SupervisorEventArgs(string message, bool eventResult) : base(message, eventResult) { }
    }
}
