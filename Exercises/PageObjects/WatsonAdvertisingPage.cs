
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class WatsonAdvertisingPage
    {
        public WatsonAdvertisingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[./text() = 'Introducing Accelerator']/ancestor::a[1]")]
        public IWebElement introducingAcceleratorSlideButton;
    }
}
