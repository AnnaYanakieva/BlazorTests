using BlazorTests.Components.Form;
using BlazorTests.Utils;
using OpenQA.Selenium;
using NUnit.Framework;

namespace BlazorTests.Tests
{
    public class FormTest
    {
        private IWebDriver _driver;
        private Form _form;

        [SetUp]
        public void Setup()
        {
            _driver = WebDriverFactory.CreateDriver(Browser.Chrome);
            _form = new Form(_driver);
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        [Test, Description("Should verify that the form can be submitted successfully when valid data is entered")]
        public void SubmitFormWithValidData()
        {
            _form.GoTo();
            _form.FillForm("John", "Smith", "male", "john.smith@mail1.com", "JavaScript");
            _form.VerifyMessageIsDisplayed("Application form submitted Successfully");
        }

        [Test, Description("Should verify that the form cannot be submitted without a valid email address")]
        public void SubmitFormWithInvalidEmail()
        {
            _form.GoTo();
            _form.FillForm("John", "Smith", "male", "john.smith#mail1.com", "JavaScript");
            _form.VerifyMessageIsDisplayed("Please provide a valid email address.");
        }
    }
}
