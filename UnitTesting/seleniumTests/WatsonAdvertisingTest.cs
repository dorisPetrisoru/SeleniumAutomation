using Exercises.Helpers;
using Exercises.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTesting.seleniumTests
{
    [TestClass]
    public class WatsonAdvertisingTest : TestBase
    {
        static WatsonAdvertisingPage watsonAdvertising;
        static IbmAdvertisingAcceleratorPage ibmAdvertisingAccelerator;
        static PowerOfPredictionPage powerOfPrediction;
        static PowerOfPredictionDownloadPage powerOfPredictionDownload;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            InitBase();
            watsonAdvertising = new WatsonAdvertisingPage(driver);
            ibmAdvertisingAccelerator = new IbmAdvertisingAcceleratorPage(driver);
            powerOfPrediction = new PowerOfPredictionPage(driver);
            powerOfPredictionDownload = new PowerOfPredictionDownloadPage(driver);

            NavigateToIbmSite();
            LoginToMyAccount();
        }

        [TestMethod]
        public void TC01_NavigateToWatsonAdvertising()
        {
            home.marketplaceMenu.Click();
            home.watsonSubMenu.Click();
            home.watsoAdvertisingnSubMenu.Click();
            Assert.AreEqual("IBM Watson Advertising | IBM", driver.Title);
        }

        [TestMethod]
        public void TC02_ClickOnIntroducingAccelerator()
        {
            WebUtil.ScrollToElement(driver, watsonAdvertising.introducingAcceleratorSlideButton);
            watsonAdvertising.introducingAcceleratorSlideButton.Click();
            wait.Until(d => d.WindowHandles.Count > 1);
            driver.SwitchTo().Window(driver.WindowHandles.LastOrDefault());
            Assert.AreEqual("IBM Advertising Accelerator with Watson | IBM", driver.Title);
        }

        [TestMethod]
        public void TC03_DownloadEBook()
        {
            ibmAdvertisingAccelerator.downoadEBookButton.Click();
            Assert.AreEqual("https://www.ibm.com/watson-advertising/thought-leadership/the-power-of-prediction", driver.Url);
            WebUtil.ScrollToElement(driver, powerOfPrediction.downloadButton);
            powerOfPrediction.downloadButton.Click();
            wait.Until(d => d.WindowHandles.Count > 2);
            driver.SwitchTo().Window(driver.WindowHandles.LastOrDefault());
            Assert.IsTrue(wait.Until(d => powerOfPredictionDownload.downloadForm.Displayed));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }
    }
}
