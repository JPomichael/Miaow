using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.jq.Service
{
    public class SightInfoSortService : ISightInfoSortService
    {
        Miaow.Domain.Repository.ISightInfoSortRepository sightSortRepository;

        public SightInfoSortService(Miaow.Domain.Repository.ISightInfoSortRepository sightSort)
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
