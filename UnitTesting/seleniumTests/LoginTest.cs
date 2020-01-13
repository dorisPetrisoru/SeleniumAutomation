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
    public class LoginTest
    {
        static IWebDriver driver;
        static HomePage home;
        static PopUpPage popUp;
        static LoginPage loginPage;
        static WebDriverWait wait;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            home = new HomePage(driver);
            popUp = new PopUpPage(driver);
            loginPage = new LoginPage(driver);
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
        public void TC03_LogOutMyAccount()
        {
            home.signOutLink.Click();
            Assert.IsTrue(home.compareActualMenuList(driver, Constants.EXPECTED_LOGGED_OUT_MENUS));
            Assert.IsTrue(home.logInToMyIbmButton.Displayed);
        }
    }
}
