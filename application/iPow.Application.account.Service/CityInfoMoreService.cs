using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Domain.Dto;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.account.Service
{
    public class CityInfoMoreService : ICityInfoMoreService
    {
        iPow.Domain.Repository.ICityInfoMoreRepository cityInfoMoreRepository;

        public CityInfoMoreService(iPow.Domain.Repository.ICityInfoMoreRepository cityInfoMore)
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
