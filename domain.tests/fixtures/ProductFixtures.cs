namespace domain.tests;

public class ProductFixture : IDisposable
{
    public Product Product { get; set; }

    public ProductFixture()
    {
        Product = new Product(itemNumber: "AA-111", name: "MacBook", price: 12599);
    }


    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
