using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class BaseTest
    {
        private static readonly TimeSpan _timeout = TimeSpan.FromSeconds(5);

        public enum Browser
        {
            Chrome,
            Firefox,
        }

        private readonly ChromeOptions _chromeOptions;
        private readonly FirefoxOptions _ffOptions;

        private IWebDriver _driver;
        protected WebDriverWait Wait;

        public BaseTest()
        {
            _chromeOptions = new ChromeOptions { AcceptInsecureCertificates = true };
            _ffOptions = new FirefoxOptions { AcceptInsecureCertificates = true };

            _chromeOptions.AddArgument("no-sandbox");
            _ffOptions.AddArgument("no-sandbox");

            _chromeOptions.AddUserProfilePreference("download.default_directory", Directory.GetCurrentDirectory());
            _chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            _chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            _chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
        }

        public void SetupTest(Browser browser, string url)
        {
            var currentDir = Directory.GetCurrentDirectory();

            _driver = browser switch
            {
                Browser.Chrome => new ChromeDriver(currentDir, _chromeOptions),
                Browser.Firefox => new FirefoxDriver(currentDir, _ffOptions),
                _ => new ChromeDriver(currentDir, _chromeOptions)
            };

            _driver.Manage().Window.Maximize();
            _driver?.Navigate().GoToUrl(url);
            _driver.Manage().Timeouts().ImplicitWait = _timeout;

            Wait = new WebDriverWait(_driver, _timeout);
        }

        [TearDown]
        public void OnExit()
        {
            _driver.Dispose();
        }
    }
}