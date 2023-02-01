using EATestFramework.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;

namespace EATestFramework.Driver;

public class DriverFixture : IDriverFixture, IDisposable
{
    RemoteWebDriver driver;
    private readonly TestSettings testSettings;
    private readonly IBrowserDriver browserDriver;

    //DI is happening
    public DriverFixture(TestSettings testSettings, IBrowserDriver browserDriver)
    {
        this.testSettings = testSettings;
        this.browserDriver = browserDriver;
        //driver = GetWebDriver();
        driver = new RemoteWebDriver(testSettings.SeleniumGridUrl, GetBrowserOptions());
        driver.Navigate().GoToUrl(testSettings.ApplicationUrl);
    }

    public IWebDriver Driver => driver;

    private IWebDriver GetWebDriver()
    {
        return testSettings.BrowserType switch
        {
            BrowserType.Chrome => browserDriver.GetChromeDriver(),
            BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
            _ => browserDriver.GetChromeDriver()
        };
    }

    private dynamic GetBrowserOptions()
    {
        switch (testSettings.BrowserType)
        {
            case BrowserType.Firefox:
                {
                    var firefoxOption = new FirefoxOptions();
                    firefoxOption.AddAdditionalOption("se:recordVideo", true);
                    return firefoxOption;
                }
            case BrowserType.Edge:
                return new EdgeOptions();
            case BrowserType.Safari:
                return new SafariOptions();
            case BrowserType.Chrome:
                {
                    var chromeOption = new ChromeOptions();
                    chromeOption.AddAdditionalOption("se:recordVideo", true);
                    return chromeOption;
                }
            default:
                return new ChromeOptions();
        }
    }


    public void Dispose()
    {
        driver.Quit();
    }
}
