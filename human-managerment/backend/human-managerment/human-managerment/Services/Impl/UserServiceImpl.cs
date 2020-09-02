using AutoMapper;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class UserServiceImpl : UserService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public UserServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public UserDTO FindOne(UserEntity login)
        {
            bool isUserExit = _humanManagerContext.Users.Where(u => u.Username == login.Username).Any();

            if (!isUserExit)
                throw new Exception(SystemContant.LOGIN_FAIL);

            UserEntity user = _humanManagerContext.Users.Where(u => u.Username == login.Username)
                                  .Include(u => u.UserRoles)
                                  .ThenInclude(ur => ur.Role)
                                  .ThenInclude(r => r.ResourceRoles)
                                  .ThenInclude(rr => rr.Resource)
                                  .SingleOrDefault();

            bool verified = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);

            if (!verified)
                throw new Exception(SystemContant.LOGIN_FAIL);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
