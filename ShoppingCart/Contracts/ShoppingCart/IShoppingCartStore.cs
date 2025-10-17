using Domains;
namespace Contracts
{
    public interface IShoppingCartStore
    {
        public ShoppingCart Get(int userId);
        void Save(ShoppingCart shoppingCart);
    }
}
