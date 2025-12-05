using FluentAssertions;

namespace domain.tests;

public class OrderItemTests
{
    [Fact]
    public void ShouldCreateOrderItemWhenValid()
    {
        // Arrange
        var product = new Product("AA-123", "TestProduct", 100m);
        var quantity = 2;

        // Act
        var orderItem = new OrderItem(product, quantity);

        // Assert
        orderItem.Product.Should().Be(product);
        orderItem.Quantity.Should().Be(quantity);
        orderItem.Price.Should().Be(100m); // Priset ska sättas från produkten
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ShouldThrowExceptionWhenQuantityIsLessThanOne(int invalidQuantity)
    {
        // Arrange
        var product = new Product("AA-123", "TestProduct", 100m);

        // Act
        Action action = () => new OrderItem(product, invalidQuantity);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Antal måste vara minst 1*");
    }
}
