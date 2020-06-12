using OpenQA.Selenium;
using System.Collections.Generic;
using BlazorTests.Extensions;

namespace BlazorTests.Components.Grid
{
    public partial class Grid
    {
        private IWebElement AddForecastButton => Driver.FindElementExtension(By.XPath("//button[text()='Add Forecast']"));
        private IWebElement TempInput => Driver.FindElementExtension(By.XPath("//td[@data-col-index='2']//input"));
        private IWebElement SummaryInput => Driver.FindElementExtension(By.XPath("//td[@data-col-index='4']//input"));
        private IWebElement UpdateButton => Driver.FindElementExtension(By.XPath("//button[text()='Update' and not(contains(@class, 'k-hidden'))]"));
        private IWebElement FirstRowId => Driver.FindElementExtension(By.XPath("(//tr//td)[1]"));
        private IWebElement FirstRowDate => Driver.FindElementExtension(By.XPath("(//tr//td)[2]"));
        private IWebElement FirstRowTemp => Driver.FindElementExtension(By.XPath("(//tr//td)[3]"));
        private IWebElement FirstRowSummary => Driver.FindElementExtension(By.XPath("(//tr//td)[5]"));
        private IWebElement FirstRowDeleteButton
             => Driver.FindElementExtension(By.XPath("(//button[text()='Delete'])[1]"));      
        private IList<IWebElement> IdsListFirstPage => Driver.FindElementsExtension(By.XPath("//tr//td[1]"));
        private IWebElement FirstRowEditButton
             => Driver.FindElementExtension(By.XPath("(//button[text()='Edit'])[1]"));
        private IWebElement FilterFirstInputField => Driver.FindElementExtension(By.XPath("(//input)[1]"));
        private IWebElement FilteSecondInputField => Driver.FindElementExtension(By.XPath("(//input)[2]"));
        private IWebElement FilterButton => Driver.FindElementExtension(By.XPath("//button[text()='Filter']"));
        private IList<IWebElement> TableRows => Driver.FindElementsExtension(By.XPath("//tr[@class='k-master-row   ']"));
        private IWebElement FirstDropdownList => Driver.FindElementExtension(By.XPath("(//span[@class='k-input'])[1]"));       
        private IWebElement SecondDropdownList => Driver.FindElementExtension(By.XPath("(//span[@class='k-input'])[2]"));
        private IWebElement ThirdDropdownList => Driver.FindElementExtension(By.XPath("(//span[@class='k-input'])[3]"));
        private IList<IWebElement> SummaryColumns => Driver.FindElementsExtension(By.XPath("//td[5]"));
        private IWebElement NewForecastId => Driver.FindElementExtension(By.XPath("//td[text()='151']"));
    }
}
