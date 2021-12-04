using Cargolator.API.Base.AbstractClasses;
using Cargolator.API.Base.EventArgs;
using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
{
    public class Supervisor : ISupervisor
    {
        public delegate void SupervisorHandler(object sender, SupervisorEventArgs e);
        public event SupervisorHandler SupervisorEvent;

        public string[,] ContainerMap { get; set; }
        public Dictionary<int, ICoordinates> LoadList { get; set; } = new Dictionary<int, ICoordinates>();
        public Supervisor(ILoadable container)
        {
            if (container is null) throw new ArgumentNullException("Container", "Container is null");
            ContainerMap = new string[container.Length, container.Width];
        }

        public Coordinates FindPlaceAndLoadOnIt(ICargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo is null");
            for (int i = 0; i < ContainerMap.GetLength(0); i++)
            {
                for (int j = 0; j < ContainerMap.GetLength(1); j++)
                {
                    if (CheckSquare(new Point(j, i), cargo))
                    {
                        Point startPoint = new Point(j, i);
                        Point endPoint = FillMap(startPoint, cargo);
                        var result = new Coordinates(startPoint, endPoint);
                        SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} succesfully placed. {result}", true));
                        return result;
                    }
                    else continue;
                }
            }
            SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} cannot be placed in container", false));
            return null;
        }

        public bool CheckSquare(IPoint startPoint, ICargo cargo)
        {
            if (startPoint is null) throw new ArgumentNullException("StartPoint", "StartPoint is null");
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo is null");
            for (int length = startPoint.Y; length < startPoint.Y + cargo.Length; length++)
            {
                for (int width = startPoint.X; width < startPoint.X + cargo.Width; width++)
                {
                    if (length < ContainerMap.GetLength(0) && width < ContainerMap.GetLength(1))
                    {
                        if (ContainerMap[length, width] is not null)
                        {
                            SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} cannot be placed here", false));
                            return false;
                        }
                    } 
                    else
                    {
                        SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} cannot be placed here", false));
                        return false;
                    }
                }
            }
            SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} can be placed here", true));
            return true;
        }

        public Point FillMap(IPoint startPoint, ICargo cargo)
        {
            if (startPoint is null) throw new ArgumentNullException("StartPoint", "StartPoint is null");
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo is null");
            int X = 0;
            int Y = 0;
            for (int length = startPoint.Y; length < startPoint.Y + cargo.Length; length++)
            {
                for (int width = startPoint.X; width < startPoint.X + cargo.Width; width++)
                {
                    if (length >= ContainerMap.GetLength(0) || width >= ContainerMap.GetLength(1))
                    {
                        SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} cannot be drawed on map", false));
                        return null;
                    }
                    ContainerMap[length, width] = cargo.Id.ToString();
                    X = width;
                }
                Y = length;
            }
            SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} drawed on map", true));
            return new Point(X, Y);
        }

        public bool EraseCargoFromMap(ICargo cargo)
        {
            if (cargo is null) throw new ArgumentNullException("Cargo", "Cargo is null");
            if (LoadList.ContainsKey(cargo.Id))
            {
                int s = cargo.Length * cargo.Width;
                for (int i = LoadList[cargo.Id].UpperLeftCorner.Y; i <= LoadList[cargo.Id].LowerRightCorner.Y; i++)
                {
                    for (int j = LoadList[cargo.Id].UpperLeftCorner.X; j <= LoadList[cargo.Id].LowerRightCorner.X; j++)
                    {
                        if (ContainerMap[i, j] == cargo.Id.ToString())
                        {
                            s--;
                            ContainerMap[i, j] = null;
                            if (s == 0)
                            {
                                SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} succesfully erased from map", true));
                                LoadList.Remove(cargo.Id);
                                return true;
                            }
                        }
                    }
                }
            }
            SupervisorEvent?.Invoke(this, new SupervisorEventArgs($"The cargo {cargo.Id} cannot be erased from map", false));
            return false;
        }
    }
}
