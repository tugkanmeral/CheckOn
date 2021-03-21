using CheckOn.Business.Abstract;
using CheckOn.DataAccess.Abstract;
using CheckOn.DataAccess.Entities;
using Phoenix.LayerBases.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Business
{
    public class CafeManager : ServiceBase<Cafe, int> , ICafeService
    {
        public CafeManager(ICafeRepository cafeRepository) : base(cafeRepository)
        {

        }
    }
}
