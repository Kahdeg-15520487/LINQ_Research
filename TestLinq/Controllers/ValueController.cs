using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TestLinq.Contract.Dtos;

namespace TestLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        public UserDto Get()
        {
            return new UserDto();
        }

        [HttpGet("n")]
        public UserDto GetNull()
        {
            return null;
        }
    }
}
