using Cargolator.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.Domain.Base
{
    public class Supervisor : ISupervisor
    {
        public string[,] ContainerMap { get; set; }
        public Dictionary<int, ICoordinates> LoadList { get; set; } = new Dictionary<int, ICoordinates>();
        public Supervisor(ILoadable container)
        {
            ContainerMap = new string[container.Length, container.Width];
        }
        public Coordinates FindLoadPlace(ICargo cargoForLoad)
        {
            Point startPoint = null;
            int cells = 0;
            int cellsTarget = cargoForLoad.Length * cargoForLoad.Width;
            for (int i = 0; i < ContainerMap.GetLength(0); i++)
            {
                if(startPoint is null)
                {
                    for (int j = 0; j < ContainerMap.GetLength(1); j++)
                    {
                        if(ContainerMap[i,j] is null)
                        {
                            if(j + cargoForLoad.Width < ContainerMap.GetLength(1))
                            {
                                if (i + cargoForLoad.Length < ContainerMap.GetLength(0))
                                {
                                    startPoint = new Point { X = i, Y = j };
                                    cells++;
                                    i = startPoint.X - 1;
                                    break;
                                }
                                else
                                    return null;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = startPoint.Y + 1; j < ContainerMap.GetLength(1); j++)
                    {
                        if (ContainerMap[i, j] is null)
                        {
                            //TODO form here
                            cells++;
                            if(cells == cellsTarget)
                            {
                                var finishPoint = new Point() { X = i, Y = j };
                                return new Coordinates(startPoint, finishPoint);
                            }
                        }
                        else
                        {
                            cells = 0;
                            startPoint = null;
                        }
                    }
                }
            }
            return null;
        }
    }
}
