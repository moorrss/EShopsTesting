namespace domain;

public class Product(string itemNumber, string name, decimal price)
{
    public string ItemNumber { get; set; } = itemNumber;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;



    public void UpdateProduct(string newItemNumber, string newName, decimal newPrice)
    {
        if (string.IsNullOrWhiteSpace(newName)) { throw new ArgumentException("Namn saknas"); }

        if (newName.Length < 5) { throw new ArgumentException("Namn måste vara minst 5 tecken"); }

        if (string.IsNullOrWhiteSpace(newItemNumber)) { throw new ArgumentException("ItemNubmer saknas"); }

        if (newItemNumber.Length < 7) { throw new ArgumentException("ItemNumber måste vara minst 7 tecken långt"); }

        if (newPrice < 0) { throw new ArgumentException("Priset kan inte vara mindre än noll"); }

        ItemNumber = newItemNumber;
        Name = newName;
        Price = newPrice;

    }

    public bool SaveProduct()
    {
        return true;
    }

}
