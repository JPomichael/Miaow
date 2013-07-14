using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miaow.Domain.Dto;

namespace Miaow.Application.account.Service
{
    public interface ICityInfoMoreService
    {
        Sys_CityInfoMoreDto GetSightDestinationLonAndLat(string city);
    }
}
