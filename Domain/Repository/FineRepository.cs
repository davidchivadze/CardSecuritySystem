using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class FineRepository:BaseRepository<Fine>,IFineRepository
    {
        public FineRepository(Data database) : base(database)
        {

        }
    }
}
