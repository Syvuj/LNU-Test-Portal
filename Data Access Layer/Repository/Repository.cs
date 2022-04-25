using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repository
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity :BaseEntity
    {
        private readonly DbContext dataBaseContext;

        private readonly DbSet<TEntity> entitiesDataSet;

        public Repository(DbContext context)
        {
            dataBaseContext = context;
            entitiesDataSet = context.Set<TEntity>();
        }
        public void Insert(TEntity entity)
        {
            entitiesDataSet.Add(entity);
            dataBaseContext.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            dataBaseContext.Update(entity);
            dataBaseContext.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            dataBaseContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            dataBaseContext.SaveChanges();
        }
        public TEntity GetModel(TEntity entity)
        {
            return entitiesDataSet.Find(entity);
        }
        public IEnumerable<TEntity> SelectAll()
        {
            return entitiesDataSet.ToList();
        }

        public IEnumerable<TEntity> SelectAll(Func<TEntity,bool> selector)
        {
            return entitiesDataSet.AsNoTracking().Where(selector).ToList();
        }

        public TEntity SelectAllById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> SelectAll(Expression<Func<TEntity, bool>> selector)
        {
            throw new NotImplementedException();
        }

        public TEntity SelectOneById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
