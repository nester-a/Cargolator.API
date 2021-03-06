using Cargolator.API.Base.Enums;
using Cargolator.API.Base.EventArgs;
using Cargolator.API.Base.Interfaces;
using System;

namespace Cargolator.API.Base
{
    public class Cargo : ICargo
    {
        public delegate void CargoHandler(object sender, CargoEventArgs e);
        public event CargoHandler CargoEvent;

        public int Id { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public CargoStatus Status { get; private set; }

        public Cargo(int id, int length, int width)
        {
            if (length == 0) throw new ArgumentException("Cargo lenght can not be 0", "Length");
            if (width == 0) throw new ArgumentException("Cargo Width can not be 0", "Width");
            Id = id;
            Length = length;
            Width = width;
            Status = CargoStatus.Wait;
        }

        public override bool Equals(object obj)
        {
            if(obj is Cargo && obj is not null)
            {
                var temp = obj as Cargo;
                return Id.Equals(temp.Id) && Length.Equals(temp.Length) && Width.Equals(temp.Width);
            }
            return false;
        }

        public void ChangeStatus(CargoStatus newStatus)
        {
            if(newStatus == Status)
            {
                CargoEvent?.Invoke(this, new CargoEventArgs($"The cargo status already this", false));
                return;
            }
            CargoStatus oldStatus = Status;
            Status = newStatus;
            CargoEvent?.Invoke(this, new CargoEventArgs($"The cargo status changed from {nameof(oldStatus)} to {nameof(newStatus)}", true));
        }
    }
}
