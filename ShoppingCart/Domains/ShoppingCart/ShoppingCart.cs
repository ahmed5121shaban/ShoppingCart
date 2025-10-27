using Contracts;
using Services;

namespace Domains
{
    public class ShoppingCart
    {
        private readonly IEventStore _eventStore;
        readonly HashSet<ShoppingCartItem> items = new();
        public int UserId { get; }
        public IEnumerable<ShoppingCartItem> Items => items;
        public ShoppingCart(int userId)
        {
            UserId = userId;
            _eventStore = new EventStore();
        }

        public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems,IEventStore eventStore)
        {
            foreach (var item in shoppingCartItems)
                if (items.Add(item))
                    _eventStore.Raise("ShoppingCartItemAdded", new { UserId, item });
        }
        public void RemoveItems(int[] productCatalogueIds, IEventStore eventStore) =>
            items.RemoveWhere( i => productCatalogueIds.Contains(i.ProductCatalogueId) );
    }

    public record ShoppingCartItem(int ProductCatalogueId, string ProductName, string Description, Money Price);
    public record Money(string Currency, decimal Amount);
}
