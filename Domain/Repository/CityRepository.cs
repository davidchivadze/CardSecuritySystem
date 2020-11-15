﻿using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(Data Database) : base(Database)
        {

        }
    }
}
