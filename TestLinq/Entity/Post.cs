using System;
using System.Collections.Generic;
using System.Text;

namespace TestLinq.Entity
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
