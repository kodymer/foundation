namespace Contoso.OnlineStore.Business
{
    public class OrderDetail
    {

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public OrderDetail(string description, int quantity = default, decimal price = default)
        {
            Check.NotNull(description, nameof(description));

            Description = description;
            Quantity = quantity;
            Price = price;
        }

        public static OrderDetail Create(string description, int quantity, decimal price)
        {
            return new OrderDetail(description, quantity, price);
        }

        public override string ToString()
        {
            return $"[Order Detail:{Description}, Quiantity: {Quantity}, price: {Price}]";
        }
    }
}