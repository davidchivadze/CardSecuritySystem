﻿using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class ForgivenessRepository:BaseRepository<Forgiveness>,IForgivenessRepository
    {
        public ForgivenessRepository(Data database) : base(database)
        {
            
        }
    }
}
