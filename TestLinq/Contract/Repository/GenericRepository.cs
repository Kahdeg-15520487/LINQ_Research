using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestLinq.Contract.Repository
{
    class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly TestDbContext context;

        private readonly DbSet<TEntity> entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public GenericRepository(TestDbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public TestDbContext Context => this.context;

        public IQueryable<TEntity> Set()
        {
            return this.entities;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = this.entities.Where(predicate);
            return query;
        }

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Insert(TEntity entity)
        {
            this.entities.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void InsertOrUpdate(TEntity entity)
        {
            this.context.Update(entity);
            this.context.SaveChanges();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public TEntity InsertGetEntity(TEntity entity)
        {
            this.entities.Add(entity);
            this.context.SaveChanges();

            return entity;
        }

        public DbContext GetDbContext()
        {
            return this.context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>();
        }
    }
}
