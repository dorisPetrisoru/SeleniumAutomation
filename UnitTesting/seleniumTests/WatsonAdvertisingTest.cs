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
    public class WatsonAdvertisingTest
    {
        static IWebDriver driver;
        static HomePage home;
        static PopUpPage popUp;
        static LoginPage loginPage;
        static WatsonAdvertisingPage watsonAdvertising;
        static IbmAdvertisingAcceleratorPage ibmAdvertisingAccelerator;
        static PowerOfPredictionPage powerOfPrediction;
        static PowerOfPredictionDownloadPage powerOfPredictionDownload;
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
            watsonAdvertising = new WatsonAdvertisingPage(driver);
            ibmAdvertisingAccelerator = new IbmAdvertisingAcceleratorPage(driver);
            powerOfPrediction = new PowerOfPredictionPage(driver);
            powerOfPredictionDownload = new PowerOfPredictionDownloadPage(driver);
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
        public void TC03_NavigateToWatsonAdvertising()
        {
            home.marketplaceMenu.Click();
            home.watsonSubMenu.Click();
            home.watsoAdvertisingnSubMenu.Click();
            Assert.AreEqual("IBM Watson Advertising | IBM", driver.Title);
        }

        [TestMethod]
        public void TC04_ClickOnIntroducingAccelerator()
        {
            WebUtil.ScrollToElement(driver, watsonAdvertising.introducingAcceleratorSlideButton);
            watsonAdvertising.introducingAcceleratorSlideButton.Click();
            wait.Until(d => d.WindowHandles.Count > 1);
            driver.SwitchTo().Window(driver.WindowHandles.LastOrDefault());
            Assert.AreEqual("IBM Advertising Accelerator with Watson | IBM", driver.Title);
        }

        [TestMethod]
        public void TC05_DownloadEBook()
        {
            ibmAdvertisingAccelerator.downoadEBookButton.Click();
            Assert.AreEqual("https://www.ibm.com/watson-advertising/thought-leadership/the-power-of-prediction", driver.Url);
            WebUtil.ScrollToElement(driver, powerOfPrediction.downloadButton);
            powerOfPrediction.downloadButton.Click();
            wait.Until(d => d.WindowHandles.Count > 2);
            driver.SwitchTo().Window(driver.WindowHandles.LastOrDefault());
            Assert.IsTrue(wait.Until(d => powerOfPredictionDownload.downloadForm.Displayed));
        }
    }
}
