﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<List<OperationClaim>> GetClaimsAsync(User user);
        Task AddAsync(User user);
        Task<User> GetByMailAsync(string email);
    }
}
