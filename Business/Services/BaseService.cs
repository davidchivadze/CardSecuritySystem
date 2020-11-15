using Business.Interface;
using Core.Helpers;
using Domain;
using Domain.Interface;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class BaseService:ServiceHelper,IBaseService
    {
        private IUnitOfWork _unitOfWork;
        protected IUnitOfWork UnitOfWork { get
            {
                return _unitOfWork = _unitOfWork ?? new UnitOfWork();
            } 
        }
    }
}
