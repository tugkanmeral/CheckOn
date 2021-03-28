using CheckOn.Business.Abstract;
using CheckOn.DataAccess.Abstract;
using CheckOn.DataAccess.Entities;
using Phoenix.LayerBases.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckOn.Business
{
    public class CafeManager : ServiceBase<Cafe, int> , ICafeService
    {
        ICafeRepository _cafeRepository;
        public CafeManager(ICafeRepository cafeRepository) : base(cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }

        public async void UpdateCafeOccupancy(int cafeId, double occupancy)
        {
            Task<Cafe> cafeTask = _cafeRepository.GetAsync(c => c.Id == cafeId);
            Cafe cafe = await cafeTask;
            cafe.Occupancy = occupancy;

            _cafeRepository.UpdateAsync(cafe);
        }
    }
}
