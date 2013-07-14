using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Miaow.Domain.Dto;
using Miaow.Infrastructure.Crosscutting.EntityToDto;

namespace Miaow.Application.account.Service
{
    public class CityInfoMoreService : ICityInfoMoreService
    {
        Miaow.Domain.Repository.ICityInfoMoreRepository cityInfoMoreRepository;

        public CityInfoMoreService(Miaow.Domain.Repository.ICityInfoMoreRepository cityInfoMore)
        {
            if (cityInfoMore == null)
            {
                throw new ArgumentNullException("cityInfoMoreRepository is null");
            }
            cityInfoMoreRepository = cityInfoMore;
        }

        public Sys_CityInfoMoreDto GetSightDestinationLonAndLat(string city)
        {
            var res = cityInfoMoreRepository.GetList(e => e.City == city).FirstOrDefault();
            return res.ToDto();
        }
    }
}
