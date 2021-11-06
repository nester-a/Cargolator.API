using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
{
    public class Stock : IStock
    {
        public Queue<ICargo> CargosStock { get; set; } = new Queue<ICargo>();

        public void AddOnStock(ICargo cargo)
        {
            CargosStock.Enqueue(cargo);
        }

        public void AddRangeOnStock(params ICargo[] cargos)
        {
            for (int i = 0; i < cargos.Length; i++)
            {
                CargosStock.Enqueue(cargos[i]);
            }
        }

        public void AddRangeOnStock(ICollection<Cargo> cargos)
        {
            foreach (var cargo in cargos)
            {
                AddOnStock(cargo);
            }
        }
    }
}
