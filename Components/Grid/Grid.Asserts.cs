
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace BlazorTests.Components.Grid
{
    public partial class Grid
    {
        public void VerifyNewForecastIsAdded(string expectedId, string expectedTemp, string expectedSummary)
        {
            string expectedDate = DateTime.Now.ToString("dddd, dd MMM yyyy");

            while (true)
            {
                try
                {
                    WaitUntilElementIsDisplayed(NewForecastId);

                    string firstRowId = FirstRowId.Text;
                    string firstRowDate = FirstRowDate.Text;
                    string firtsRowTemp = FirstRowTemp.Text;
                    string firstRowSummary = FirstRowSummary.Text;

                    Assert.AreEqual(expectedId, firstRowId);
                    Assert.AreEqual(firstRowDate, expectedDate);
                    Assert.AreEqual(expectedTemp, firtsRowTemp);
                    Assert.AreEqual(expectedSummary, firstRowSummary);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    continue;
                }
            }
        }

        public void VerifyThatForecastIsDeleted()
        {
            bool isForecastDeleted;
            while (true)
            {
                try
                {
                    var idsList = IdsListFirstPage;
                    isForecastDeleted = idsList.Any(item => item.Text != "1");
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    continue;
                }
            }
            Assert.IsTrue(isForecastDeleted);
        }
        public void VerifyForecastIsFilteredById(int expectedNumberOfRows, string expectedRowId)
        {
            WaitUntilAttributeContainsValue(By.XPath("//span[text()='Id']//following-sibling::div"), "background-color", "rgba(0, 123, 255, 1)");

            var actualTableRows = TableRows.Count;
            var actualRowId = FirstRowId.Text;

            Assert.AreEqual(expectedNumberOfRows, actualTableRows);
            Assert.AreEqual(expectedRowId, actualRowId);
        }

        public void VerifyForecastsAreFilteredBySummary(string firstFilterValue, string secondFilterValue)
        {
            WaitUntilAttributeContainsValue(By.XPath("//span[text()='Summary']//following-sibling::div"), "background-color", "rgba(0, 123, 255, 1)");

            bool isFilterAppliedCorrectly = false;
            while (true)
            {
                try
                {
                    foreach (var summary in SummaryColumns)
                    {

                        if (summary.Text.StartsWith(firstFilterValue) || summary.Text.Contains(secondFilterValue))
                        {
                            isFilterAppliedCorrectly = true;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    continue;
                }
            }
            Assert.IsTrue(isFilterAppliedCorrectly);
        }
    }
}
