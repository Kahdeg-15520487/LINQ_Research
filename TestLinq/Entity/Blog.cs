using System;
using System.Collections.Generic;
using System.Text;

namespace TestLinq.Entity
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
