using GeekShopping.Web.Models;
using GeekShopping.Web.Utils;
using System.Collections;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services.IServices
{
    public class teste : Iteste
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/teste";

        public teste(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable> FindAllProducts()
        {
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }
    }
}
