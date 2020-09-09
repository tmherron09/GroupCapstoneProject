using GadeliniumGroupCapstone.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PetAppDbContext PetAppDbContext { get; set; }

        public RepositoryBase(PetAppDbContext petAppDbContext)
        {
            PetAppDbContext = petAppDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return PetAppDbContext.Set<T>().AsNoTracking();

        }
        public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression)
        {
            return PetAppDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            PetAppDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            PetAppDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            PetAppDbContext.Set<T>().Update(entity);
        }
    }
}
