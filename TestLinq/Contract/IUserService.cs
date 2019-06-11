using System;
using System.Collections.Generic;
using System.Text;
using TestLinq.Contract.Dtos;

namespace TestLinq.Contract
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto Get(Guid id);
        UserDto GetCompiledQuerry(Guid id);
        UserDto GetLinq(Guid id);
        UserDto GetRawSql(Guid id);
        UserDto GetStoredProcedure(Guid id);
    }
}
