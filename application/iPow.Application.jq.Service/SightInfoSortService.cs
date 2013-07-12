using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.jq.Service
{
    public class SightInfoSortService : ISightInfoSortService
    {
        iPow.Domain.Repository.ISightInfoSortRepository sightSortRepository;

        public SightInfoSortService(iPow.Domain.Repository.ISightInfoSortRepository sightSort)
        {
            sightSortRepository = sightSort;
        }

        public bool SightIsInSort(int id)
        {
            var res = sightSortRepository.GetList(e => e.SightId == id).Any();
            return res;
        }
    }
}
