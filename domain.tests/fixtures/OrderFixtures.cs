namespace domain.tests;

public class OrderFixtures : IDisposable
{
    public Order Order { get; set; }

    public OrderFixtures()
    {
        Order = new Order();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

