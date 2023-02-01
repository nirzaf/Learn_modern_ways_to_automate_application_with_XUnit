using EATestFramework.Driver;
using EATestFramework.Extensions;
using EATestProject.Model;
using OpenQA.Selenium;
using System;

namespace EATestProject.Pages;
public interface IProductPage
{
    void EnterProductDetails(Product product);

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

}
