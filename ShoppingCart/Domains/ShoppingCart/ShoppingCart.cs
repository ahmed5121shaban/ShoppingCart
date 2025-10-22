namespace Domains
{
    public class ShoppingCart
    {
        readonly HashSet<ShoppingCartItem> items = new();
        public int UserId { get; }
        public IEnumerable<ShoppingCartItem> Items => items;
        public ShoppingCart(int userId) => UserId = userId;
        public void AddItems(IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            foreach (var item in shoppingCartItems) items.Add(item);
        }
        public void RemoveItems(int[] productCatalogueIds) =>
            items.RemoveWhere( i => productCatalogueIds.Contains(i.ProductCatalogueId) );
    }

    public record ShoppingCartItem(int ProductCatalogueId, string ProductName, string Description, Money Price);
    public record Money(string Currency, decimal Amount);
}
