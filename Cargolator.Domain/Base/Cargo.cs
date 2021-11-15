using Cargolator.API.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargolator.API.Base
{
    public class Cargo : ICargo
    {
        public int Id { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public Cargo(int id, int length, int width)
        {
            Id = id;
            Length = length;
            Width = width;
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
    }
}
