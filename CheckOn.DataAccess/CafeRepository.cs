using CheckOn.DataAccess.Abstract;
using CheckOn.DataAccess.Entities;
using CheckOn.DataAccess.EntityFrameworkCore;
using Phoenix.LayerBases.DataAccess;
using System;

namespace CheckOn.DataAccess
{
    public class CafeRepository : RepositoryBase<Cafe, int>, ICafeRepository
    {
        public CafeRepository(CheckOnDatabaseContext context) : base(context)
        {
        }
    }
}
