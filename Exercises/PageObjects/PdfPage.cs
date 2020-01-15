using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class PdfPage
    {
        public PdfPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//embed[@type = 'application/pdf']")]
        public IWebElement pdfContent;
    }
}
