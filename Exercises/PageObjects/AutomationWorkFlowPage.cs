using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class AutomationWorkFlowPage
    {
        public AutomationWorkFlowPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='ibm-duo-button-item']/a[contains(text(), 'PDF')]")]
        public IWebElement downloadPdfButton;
    }
}
