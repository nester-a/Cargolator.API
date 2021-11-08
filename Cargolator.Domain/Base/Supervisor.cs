using Cargolator.API.Base.AbstractClasses;
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
        public string[,] ContainerMap { get; set; }
        public Dictionary<int, ICoordinates> LoadList { get; set; } = new Dictionary<int, ICoordinates>();
        public Supervisor(ILoadable container)
        {
            ContainerMap = new string[container.Length, container.Width];
        }
        public Coordinates FindLoadPlace(ICargo cargoForLoad)
        {
            string[,] draft = CopyContainerMap();
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
                                    draft[i, j] = cargoForLoad.Id.ToString();
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
                    for (int j = 0; j < ContainerMap.GetLength(1); j++)
                    {
                        if (cells == 1 && j == 0) continue;
                        else
                        {
                            if (ContainerMap[i, j] is null)
                            {
                                cells++;
                                draft[i, j] = cargoForLoad.Id.ToString();
                                if (cells % cargoForLoad.Length == 0 && cells != cellsTarget) break;
                                if (cells == cellsTarget)
                                {
                                    var finishPoint = new Point() { X = i, Y = j };
                                    RenewContainerMap(draft);
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
            }
            return null;
        }
        private string[,] CopyContainerMap()
        {
            string[,] result = new string[ContainerMap.GetLength(0), ContainerMap.GetLength(1)];
            for (int i = 0; i < ContainerMap.GetLength(0); i++)
            {
                for (int j = 0; j < ContainerMap.GetLength(1); j++)
                {
                    result[i, j] = ContainerMap[i, j];
                }
            }
            return result;
        }
        private void RenewContainerMap(string[,] origin)
        {
            for (int i = 0; i < ContainerMap.GetLength(0); i++)
            {
                for (int j = 0; j < ContainerMap.GetLength(1); j++)
                {
                    if (origin[i, j] is not null && ContainerMap[i, j] != origin[i, j])
                    {
                        ContainerMap[i, j] = origin[i, j];
                    }
                    else continue;
                }
            }
        }
        public bool CheckSquare(IPoint startPoint, ICargo cargo)
        {
            for (int length = startPoint.Y; length < startPoint.Y + cargo.Length; length++)
            {
                for (int width = startPoint.X; width < startPoint.X + cargo.Width; width++)
                {
                    if (length < ContainerMap.GetLength(0) && width < ContainerMap.GetLength(1))
                    {
                        if (ContainerMap[length, width] is not null) return false;
                    } 
                    else return false;
                }
            }
            return true;
        }
        public Point FillMap(IPoint startPoint, ICargo cargo)
        {
            int X = 0;
            int Y = 0;
            for (int length = startPoint.Y; length < startPoint.Y + cargo.Length; length++)
            {
                for (int width = startPoint.X; width < startPoint.X + cargo.Width; width++)
                {
                    if (length >= ContainerMap.GetLength(0) || width >= ContainerMap.GetLength(1)) return null;
                    ContainerMap[length, width] = cargo.Id.ToString();
                    X = width;
                }
                Y = length;
            }
            return new Point(X, Y);
        }
        public bool EraceCargoFromMap(ICargo cargo)
        {
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
                                LoadList.Remove(cargo.Id);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public Coordinates FindPlace(ICargo cargo)
        {
            for (int i = 0; i < ContainerMap.GetLength(0); i++)
            {
                for (int j = 0; j < ContainerMap.GetLength(1); j++)
                {
                    if (CheckSquare(new Point(j, i), cargo))
                    {
                        Point startPoint = new Point(j, i);
                        Point endPoint = FillMap(startPoint, cargo);
                        return new Coordinates(startPoint, endPoint);
                    }
                    else continue;
                }
            }
            return null;
        }
    }
}
