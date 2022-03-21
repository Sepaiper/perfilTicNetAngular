﻿using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetProducts.Entities.Interfaces
{
    public interface IProductRepositoryHttp
    {
        Task<bool> SearchCategory(Product product);
    }
}
