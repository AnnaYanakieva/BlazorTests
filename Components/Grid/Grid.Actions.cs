using BlazorTests.Components.Abstract;
using BlazorTests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BlazorTests.Components.Grid
{
    public partial class Grid : BasePage
    {
        public override string Url => "https://localhost:5001/grid";
        public Grid(IWebDriver driver) : base(driver)
        {
        }
        public void AddForecast(string temp, string summary)
        {
            AddForecastButton.ClickExtension(Js);
            TempInput.ClickClearAndSendKeys(temp);
            SummaryInput.ClickClearAndSendKeys(summary);
            UpdateButton.ClickExtension(Js);
        }

        public void DeleteForecast()
        {
            FirstRowDeleteButton.ClickExtension(Js);
        }

        public void WaitUntilAttributeContainsValue(By locator, String attribute, String value, int secondsToWait = 5)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait))
               .Until(d => d.FindElement(locator).GetCssValue(attribute) == value);
        }

        public void FilterBy(string filterName, string firstDropdownOption, string firstFilterValue, string secondDropdownOption = "", string thirdDropdownOption = "", string secondFilterValue = "")
        {
            Driver.FindElementExtension(By.XPath($"//span[text()='{filterName}']//following-sibling::div")).ClickExtension(Js);

            this.SelectOptionFromDropdown(FirstDropdownList, firstDropdownOption);
            FilterFirstInputField.ClickClearAndSendKeys(firstFilterValue);
            this.SelectOptionFromDropdown(SecondDropdownList, secondDropdownOption);
            this.SelectOptionFromDropdown(ThirdDropdownList, thirdDropdownOption);

            FilteSecondInputField.ClickClearAndSendKeys(secondFilterValue);
            FilterButton.ClickExtension(Js);
        }
    }
}

