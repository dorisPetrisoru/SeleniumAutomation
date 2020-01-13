using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
