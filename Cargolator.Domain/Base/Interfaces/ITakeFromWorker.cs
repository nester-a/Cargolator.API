using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base.Interfaces
{
    public interface ITakeFromWorker: IDropCargo, IWorkerWithType
    {
        void TakeFromWorker(ITakeFromWorker otherWorker);
        bool TryTakeFromWorker(ITakeFromWorker otherWorker);
    }
}
