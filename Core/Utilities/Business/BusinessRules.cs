﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var item in logics)
            {
                if (!item.IsSuccess)
                {
                    return item;
                }
            }
            return null;
        }
       

    }
}
