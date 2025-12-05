using FluentAssertions;

namespace domain.tests;

public class OrderTests
{
    [Fact]
    public void ShouldInitializeWithDefaultValues()
    {
        //Act...
        var order = new Order();

        //Assert..
        order.OrderNumber.Should().Be(12334);
        order.DateTime.Date.Should().Be(DateTime.Today);

    }

    [Fact]
    public void AddOrderItemShouldAddItemToList()
    {
        // Arrange
        var order = new Order();
        var product = new Product("BB-111", "Laptop", 15000m);
        var item = new OrderItem(product, 1);

        // Act
        order.AddOrderItem(item);

        // Assert
        order.OrderItems.Should().HaveCount(1);
        order.OrderItems.Should().Contain(item);
    }

    [Fact]
    public void SaveOrderShouldReturnTrueWhenCustomerAndItemsExist()
    {
        // Arrange
        var order = new Order();
        order.Customer = new Customer { FirstName = "Anna", LastName = "Andersson", Email = "annaAndersson@test.com" };

        var product = new Product("CC-123", "Phone", 5000m);
        order.AddOrderItem(new OrderItem(product, 1));

        // Act
        var result = order.SaveOrder();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void SaveOrderShouldThrowWhenCustomerIsMissing()
    {
        // Arrange
        var order = new Order();
        var product = new Product("CC-123", "Phone", 5000m);
        order.AddOrderItem(new OrderItem(product, 1));

        // Act
        Action action = () => order.SaveOrder();

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("*En kund måste finnas*");
    }
    [Fact]
    public void SaveOrder_ShouldThrow_WhenOrderItemsAreMissing()
    {
        // Arrange
        var order = new Order();
        order.Customer = new Customer();

        // Act
        Action action = () => order.SaveOrder();

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("*Ordern måste ha minst en orderrad*");
    }
}
