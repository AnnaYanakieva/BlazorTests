using BlazorTests.Extensions;
using OpenQA.Selenium;

namespace BlazorTests.Components.Form
{
    public partial class Form
    {
        private IWebElement FirstName => Driver.FindElementExtension(By.XPath("//input[@id='FNameTb']"));
        private IWebElement LastName => Driver.FindElementExtension(By.XPath("//input[@id='LNameTb']"));
        private IWebElement GenderDropdown => Driver.FindElementExtension(By.XPath("//span[text()='Select gender']"));
        private IWebElement Email => Driver.FindElementExtension(By.XPath("//input[@id='EmailTb']"));
        private IWebElement LanguagesDropdown => Driver.FindElementExtension(By.XPath("//span[text()='Preferred team']"));
        private IWebElement SubmitButton => Driver.FindElementExtension(By.XPath("//button[text()='Submit']"));
    }
}
