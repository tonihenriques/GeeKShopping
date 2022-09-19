namespace GeekShopping.teste.Data.ValueObjects
{
    public class CartVO
    {
        public CartHeaderVO CartHeader { get; set; }

        public IEnumerable<CartDetailVO> CartDetail { get; set; }
    }
}
