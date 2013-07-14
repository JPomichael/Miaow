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
    
    public class m_user_index_infoDtoValidate : AbstractValidator<m_user_index_infoDto>
    {
    	public m_user_index_infoDtoValidate()
    	{
    
    	}
    }
}
