using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Core.Entities
{
    public interface IPlace
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Address { get; set; }
    }
}
