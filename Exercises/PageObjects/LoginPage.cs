using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Exercises.PageObjects
{
    public class LoginPage
    {
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement userNameField;

        [FindsBy(How = How.Id, Using = "continue-button")]
        public IWebElement continueButton;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordField;

        [FindsBy(How = How.Id, Using = "signinbutton")]
        public IWebElement loginButton;
    }
}
