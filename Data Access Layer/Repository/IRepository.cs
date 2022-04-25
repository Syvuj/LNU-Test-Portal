using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public interface IRepository <TEntity> where TEntity:BaseEntity
    {
        void Insert(TEntity entity) { }
        void Update(TEntity entity) { }
        void Delete(TEntity entity) { }
        public TEntity GetModel(TEntity entity);
        IEnumerable<TEntity> SelectAll();
        public TEntity SelectAllById(int id);
        public IEnumerable<TEntity> SelectAll(Expression<Func<TEntity, bool>> selector);
        public TEntity SelectOneById(int Id);
    }
}
