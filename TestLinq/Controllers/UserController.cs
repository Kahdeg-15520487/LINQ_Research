using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TestLinq.Contract;
using TestLinq.Contract.Dtos;

namespace TestLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return this.userService.GetAll();
        }

        [HttpGet("{id}")]
        public UserDto Get(Guid id)
        {
            return this.userService.Get(id);
        }

        [HttpGet("compiledquery/{id}")]
        public UserDto GetCompiledQuery(Guid id)
        {
            return this.userService.GetCompiledQuerry(id);
        }

        [HttpGet("linqsyntax/{id}")]
        public UserDto GetLinq(Guid id)
        {
            return this.userService.GetLinq(id);
        }

        [HttpGet("rawsql/{id}")]
        public UserDto GetRawSql(Guid id)
        {
            return this.userService.GetRawSql(id);
        }

        [HttpGet("storedprocedure/{id}")]
        public UserDto GetStoredProcedure(Guid id)
        {
            return this.userService.GetStoredProcedure(id);
        }
    }
}
