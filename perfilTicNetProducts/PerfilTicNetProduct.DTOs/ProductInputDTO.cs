using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.DTOs
{
    public class ProductInputDTO
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int Weight { get; init; }
        public float Price { get; init; }
        public int Category { get; init; }
        public string ImageOne { get; init; }
        public string ImageTwo { get; init; }
        public string ImageThree { get; init; }

    }
}
