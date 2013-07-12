using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using FluentValidation;
using FluentValidation.Mvc;

namespace iPow.Domain.Dto.Validate
{
    using iPow.Domain.Dto;
    public class Sys_MvcControllerDtoValidate : AbstractValidator<Sys_MvcControllerDto>
    {
    	public Sys_MvcControllerDtoValidate()
    	{
    
    	}
    }
}
