using ArtOfTest.Common.UnitTesting;
using BlazorTests.Extensions;
using OpenQA.Selenium;

namespace BlazorTests.Components.Form
{
    public partial class Form
    {
        public void VerifyMessageIsDisplayed(string messageText)
        {
            var isMessageDisplayed = Driver.FindElementExtension(By.XPath($"//*[contains(text(), '{messageText}')]")).Displayed;
            Assert.IsTrue(isMessageDisplayed);
        }
    }
}
