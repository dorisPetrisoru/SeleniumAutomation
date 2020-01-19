using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class IoTPage
    {
        public IoTPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[./text() = 'Watch the video']/ancestor::a[1]")]
        public IWebElement watchVideoButton;

        [FindsByAll]
        [FindsBy(How = How.CssSelector, Using = ".prepped", Priority = 0)]
        [FindsBy(How = How.CssSelector, Using = ".active", Priority = 1)]
        public IWebElement activeVideoFrame;

        [FindsBy(How = How.CssSelector, Using = "div.prepped iframe")]
        public IWebElement videoIframe;

        [FindsBy(How = How.CssSelector, Using = "div.prepped a.ibm-close-link")]
        public IWebElement closeVideoLink;
    }
}
