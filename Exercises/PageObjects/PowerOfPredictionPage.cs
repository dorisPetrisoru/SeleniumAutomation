using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class PowerOfPredictionPage
    {
        public PowerOfPredictionPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Download Here")]
        public IWebElement downloadButton;
    }
}
