namespace Restaurant.Services.ShoppingCartAPI.Model.DTO
{
    public class CartDTO
    {
        public CartHeaderDTO CartHeader { get; set; }
        public IEnumerable<CartDetailDTO>? CartDetails { get; set; }
    }
}
