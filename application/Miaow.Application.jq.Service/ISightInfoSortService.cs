using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.jq.Service
{
    public interface ISightInfoSortService
    {

        bool SightIsInSort(int id);


        //List<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoSort>  GetTopClassBySight(int ,id);

    }
}
