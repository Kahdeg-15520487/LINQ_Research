using ChessServer.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUser();
        UserDto GetUser(Guid id);

        UserDto CreateUser(UserDto dto);
    }
}
