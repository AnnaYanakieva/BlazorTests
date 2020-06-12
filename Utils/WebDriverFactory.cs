using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace BlazorTests.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(Browser browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
            return driver;
        }
    }
}
