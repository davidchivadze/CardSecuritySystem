using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : BaseModel
    {
        protected readonly Data _database;

        public BaseRepository(Data database)
        {
            _database = database;
        }

        public void Add(Tentity entity)
        {
            _database.Set<Tentity>().Add(entity);
        }

        public void AddRange(IEnumerable<Tentity> entities)
        {
            _database.Set<Tentity>().AddRange(entities);
        }

        public IEnumerable<Tentity> Find(Expression<Func<Tentity, bool>> predicate)
        {
            return _database.Set<Tentity>().Where(predicate);
        }

        public Tentity Get(int ID)
        {
            return _database.Set<Tentity>().Find(ID);
        }

        public IEnumerable<Tentity> GetAll()
        {
            return _database.Set<Tentity>();
        }

        public void Remove(Tentity entity)
        {
            _database.Set<Tentity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Tentity> entities)
        {
            _database.Set<Tentity>().RemoveRange(entities);
        }





        //private Data _database;
        //protected Data Database
        //{
        //    get
        //    {
        //        return _database = _database ?? new Data();
        //    }
        //}

        //public T Add(T entity)
        //{
        //    T returnObjec = Database.Set<T>().Add(entity);
        //    Database.SaveChanges();
        //    return returnObjec;
        //}

        //public IQueryable<T> Get()
        //{
        //    return Database.Set<T>();
        //}

        //public T Update(T entity)
        //{
        //    Database.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        //    Database.SaveChanges();
        //    return entity;
        //}
    }
}
