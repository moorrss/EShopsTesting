namespace domain;

public class Order
{
    public DateTime DateTime { get; set; }
    public int OrderNumber { get; set; } = 12345;

    public Customer? Customer { get; set; }

    private readonly List<OrderItem> _orderItems = new();

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();


    public Order()
    {
        DateTime = DateTime.Now;
    }

    public void AddOrderItem(OrderItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Måste finnas en orderrad");
        }
        _orderItems.Add(item);
    }
    public bool SaveOrder()
    {
        if (Customer == null)
        {
            throw new InvalidOperationException("En kund måste finnas för att kunna spara ordern.");
        }

        if (_orderItems.Count == 0)
        {
            throw new InvalidOperationException("Ordern måste ha minst en orderrad för att kunna sparas.");
        }

        return true;
    }
}
