namespace EATestBDD.Pages;
public interface IProductPage
{
    void EnterProductDetails(Product product);
    void EditProduct(Product product);
    Product GetProductDetails();
}

public class ProductPage : IProductPage
{
    private readonly IWebDriver driver;

    public ProductPage(IDriverFixture driverFixture) => driver = driverFixture.Driver;
    IWebElement txtName => driver.FindElement(By.Id("Name"));
    IWebElement txtDescription => driver.FindElement(By.Id("Description"));
    IWebElement txtPrice => driver.FindElement(By.Id("Price"));
    IWebElement ddlProductType => driver.FindElement(By.Id("ProductType"));
    IWebElement btnCreate => driver.FindElement(By.Id("Create"));
    IWebElement btnSave => driver.FindElement(By.Id("Save"));

    public void EnterProductDetails(Product product)
    {
        txtName.SendKeys(product.Name);
        txtDescription.ClearAndEnterText(product.Description);
        txtPrice.SendKeys(product.Price.ToString());
        ddlProductType.SelectDropDownByText(product.ProductType.ToString());
        btnCreate.Click();
    }


    public Product GetProductDetails()
    {
        return new Product()
        {
            Name = txtName.Text,
            Description = txtDescription.Text,
            Price = int.Parse(txtPrice.Text),
            ProductType = (ProductType)Enum.Parse(typeof(ProductType),
                          ddlProductType.GetAttribute("innerText").ToString())
        };
    }

    public void EditProduct(Product product)
    {
        txtName.ClearAndEnterText(product.Name);
        txtDescription.ClearAndEnterText(product.Description);
        txtPrice.ClearAndEnterText(product.Price.ToString());
        btnSave.Click(); 
    }

}
