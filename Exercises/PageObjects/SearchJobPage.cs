using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class SearchJobPage
    {
        public SearchJobPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Experience-Level")]
        public IWebElement experienceLevelSelect;

        [FindsBy(How = How.Id, Using = "Job-Category")]
        public IWebElement jobCategorySelect;

        [FindsBy(How = How.Id, Using = "Job-Country")]
        public IWebElement jobCountrySelect;

        [FindsBy(How = How.Id, Using = "btnSearch")]
        public IWebElement searchButton;

        [FindsBy(How = How.ClassName, Using = "JobListTable")]
        public IWebElement searchResultsTable;
    }
}
