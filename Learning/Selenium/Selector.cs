using OpenQA.Selenium;

namespace Selenium
{
    internal static class Selector
    {
        public static By AnyCheckbox = By.XPath("//input[@type='checkbox']");

        public static By ByText(string text)
        {
            return By.XPath($"//*[text()='{text}']");
        }

        public static By ByAnyAttribute(string attributeName, string attributeValue)
        {
            return By.XPath($"//*[@{attributeName}='{attributeValue}']");
        }

        public static By ByClassContains(string attributeValue)
        {
            return By.XPath($"//*[contains(@class, {attributeValue})]");
        }

        public static void ClearInputAndSendKeys(this IWebElement element, string value)
        {
            if (element.Enabled)
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(value);
            }
        }


    }
}