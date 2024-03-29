﻿using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICityRepository : IBaseRepository<City>
    {
        IEnumerable<City> GetCitiesByCountryID(int? countryID);
    }
}
