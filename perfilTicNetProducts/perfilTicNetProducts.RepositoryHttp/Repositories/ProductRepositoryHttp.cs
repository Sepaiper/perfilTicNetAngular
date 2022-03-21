using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace perfilTicNetProducts.RepositoryHttp.Repositories
{
    public class ProductRepositoryHttp : IProductRepositoryHttp
    {

        public async Task<bool> SearchCategory(Product product)
        {
            try
            {
                Uri baseAddress = new($"http://localhost:27970/api/ReadCategory/{product.Category}");
                HttpClient cliente = new();
                ResponseCategory Category = new();
                HttpResponseMessage response = await cliente.GetAsync(baseAddress);
                if (response.IsSuccessStatusCode)
                {
                    var jsonStrinfy = response.Content.ReadAsStringAsync().Result;
                    Category = JsonSerializer.Deserialize<ResponseCategory>(jsonStrinfy, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                return Category.Name != null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
