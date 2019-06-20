using ChessServer.Dal;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options)
        {
        }

        public ChessDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<BoardState> BoardStates { get; set; }
    }
}
