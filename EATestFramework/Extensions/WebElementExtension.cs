using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EATestFramework.Extensions;
public static class WebElementExtension
{
    public static void SelectDropDownByText(this IWebElement element, string text)
    {
        var select = new SelectElement(element);
        select.SelectByText(text);
    }

    public static void SelectDropDownByValue(this IWebElement element, string value)
    {
        var select = new SelectElement(element);
        select.SelectByValue(value);
    }

    public static void SelectDropDownByIndex(this IWebElement element, int index)
    {
        var select = new SelectElement(element);
        select.SelectByIndex(index);
    }

    public static void ClearAndEnterText(this IWebElement element, string value)
    {
        element.Clear();
        element.SendKeys(value);
    }

    public static string GetSelectedDropDownValue(this IWebElement element)
    {
        return new SelectElement(element).SelectedOption.Text;
    }
}
