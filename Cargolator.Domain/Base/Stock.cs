using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Stock : IStock
    {
        public Queue<ICargo> CargosStock { get; set; } = new Queue<ICargo>();

        public void AddOnStock(params ICargo[] cargos)
        {
            for (int i = 0; i < cargos.Length; i++)
            {
                CargosStock.Enqueue(cargos[i]);
            }
        }
    }
}
