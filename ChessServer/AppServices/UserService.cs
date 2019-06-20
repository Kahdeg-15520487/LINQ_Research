using AutoMapper;
using ChessServer.Contracts;
using ChessServer.Contracts.Dtos;
using ChessServer.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer.AppServices
{
    public class UserService : IUserService
    {
        private readonly ChessDbContext context;
        private readonly IMapper mapper;

        public UserService(ChessDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUser()
        {
            return this.mapper.Map<IEnumerable<UserDto>>(this.context.Users.AsEnumerable());
        }

        public UserDto GetUser(Guid id)
        {
            return this.mapper.Map<UserDto>(this.context.Users.FirstOrDefault(u => u.Id.Equals(id)));
        }

        public UserDto CreateUser(UserDto dto)
        {
            var user = this.mapper.Map<User>(dto);
            this.context.Users.Add(user);
            this.context.SaveChanges();
            return this.mapper.Map<UserDto>(user);
        }
    }
}
