using ProductAPI.Repository;

namespace EATestBDD.StepDefinitions;

[Binding]
public sealed class ProductSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IHomePage homePage;
    private readonly IProductPage productPage;
    private readonly IProductRepository productRepository;

    public ProductSteps(ScenarioContext scenarioContext, IHomePage homePage, IProductPage productPage, IProductRepository productRepository)
    {
        this.scenarioContext = scenarioContext;
        this.homePage = homePage;
        this.productPage = productPage;
        this.productRepository = productRepository;
    }

    [Given(@"I click the Product menu")]
    public void GivenIClickTheProductMenu()
    {
        //productRepository.DeleteProduct(3);
        homePage.ClickProduct();
    }

    [Given(@"I click the ""([^""]*)"" link")]
    public void GivenIClickTheLink(string create)
    {
        homePage.ClickCreate();
    }

    [Given(@"I create product with following details")]
    public void GivenICreateProductWithFollowingDetails(Table table)
    {
        //Automatically Map all the Specflow Tables row data to the actual Product Type 
        var product = table.CreateInstance<Product>();

        productPage.EnterProductDetails(product);

        //Store the product details
        scenarioContext.Set<Product>(product);
    }

    [When(@"I click the (.*) link of the newly created product")]
    public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct(string operation)
    {
        var product = scenarioContext.Get<Product>();
        homePage.PerformClickOnSpecialValue(product.Name, operation);
    }

    [Then(@"I see all the product details are created as expected")]
    public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
        var product = scenarioContext.Get<Product>();
        //assertion
        var actualProduct = productPage.GetProductDetails();

        actualProduct
            .Should()
            .BeEquivalentTo(product, option => option.Excluding(x => x.Id));

    }

    [When(@"I Edit the product details with following")]
    public void WhenIEditTheProductDetailsWithFollowing(Table table)
    {
        var product = table.CreateInstance<Product>();

        productPage.EditProduct(product);

        //Store the product details
        scenarioContext.Set<Product>(product);
    }


}
