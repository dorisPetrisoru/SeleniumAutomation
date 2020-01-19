using OpenQA.Selenium;

namespace Exercises.Helpers
{
    public class WebUtil
    {
        public static void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                    + "var elementTop = arguments[0].getBoundingClientRect().top;"
                    + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            ((IJavaScriptExecutor) driver).ExecuteScript(scrollElementIntoMiddle, element);
        }
    }
}
