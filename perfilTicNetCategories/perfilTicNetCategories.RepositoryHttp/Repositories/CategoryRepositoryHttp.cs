using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace perfilTicNetCategories.RepositoryHttp.Repositories
{
    public class CategoryRepositoryHttp : ICategoryRepositoryHttp
    {
        public async Task<bool> SearchProduct(Category category)
        {
            try
            {
                Uri baseAddress = new($"http://localhost:22204/api/GetAllProductBCategory/{category.IdCategory}");
                HttpClient cliente = new();
                ResponseProduct Product = new();
                HttpResponseMessage response = await cliente.GetAsync(baseAddress);
                if (response.IsSuccessStatusCode)
                {
                    var jsonStrinfy = response.Content.ReadAsStringAsync().Result;
                    Product = JsonSerializer.Deserialize<ResponseProduct>(jsonStrinfy, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                return (Product.Count > 0);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
