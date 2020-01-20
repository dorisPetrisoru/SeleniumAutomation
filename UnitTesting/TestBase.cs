using Exercises.Helpers;
using Exercises.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTesting
{
    public class TestBase
    {
        public static IWebDriver driver;
        public static HomePage home;
        public static PopUpPage popUp;
        public static LoginPage loginPage;
        public static WebDriverWait wait;
        public static void InitBase()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            home = new HomePage(driver);
            popUp = new PopUpPage(driver);
            loginPage = new LoginPage(driver);
        }

        public static void NavigateToIbmSite()
        {
            driver.Navigate().GoToUrl("https://www.ibm.com/ro-en");
            wait.Until(d => popUp.popUpFrame.Displayed);
            driver.SwitchTo().Frame(popUp.popUpFrame);
            wait.Until(d => popUp.acceptCookiesButton.Displayed);
            popUp.acceptCookiesButton.Click();
            driver.SwitchTo().DefaultContent();
        }

        public static void LoginToMyAccount()
        {
            home.profileLink.Click();
            home.signInLink.Click();
            loginPage.userNameField.SendKeys(Constants.USERNAME);
            loginPage.continueButton.Click();
            loginPage.passwordField.SendKeys(EncryptDecryptHelper.Decrypt(Constants.ENCODED_PASS));
            loginPage.loginButton.Click();
        }
    }
}
