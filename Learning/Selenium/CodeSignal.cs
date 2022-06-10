using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium
{
    public class CodeSignal : BaseTest
    {
        [Test]
        public async Task LoginTest()
        {
            SetupTest(Browser.Chrome, "https://www.instagram.com/");

            Login();

            Wait.Until(_ => _.FindElement(By.XPath("//*[contains(@class, 'arcade')]"))).Click();
            Wait.Until(driver => driver.FindElement(
                Selector.ByAnyAttribute("href", "/arcade/intro"))).Click();

            var pinAvatar = Wait.Until(_ => _.FindElement(By.XPath("//div[contains(@class, 'pin-avatar')]")));
            pinAvatar.Click();


           // Wait.Until(_ => _.f)


            await TimeHolder.LongDelay();
        }

        private  void Login()
        {
            Wait.Until(_ => _.FindElement(By.Name("username"))).SendKeys("t.rustamov@innovadis.com");
            Wait.Until(_ => _.FindElement(By.Name("password"))).SendKeys("qwerty123!");
            Wait.Until(_ => _.FindElement(Selector.ByText("Log In"))).Click();
            Wait.Until(_ => _.)
        }
    }
}