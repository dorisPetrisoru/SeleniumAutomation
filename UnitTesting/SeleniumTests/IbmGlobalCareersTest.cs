using Exercises.Helpers;
using Exercises.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Tests.SeleniumTests
{
    [TestClass]
    public class IbmGlobalCareersTest : TestBase
    {
        static EmploymentPage employment;
        static SearchJobPage searchJob;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            InitBase();
            NavigateToIbmSite();
            LoginToMyAccount();
            employment = new EmploymentPage(driver);
            searchJob = new SearchJobPage(driver);
        }

        [TestMethod]
        public void TC01_GoToIbmGlobalCareers()
        {
            WebUtil.ScrollToElement(driver, home.ibmGlobalCareersLink);
            home.ibmGlobalCareersLink.Click();
            Assert.IsTrue(employment.ibmCareersLink.Displayed, "Check that the 'IBM Careers' link is loaded");
        }

        [TestMethod]
        public void TC02_GoToAllJobs()
        {
            employment.searchAllJobsLink.Click();
            Assert.IsTrue(driver.WindowHandles.Count == 2, "Check the second tab for ListJobs has opened");
            driver.SwitchTo().Window(driver.WindowHandles.LastOrDefault());
        }

        [TestMethod]
        public void TC03_SearchJobsFirstInList()
        {
            SelectElement experienceObj = new SelectElement(searchJob.experienceLevelSelect);
            experienceObj.SelectByIndex(1);
            var selectedExperience = experienceObj.SelectedOption.Text;
            
            SelectElement categoryObj = new SelectElement(searchJob.jobCategorySelect);
            categoryObj.SelectByIndex(1);
            var selectedCategory = categoryObj.SelectedOption.Text;
            
            SelectElement countryeObj = new SelectElement(searchJob.jobCountrySelect);
            countryeObj.SelectByIndex(1);
            var selectedCountry = countryeObj.SelectedOption.Text;
            
            searchJob.searchButton.Click();

            VerifyResultTable(selectedExperience, selectedCategory, selectedCountry);
        }

        [TestMethod]
        public void TC04_SearchJobsRo()
        {
            SelectElement experienceObj = new SelectElement(searchJob.experienceLevelSelect);
            experienceObj.SelectByIndex(1);
            var selectedExperience = experienceObj.SelectedOption.Text;

            SelectElement categoryObj = new SelectElement(searchJob.jobCategorySelect);
            categoryObj.SelectByIndex(1);
            var selectedCategory = categoryObj.SelectedOption.Text;

            SelectElement countryeObj = new SelectElement(searchJob.jobCountrySelect);
            countryeObj.SelectByValue("/ListJobs/ByCustom/Job-Country/Keyword-RO/");
            var selectedCountry = countryeObj.SelectedOption.Text;

            searchJob.searchButton.Click();

            VerifyResultTable(selectedExperience, selectedCategory, selectedCountry);
        }

        void VerifyResultTable(string selectedExperience, string selectedCategory, string selectedCountry)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            try
            {
                wait.Until(d => searchJob.searchResultsTable.Displayed);
                Console.WriteLine("Results table was loaded");
            }
            catch (WebDriverException)
            {
                Console.WriteLine("No results were found for selection: "+ Environment.NewLine +
                    $"job experience - {selectedExperience}, "+ Environment.NewLine +
                    $"job category - {selectedCategory}, " + Environment.NewLine +
                    $"country - {selectedCountry}");
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }
    }
}
