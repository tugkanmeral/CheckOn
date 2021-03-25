using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.DataAccess.Entities
{
    public class CafeManager : IEntity<int>
    {
        public int Id { get; set; }
        public int CafeId { get; set; }
        public int UserId { get; set; }

    }
}
