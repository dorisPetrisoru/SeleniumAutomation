using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class PowerOfPredictionDownloadPage
    {
        public PowerOfPredictionDownloadPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id = 'FormSection']//form")]
        public IWebElement downloadForm;
    }
}
