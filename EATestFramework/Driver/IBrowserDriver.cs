using OpenQA.Selenium;

namespace EATestFramework.Driver;
public interface IBrowserDriver
{
    IWebDriver GetChromeDriver();
    IWebDriver GetFirefoxDriver();
}
