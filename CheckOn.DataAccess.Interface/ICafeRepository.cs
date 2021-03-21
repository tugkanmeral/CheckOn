using CheckOn.DataAccess.Entities;
using Phoenix.LayerBases.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.DataAccess.Abstract
{
    public interface ICafeRepository : IRepository<Cafe, int>
    {
    }
}
