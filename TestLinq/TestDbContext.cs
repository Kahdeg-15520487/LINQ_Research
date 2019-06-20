using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TestLinq.Entity;
using System.Linq;

namespace TestLinq
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public TestDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot Configuration = builder.Build();
            optionsBuilder.UseSqlServer(Configuration["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Blog>().Property(b => b.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Post>().Property(p => p.Id).HasDefaultValueSql("NEWID()");

            Guid userId = Guid.NewGuid();
            Guid blogId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                Name = "batan"
            });

            modelBuilder.Entity<Blog>().HasData(new Blog
            {
                Id = blogId,
                Name = "batanvlog",
                UserId = userId
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = Guid.NewGuid(),
                Name = "100 canh ga chien nuoc mam",
                BlogId = blogId,
                Content = "Cac chau oi ..."
            });

            modelBuilder.Entity<Customer>().HasData(
                new Customer[]
                {
                    new Customer
                    {
                        Id=1,
                        Name="Molly",
                        Address="W Smithfield, London EC1A 7BE",
                        City="London"
                    },
                    new Customer
                    {
                        Id=2,
                        Name="Sherlock",
                        Address="221b Baker St",
                        City="London"
                    },
                    new Customer
                    {
                        Id=3,
                        Name="Mycroft",
                        Address="10 Downing St",
                        City="London"
                    },
                }
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
