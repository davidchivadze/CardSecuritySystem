using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private Data _database;
        protected Data Database
        {
            get
            {
                return _database = _database ?? new Data();
            }
        }
        public T Add(T entity)
        {
            T returnObjec = Database.Set<T>().Add(entity);
            Database.SaveChanges();
            return returnObjec;
        }

        public IQueryable<T> Get()
        {
            return Database.Set<T>();
        }

        public T Update(T entity)
        {
            Database.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Database.SaveChanges();
            return entity;
        }
    }
}
