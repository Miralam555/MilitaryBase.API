﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
