﻿using perfilTicNetCategories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.UseCasesPorts
{
    public interface ICreateCategoryOutputPort
    {
        Task Handle(CategoryOutputDTO category);
    }
}
