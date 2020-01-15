using Exercises.Helpers;
using Exercises.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTesting.seleniumTests
{
    [TestClass]
    public class WorkflowAutomationTest
    {
        static IWebDriver driver;
        static HomePage home;
        static PopUpPage popUp;
        static LoginPage loginPage;
        static WebDriverWait wait;
        static AutomationWorkFlowPage automationWorkflow;
        static PdfPage pdfPage;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            home = new HomePage(driver);
            popUp = new PopUpPage(driver);
            loginPage = new LoginPage(driver);
            automationWorkflow = new AutomationWorkFlowPage(driver);
            pdfPage = new PdfPage(driver);
        }

        [TestMethod]
        public void TC01_NavigateToIbmSite()
        {
            driver.Navigate().GoToUrl("https://www.ibm.com/ro-en");
            wait.Until(d => popUp.popUpFrame.Displayed);
            driver.SwitchTo().Frame(popUp.popUpFrame);
            wait.Until(d => popUp.acceptCookiesButton.Displayed);
            popUp.acceptCookiesButton.Click();
            driver.SwitchTo().DefaultContent();
        }

        [TestMethod]
        public void TC02_LoginToMyAccount()
        {
            home.profileLink.Click();
            home.signInLink.Click();
            loginPage.userNameField.SendKeys(Constants.USERNAME);
            loginPage.continueButton.Click();
            loginPage.passwordField.SendKeys(EncryptDecryptHelper.Decrypt(Constants.ENCODED_PASS));
            loginPage.loginButton.Click();
            Assert.IsTrue(home.compareActualMenuList(driver, Constants.EXPECTED_LOGGED_IN_MENUS));
        }

        [TestMethod]
        public void TC03_NavigateToWorkflowAutomation()
        {
            home.marketplaceMenu.Click();
            home.automationSubMenu.Click();
            home.workflowAutomationSubMenu.Click();
            Assert.AreEqual("Automation - Workflow - Czech Republic | IBM", driver.Title);
        }

        [TestMethod]
        public void TC04_DownloadPdfFromSlide()
        {
            string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                + "var elementTop = arguments[0].getBoundingClientRect().top;"
                + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, automationWorkflow.downloadPdfButton);
            automationWorkflow.downloadPdfButton.Click();
            Assert.IsTrue(pdfPage.pdfContent.Displayed);
        }
    }
}
