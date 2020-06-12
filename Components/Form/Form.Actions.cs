using BlazorTests.Components.Abstract;
using BlazorTests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BlazorTests.Components.Form
{
    public partial class Form : BasePage
    {
      
        public override string Url => "https://localhost:5001/form";

        public Form(IWebDriver driver): base(driver)
        {
        }

        public void FillForm(string firstName, string lastName, string gender, string email, string languages)
        {
            WaitUntilElementIsDisplayed(SubmitButton);
            FirstName.ClickClearAndSendKeys(firstName);
            LastName.ClickClearAndSendKeys(lastName);
            SelectOptionFromDropdown(GenderDropdown, gender);
            Email.ClickClearAndSendKeys(email);
            Actions.MoveToElement(LanguagesDropdown);
            Actions.Perform();
            SelectOptionFromDropdown(LanguagesDropdown, languages);
            SubmitButton.ClickExtension(Js);
        }
    }
}
