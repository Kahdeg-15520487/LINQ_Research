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
    public class BlogController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IBlogService blogService;
        public BlogController(IUserService userService, IBlogService blogService)
        {
            this.userService = userService;
            this.blogService = blogService;
        }

        [HttpGet]
        public IEnumerable<BlogDto> GetAll()
        {
            return this.blogService.GetAll();
        }

        [HttpGet("{id}")]
        public BlogDto Get(Guid id)
        {
            return this.blogService.Get(id);
        }

        [HttpPost]
        public BlogDto Create([FromBody] BlogDto blog)
        {
            return this.blogService.Create(blog);
        }
    }
}
