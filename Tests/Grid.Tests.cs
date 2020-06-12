using BlazorTests.Components.Grid;
using BlazorTests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BlazorTests
{
    public class GridTests
    {
        private IWebDriver _driver;
        private Grid _grid;
       
        [SetUp]
        public void Setup()
        {
            _driver = WebDriverFactory.CreateDriver(Browser.Chrome);
            _grid = new Grid(_driver);
        }

        [Test, Description("Should verify that a new forecast can be added")]
        public void AddNewForecastTest()
        {
            _grid.GoTo();
            _grid.AddForecast("3", "Cold");
            _grid.VerifyNewForecastIsAdded("151", "3", "Cold");
        }

        [Test, Description("Should verify that a forecast can be deleted")]
        public void DeleteForecastTest()
        {
            _grid.GoTo();
            _grid.DeleteForecast();
            _grid.VerifyThatForecastIsDeleted();
        }
 
        [Test, Description("Should verify that filter by Id returns the correct results")]
        public void FilterByIdTest()
        {
            _grid.GoTo();
            _grid.FilterBy("Id", "Is equal to", "1"); 
            _grid.VerifyForecastIsFilteredById(1, "1");
        }

        [Test, Description("Should verify that filter by Summary returns the correct results")]
        public void FilterBySummaryTest()
        {
            _grid.GoTo();
            _grid.FilterBy("Summary", "Starts with", "Ho", "Or", "Contains", "Warm");
            _grid.VerifyForecastsAreFilteredBySummary("Ho", "Warm");           
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}