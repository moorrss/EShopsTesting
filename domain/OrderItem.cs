namespace domain;

public class OrderItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public OrderItem(Product product, int quantity)
    {
        if (product == null)
        {
            throw new ArgumentException("Minst 1 produkt");
        }
        Product = product;
        Quantity = quantity;
        Price = product.Price;
    }
}
