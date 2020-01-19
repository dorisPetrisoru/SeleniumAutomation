using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class IbmAdvertisingAcceleratorPage
    {
        public IbmAdvertisingAcceleratorPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[./text() = 'Download the eBook']/ancestor::a[1]")]
        public IWebElement downoadEBookButton;
    }
}
