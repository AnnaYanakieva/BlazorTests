using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTests.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClickClearAndSendKeys(this IWebElement webElement, string textToSend)
        {
            webElement.Click();
            webElement.Clear();
            webElement.SendKeys(textToSend);
        }

        public static void ClickExtension(this IWebElement webElement, IJavaScriptExecutor js)
        {
            try
            {
                webElement.Click();
            }

            catch (Exception ex)
            {
                if (ex is ElementClickInterceptedException || ex is ElementNotInteractableException)
                {
                    js.ExecuteScript("arguments[0].click();", webElement);
                    return;
                }
                throw;
            }
        }

    }
}
