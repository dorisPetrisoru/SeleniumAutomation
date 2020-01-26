using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class EmploymentPage
    {
        public EmploymentPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "IBM Careers")]
        public IWebElement ibmCareersLink;

        [FindsBy(How = How.LinkText, Using = "Search all jobs")]
        public IWebElement searchAllJobsLink;
    }
}
