using System.ComponentModel.DataAnnotations;
using FluentAssertions;

namespace domain.tests;

public class CustomerTests : IClassFixture<CustomerFixture>
{
    readonly CustomerFixture fixture;
    public CustomerTests(CustomerFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void ShouldCreateAnInstanceOfCustomer()
    {
        Assert.IsType<Customer>(fixture.Customer);
    }

    [Fact]
    public void ShouldEqualWithCustomer()
    {
        Assert.Equal("Anna", fixture.Customer.FirstName);
        Assert.Equal("Andersson", fixture.Customer.LastName);
        Assert.Equal("annaandersson@gmail.com", fixture.Customer.Email);
        Assert.Equal(076786234, fixture.Customer.Phone);
    }

    [Fact]
    public void ShouldReturnTrueIfItHasAll()
    {
        //Act..
        fixture.Customer.FirstName = "Anna";
        fixture.Customer.LastName = "Andersson";
        fixture.Customer.Email = "annaAndersson@gmail.com";
    }

    [Fact]
    public void SaveShouldThrowArgumentExeptionsIfSomeOneIsNull()
    {
        fixture.Customer.FirstName = "Anna";
        fixture.Customer.LastName = "Andersson";
        //fixture.Customer.Email = "annaAndersson@gmail.com";

        ArgumentException ex = Assert.Throws<ArgumentException>(() => fixture.Customer.SaveCusomter());

        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
        Assert.Equal("Information saknas", ex.Message);
    }

    [Fact]
    public void UpdateShouldReturnTrueWhenSuccessful()
    {
        fixture.Customer.LastName = "Andersson";
        fixture.Customer.Email = "annaAndersson@gmail.com";

        var result = fixture.Customer.UpdateCusomter();

        Assert.True(result);
    }

    [Fact]
    public void UpdateShouldThrowArgumentExptionWhenUnsuccessful()
    {
        fixture.Customer.LastName = "Andersson";
        // fixture.Customer.Email = "annaAndersson@gmail.com";

        var result = fixture.Customer.UpdateCusomter();

        ArgumentException ex = Assert.Throws<ArgumentException>(() => fixture.Customer.UpdateCusomter());

        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
        Assert.Equal("Information saknas", ex.Message);
    }

    [Fact]
    public void ShouldReturnTrueWhenSuccessful()
    => fixture.Customer.SaveCusomter().Should().BeTrue();


}