using FluentAssertions;

namespace domain.tests;

public class ProductTests : IClassFixture<ProductFixture>
{
    //readonly Product _product;
    readonly ProductFixture fixture;

    public ProductTests(ProductFixture fixture)
    {
        this.fixture = fixture;
        //  _product = new Product(itemNumber: "AA-111", name: "MacBook", price: 12599);
    }


    [Fact]
    public void ShouldCreateProductIstansWithCorrectInitalizing()
    {
        //Arrange...
        // var product = new Product(itemNumber: "AA-111", name: "MacBook", price: 12599);

        //Act...


        //Assert..
        Assert.IsType<Product>(fixture.Product);
    }

    [Fact]
    public void ShouldHaveEqualItemNumberNamePrice()
    {
        //Arrange...
        //  var product = new Product(itemNumber: "AA-222", name: "ChromeBook", price: 9899);

        //Act..


        //Assert..
        Assert.Equal("AA-111", fixture.Product.ItemNumber);
        Assert.Equal("MacBook", fixture.Product.Name);
        Assert.Equal(12599, fixture.Product.Price);
    }

    [Fact]
    public void ShouldUpdateProductNullAsName()
    {
        //Arrange..
        //   var product = new Product("AA-333", "MacBook", 15000);

        //Act..

        //Assert..
        ArgumentException ex = Assert.Throws<ArgumentException>(() => fixture.Product.UpdateProduct("AA-111", null, 12599));

        Assert.Equal("Namn saknas", ex.Message);
    }

    [Fact]
    public void ShouldUpdateProductEmtypStringAsName()
    {
        //var product = new Product("AA-123456", "MacBook", 15000);

        Assert.Throws<ArgumentException>(() => fixture.Product.UpdateProduct("AA-111", "", 12599));
    }

    /*[Fact]
    public void ShouldUpdateNameWithLessThenFiveLetters()
    {
       var product = new Product("AA-12345", "HPdator", 5999);

        Action action = () => product.UpdateProduct("AA-12345", "HP", 5999);

         Assert.Throws<ArgumentException>(() => product.UpdateProduct("AA-12345", "HP", 5999));

        action.Should().Throw<ArgumentException>().WithMessage("Namn måste vara minst 5 tecken");
    }
*/

    [Theory]
    [InlineData("M")]
    [InlineData("Ma")]
    [InlineData("Mac")]
    [InlineData("MacB")]

    public void ShouldUpdateNameWithLessThenFiveLetters(string name)
    {
        //var product = new Product("AA-12345", "HPdator", 5999);

        Action action = () => fixture.Product.UpdateProduct("AA-12345", "Ma", 12599);

        // Assert.Throws<ArgumentException>(() => product.UpdateProduct("AA-12345", "HP", 5999));

        action.Should().Throw<ArgumentException>().WithMessage("Namn måste vara minst 5 tecken");
    }

    [Fact]
    public void ShouldUpdateProductWithNullAsItemNumber()
    {
        // var product = new Product("AA-9834", "Laptop", 9999);

        Assert.Throws<ArgumentException>(() => fixture.Product.UpdateProduct("", "MAcBook", 12599));
    }

    [Fact]
    public void ShouldUpdateProductWithEmptyStringAsItemNumber()
    {
        //var product = new Product("AA-9834", "Laptop", 9999);

        Assert.Throws<ArgumentException>(() => fixture.Product.UpdateProduct(null, "MacBook", 12599));
    }

    [Fact]
    public void ShouldUpdateItemNumberWithLessThenSevenLetters()
    {
        // var product = new Product("AA-153421", "HPdator", 5999);

        Assert.Throws<ArgumentException>(() => fixture.Product.UpdateProduct("AA-15", "MacBook", 12599));
    }

    [Fact]
    public void ShouldUpdatePriceIfLessThenZero()
    {
        //var product = new Product("AA-123", "MSIDator", 2987);

        Assert.Throws<ArgumentException>(() => fixture.Product.UpdateProduct("AA-111", "MacBook", -10m));
    }

    [Fact]
    public void SaveShouldReturnTrueWhenSuccessful()
     => fixture.Product.SaveProduct().Should().BeTrue();

    // public void SaveShouldReturnTrueWhenSuccessful()
    // {
    //     //Act...
    //     var result = fixture.Product.SaveProduct();

    //     //Assert..
    //     Assert.True(result);
    //     // Assert.Throws<ArgumentException>(() => fixture.Product.SaveProduct());

    // }

    //     sämre lösning men en lösning..
    //    public void Dispose()
    //     {
    //        GC.SuppressFinalize(this);
    //    }
}
