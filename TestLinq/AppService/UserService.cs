using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinq.Contract;
using TestLinq.Contract.Dtos;
using TestLinq.Entity;
using TestLinq.ExtensionMethods;

namespace TestLinq.AppService
{
    class UserService : IUserService
    {
        private TestDbContext context;
        private IMapper mapper;
        private ILogger logger;

        public UserService(TestDbContext context, IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger<UserService>();
        }

        public IEnumerable<UserDto> GetAll()
        {
            IQueryable<User> query = this.context.Users;

            return this.mapper.Map<List<UserDto>>(query.ToList());
        }

        public UserDto Get(Guid id)
        {
            IQueryable<User> query = this.context.Users.Where(usr => usr.Id.Equals(id));

            this.logger.LogInformation(query.ToSql());

            User user = query.FirstOrDefault();

            return this.mapper.Map<UserDto>(user);
        }

        public UserDto GetCompiledQuerry(Guid id)
        {
            Func<TestDbContext, User> QueryUserById = EF.CompileQuery<TestDbContext, User>(context => context.Users.FirstOrDefault(usr => usr.Id.Equals(id)));

            User user = QueryUserById(this.context);

            return this.mapper.Map<UserDto>(user);
        }


        public UserDto GetLinq(Guid id)
        {
            IQueryable<User> query = from u in this.context.Users
                                     where u.Id.Equals(id)
                                     select u;

            this.logger.LogInformation(query.ToSql());

            User user = query.FirstOrDefault();

            return this.mapper.Map<UserDto>(user);
        }

        public UserDto GetRawSql(Guid id)
        {
            IQueryable<User> query = this.context.Users.FromSql($"SELECT * FROM dbo.Users WHERE Id = {id}");

            this.logger.LogInformation(query.ToSql());

            User user = query.FirstOrDefault();

            return this.mapper.Map<UserDto>(user);
        }

        public UserDto GetStoredProcedure(Guid id)
        {
            IQueryable<User> query = this.context.Users.FromSql($"EXEC GetUserById @id= {id}");

            this.logger.LogInformation(query.ToSql());

            User user = query.FirstOrDefault();

            return this.mapper.Map<UserDto>(user);
        }

        public UserDto Create(UserDto user)
        {
            User newuser = this.mapper.Map<User>(user);
            UserDto uu = this.mapper.Map<UserDto>(this.context.Users.Add(newuser).Entity);
            this.context.SaveChanges();
            return uu;
        }
    }
}
