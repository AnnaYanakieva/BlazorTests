using BlazorTests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace BlazorTests.Components.Abstract
{
    public abstract class BasePage
    {
        protected WebDriverWait wait;
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Js = (IJavaScriptExecutor)driver;
            Actions = new Actions(driver);
        }

        public void GoTo() => Driver.Navigate().GoToUrl(Url);

        public void SelectOptionFromDropdown(IWebElement dropdown, string dropdownOption)
        {
            if (dropdownOption != "")
            {
                dropdown.ClickExtension(Js);
                Driver.FindElementExtension(By.XPath($"//li[text()='{dropdownOption}']")).ClickExtension(Js);
            }
            else
            {
                return;
            }
        }

        public void WaitUntilElementIsDisplayed(IWebElement webelement, int secondsToWait = 5)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait))
               .Until(d => webelement.Displayed == true);
        }

        public abstract string Url { get; }
        protected IWebDriver Driver { get; }
        protected IJavaScriptExecutor Js { get; }
        protected Actions Actions { get; }
    }
}
