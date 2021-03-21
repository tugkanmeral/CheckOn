using CheckOn.Core.Entities;
using Phoenix.LayerBases.Entity;
using System;

namespace CheckOn.DataAccess.Entities
{
    public class Cafe : CafeBase, IEntity<int>
    {
        public int Id { get; set; }
    }
}
