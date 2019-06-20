using System;
using System.Collections.Generic;
using System.Text;

namespace TestLinq.Contract.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }
    }
}
