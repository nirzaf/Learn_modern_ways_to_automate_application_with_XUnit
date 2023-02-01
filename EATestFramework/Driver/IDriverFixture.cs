using OpenQA.Selenium;

namespace EATestFramework.Driver;
public interface IDriverFixture
{
    IWebDriver Driver { get; }
}
