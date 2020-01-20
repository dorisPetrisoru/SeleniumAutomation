using Exercises.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.seleniumTests
{
    [TestClass]
    public class LoginTest : TestBase
    { 

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            InitBase();
        }

        [TestMethod]
        public void TC01_NavigateToIbmSite()
        {
            NavigateToIbmSite();
        }

        [TestMethod]
        public void TC02_LoginToMyAccount()
        {
            LoginToMyAccount();
            Assert.IsTrue(home.compareActualMenuList(driver, Constants.EXPECTED_LOGGED_IN_MENUS));
        }

        [TestMethod]
        public void TC03_LogOutMyAccount()
        {
            home.signOutLink.Click();
            Assert.IsTrue(home.compareActualMenuList(driver, Constants.EXPECTED_LOGGED_OUT_MENUS));
            Assert.IsTrue(home.logInToMyIbmButton.Displayed);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }
    }
}
