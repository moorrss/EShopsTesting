namespace domain.tests;

public class CustomerFixture : IDisposable
{
    public Customer Customer { get; set; }

    public CustomerFixture()
    {
        Customer = new Customer();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}