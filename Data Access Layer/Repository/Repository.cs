using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repository
{
    public class Repository<T> :IRepository<T> where T :BaseEntity
    {
        private readonly DataContext dataBaseContext;
        private readonly DbSet<T> entitiesDataSet;

        public Repository(DataContext context)
        {
            dataBaseContext = context;
            entitiesDataSet = context.Set<T>();
        }
        public void Insert(T entity)
        {
            entitiesDataSet.Add(entity);
            dataBaseContext.SaveChanges();
        }
        public void Update(T entity)
        {
            dataBaseContext.Update(entity);
            dataBaseContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            dataBaseContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            dataBaseContext.SaveChanges();
        }
        public T GetModel(T entity)=> entitiesDataSet.Find(entity);
        public IEnumerable<T> SelectAll()=> entitiesDataSet.ToList();
        public T SelectOneById(int Id)=> entitiesDataSet.FirstOrDefault(x => x.id == Id);
        
        public IEnumerable<T> SelectAll(Expression<Func<T, bool>> selector,params Expression<Func<T, object>>[] includeProperties)
        {
            return GetValueWithInclude(includeProperties).Where(selector).ToList();
        }

        private IQueryable<T> GetValueWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> querriedEntities = entitiesDataSet.AsNoTracking();

            return includeProperties.Aggregate(querriedEntities, (current, includeProperty)
                => current.Include(includeProperty));
        }
    }
}


