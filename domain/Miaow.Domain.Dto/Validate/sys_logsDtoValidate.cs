using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using FluentValidation;
using FluentValidation.Mvc;

using Miaow.Domain.Dto;

namespace Miaow.Domain.Dto.Validate
{
    
    public class sys_logsDtoValidate : AbstractValidator<sys_logsDto>
    {
    	public sys_logsDtoValidate()
    	{
    
    	}
    }
}
