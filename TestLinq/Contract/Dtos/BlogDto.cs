using System;
using System.Collections.Generic;
using System.Text;

namespace TestLinq.Contract.Dtos
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UserDto User { get; set; }

        public PostDto[] Posts { get; set; }
    }
}
