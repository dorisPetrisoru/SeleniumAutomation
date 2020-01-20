using Exercises.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTesting.seleniumTests
{
    [TestClass]
    public class WatsonIoTTest : TestBase
    {
        static IoTPage ioTPage;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            InitBase();
            ioTPage = new IoTPage(driver);

            NavigateToIbmSite();
            LoginToMyAccount();
        }

        [TestMethod]
        public void TC01_NavigateToWatsonIoT()
        {
            home.marketplaceMenu.Click();
            home.iotSubMenu.Click();
            home.watsoIoTSubMenu.Click();
            Assert.IsTrue(wait.Until(d => ioTPage.watchVideoButton.Displayed));
        }

        [TestMethod]
        public void TC02_WatchTheVideo()
        {
            ioTPage.watchVideoButton.Click();
            Assert.IsTrue(wait.Until(d => ioTPage.activeVideoFrame.Displayed));
            var videoSrc = ioTPage.videoIframe.GetAttribute("src");

            IWebDriver driver2 = new ChromeDriver();
            driver2.Navigate().GoToUrl(videoSrc);
            driver2.Quit();
            ioTPage.closeVideoLink.Click();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }
    }
}
