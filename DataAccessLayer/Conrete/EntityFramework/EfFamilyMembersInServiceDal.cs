﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfFamilyMembersInServiceDal:EfEntityRepositoryBase<FamilyMembersInService,MilitaryBaseContext>,IFamilyMemberInServiceDal
    {
    }
}
