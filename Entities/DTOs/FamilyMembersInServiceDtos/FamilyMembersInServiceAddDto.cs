﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.FamilyMembersInServiceDtos
{
    public class FamilyMembersInServiceAddDto:IDto
    {
        public int PersonelId { get; set; }

        public int MemberId { get; set; }

        public string? Record { get; set; }
    }
}
