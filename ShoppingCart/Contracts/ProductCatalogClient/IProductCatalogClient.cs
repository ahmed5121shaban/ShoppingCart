using Domains;

namespace Contracts
{
    public interface IProductCatalogClient
    {
        public Task<IEnumerable<ShoppingCartItem>> GetShoppingCrtItems(int[] productCatalogIds);
        public Task<HttpResponseMessage> RequestProductFromProductCatalog(int[] productCatalogIds);
    }
}
