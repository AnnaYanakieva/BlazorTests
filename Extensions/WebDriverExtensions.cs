using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace BlazorTests.Extensions
{
    public static class WebDriverExtensions
    {

        public static IWebElement FindElementExtension(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                return wait.Until(driver => driver.FindElement(by));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IList<IWebElement> FindElementsExtension(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                return wait.Until(driver => driver.FindElements(by));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
    }
}
