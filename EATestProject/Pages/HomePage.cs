using EATestFramework.Driver;
using EATestFramework.Extensions;
using OpenQA.Selenium;

namespace EATestProject.Pages;
public interface IHomePage
{
    void CreateProduct();

    void PerformClickOnSpecialValue(string name, string operation);
}

public class HomePage : IHomePage
{
    private readonly IWebDriver driver;

    public HomePage(IDriverFixture driverFixture) => driver = driverFixture.Driver;

    IWebElement lnkProduct => driver.FindElement(By.LinkText("Product"));
    IWebElement lnkCreate => driver.FindElement(By.LinkText("Create"));

    IWebElement tblList => driver.FindElement(By.CssSelector(".table"));

    public void CreateProduct()
    {
        lnkProduct.Click();
        lnkCreate.Click();
    }

    public void PerformClickOnSpecialValue(string name, string operation)
    {
        tblList.PerformActionOnCell("5", "Name", name, operation);
    }
}
