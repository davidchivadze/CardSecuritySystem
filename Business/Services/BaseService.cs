using Business.Interface;
using Core.Helpers;
using Domain.Interface;
using Domain.Repository;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Business.Services
{
   public class BaseService:ServiceHelper, IBaseService/*<TEntity> where TEntity : BaseModel, new()*/
    {
        private IUnitOfWork _unitOfWork;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork ?? new UnitOfWork();
            }
        }

        //public void Add(TEntity entity)
        //{
        //    _unitOfWork.GetRepository<TEntity>().Add(entity);
        //}

        //public void AddRange(IEnumerable<TEntity> entities)
        //{
        //    _unitOfWork.GetRepository<TEntity>().AddRange(entities);
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _unitOfWork.GetRepository<TEntity>().Find(predicate);
        //}

        //public TEntity Get(int id)
        //{
        //    return _unitOfWork.GetRepository<TEntity>().Get(id);
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return _unitOfWork.GetRepository<TEntity>().GetAll();
        //}

        //public void Remove(TEntity entity)
        //{
        //    _unitOfWork.GetRepository<TEntity>().Remove(entity);
        //}

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    _unitOfWork.GetRepository<TEntity>().RemoveRange(entities);
        //}
    }
}
