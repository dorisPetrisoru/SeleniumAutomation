using Exercises.Helpers;
using Exercises.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace UnitTesting.seleniumTests
{
    [TestClass]
    public class WatsonIoTTest
    {
        static IWebDriver driver;
        static HomePage home;
        static PopUpPage popUp;
        static LoginPage loginPage;
        static IoTPage ioTPage;
        static WebDriverWait wait;

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
            ioTPage = new IoTPage(driver);
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
        public void TC03_NavigateToWatsonIoT()
        {
            home.marketplaceMenu.Click();
            home.iotSubMenu.Click();
            home.watsoIoTSubMenu.Click();
            Assert.IsTrue(wait.Until(d => ioTPage.watchVideoButton.Displayed));
        }

        [TestMethod]
        public void TC04_WatchTheVideo()
        {
            ioTPage.watchVideoButton.Click();
            Assert.IsTrue(wait.Until(d => ioTPage.activeVideoFrame.Displayed));
            var videoSrc = ioTPage.videoIframe.GetAttribute("src");

            IWebDriver driver2 = new ChromeDriver();
            driver2.Navigate().GoToUrl(videoSrc);
            driver2.Quit();
            ioTPage.closeVideoLink.Click();
        }
    }
}
