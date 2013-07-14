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
    
    public class sys_rolesDtoValidate : AbstractValidator<sys_rolesDto>
    {
    	public sys_rolesDtoValidate()
    	{
    
    	}
    }
}
