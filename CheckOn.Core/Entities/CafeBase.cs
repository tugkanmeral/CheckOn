using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Core.Entities
{
    public abstract class CafeBase : IPlace
    {
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double Fulness { get; set; }
        public string Address { get; set; }
    }
}
