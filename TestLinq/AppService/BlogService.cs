using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLinq.Contract;
using TestLinq.Contract.Dtos;
using TestLinq.Entity;

namespace TestLinq.AppService
{
    class BlogService : IBlogService
    {
        private TestDbContext context;
        private IMapper mapper;
        private ILogger logger;

        public BlogService(TestDbContext context, IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger<UserService>();
        }

        public IEnumerable<BlogDto> GetAll()
        {
            IQueryable<Blog> query = this.context.Blogs.Include(b => b.User).Include(b => b.Posts);

            return this.mapper.Map<List<BlogDto>>(query.ToList());
        }

        public BlogDto Get(Guid id)
        {
            IQueryable<Blog> query = this.context.Blogs.Where(b => b.Id.Equals(id));

            Blog blog = query.FirstOrDefault();

            return this.mapper.Map<BlogDto>(blog);
        }

        public BlogDto Create(BlogDto blog)
        {
            Blog newblog = this.mapper.Map<Blog>(blog);

            BlogDto bb = this.mapper.Map<BlogDto>(this.context.Blogs.Add(newblog).Entity);
            this.context.SaveChanges();

            return bb;
        }
    }
}
