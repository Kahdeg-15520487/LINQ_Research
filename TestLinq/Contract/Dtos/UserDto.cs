using System;
using System.Collections.Generic;
using System.Text;

namespace TestLinq.Contract.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BlogId { get; set; }
    }
}
