using AutoFixture.Xunit2;
using EATestProject.Model;
using EATestProject.Pages;
using FluentAssertions;
using Xunit;

namespace EATestProject;
public class UnitTest1
{
    private readonly IHomePage homePage;
    private readonly IProductPage productPage;
    public UnitTest1(IHomePage homePage, IProductPage createProductPage)
    {
        this.homePage = homePage;
        this.productPage = createProductPage;
    }

    [Theory, AutoData]
    public void Test1(Product product)
    {
        //Separation of concern
        homePage.CreateProduct();

        productPage.EnterProductDetails(product);
    }

    [Theory, AutoData]
    public void Test2(Product product)
    {
        //Separation of concern
        homePage.CreateProduct();

        productPage.EnterProductDetails(product);
    }

    [Theory, AutoData]
    public void Test3(Product product)
    {
        //Separation of concern
        homePage.CreateProduct();

        productPage.EnterProductDetails(product);

        homePage.PerformClickOnSpecialValue(product.Name, "Details");

        //assertion
        var actualProduct = productPage.GetProductDetails();

        actualProduct
            .Should()
            .BeEquivalentTo(product,option => option.Excluding(x => x.Id));

    }

    [Theory, AutoData]
    public void Test4(Product product)
    {
        product.ProductType = ProductType.PERIPHARALS;
        //Separation of concern
        homePage.CreateProduct();

        productPage.EnterProductDetails(product);

    }
}
