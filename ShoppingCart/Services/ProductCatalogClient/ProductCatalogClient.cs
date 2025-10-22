using Contracts;
using Domains;
using System.Text.Json;

namespace Services
{
    public class ProductCatalogClient : IProductCatalogClient
    {
        private readonly HttpClient _httpClient;
        private static string productCatalogBaseUrl = @"https://git.io/JeHiE";
        private static string getProductPathTemplate = "?productIds=[{0}]";
        public ProductCatalogClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(productCatalogBaseUrl);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient = httpClient;
        }
        public Task<IEnumerable<ShoppingCartItem>> GetShoppingCrtItems(int[] productCatalogIds)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> RequestProductFromProductCatalog(int[] productCatalogIds)
        {
            var productsResource = string.Format(getProductPathTemplate,string.Join(",", productCatalogIds));
            return await _httpClient.GetAsync(productsResource);
        }

        private static async Task<IEnumerable<ShoppingCartItem>>
        ConvertToShoppingCartItems(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var products = await
            JsonSerializer.DeserializeAsync<List<ProductCatalogProduct>>(
            await response.Content.ReadAsStreamAsync(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new();
            return products
            .Select(p =>
            new ShoppingCartItem(
            p.ProductId,
            p.ProductName, p.ProductDescription,p.Price));
        }

        private record ProductCatalogProduct(int ProductId,string ProductName,string ProductDescription,Money Price);
    }
}
