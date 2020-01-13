using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class PopUpPage
    {
        public PopUpPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id, 'pop-frame')]")]
        public IWebElement popUpFrame;

        [FindsBy(How = How.ClassName, Using = "call")]
        public IWebElement acceptCookiesButton;
    }
}
