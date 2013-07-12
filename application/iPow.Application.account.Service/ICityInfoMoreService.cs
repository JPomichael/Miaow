using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Domain.Dto;

namespace iPow.Application.account.Service
{
    public interface ICityInfoMoreService
    {
        Sys_CityInfoMoreDto GetSightDestinationLonAndLat(string city);
    }
}
