﻿using PerfilTicNetProduct.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCasesPorts
{
    public interface IGetAllProductBCategoryInputPort
    {
        Task Handle(ListProductsBCategoryInputDTO product);
    }
}
