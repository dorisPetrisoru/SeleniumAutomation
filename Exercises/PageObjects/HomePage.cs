using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.PageObjects
{
    public class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "ibm-profile-link")]
        public IWebElement profileLink;

        [FindsBy(How = How.XPath, Using = "//li[@data-linktype='signin']/a")]
        public IWebElement signInLink;

        [FindsBy(How = How.XPath, Using = "//ul[@id = 'ibm-signin-minimenu-container']/li/a")]
        public IList<IWebElement> menuLinks;

        [FindsBy(How = How.XPath, Using = "//li[@data-linktype = 'signout']/a")]
        public IWebElement signOutLink;

        [FindsBy(How = How.CssSelector, Using = ".ibm-btn-pri.ibm-btn-white.sign-in-btn.ibm-ls-button-trigger")]
        public IWebElement logInToMyIbmButton;

        [FindsBy(How = How.LinkText, Using = "Marketplace")]
        public IWebElement marketplaceMenu;

        [FindsBy(How = How.LinkText, Using = "Automation (CZ)")]
        public IWebElement automationSubMenu;

        [FindsBy(How = How.LinkText, Using = "Workflow Automation (CZ)")]
        public IWebElement workflowAutomationSubMenu;

        [FindsBy(How = How.LinkText, Using = "Watson")]
        public IWebElement watsonSubMenu;

        [FindsBy(How = How.LinkText, Using = "Watson Advertising")]
        public IWebElement watsoAdvertisingnSubMenu;

        [FindsBy(How = How.LinkText, Using = "Internet of Things (CZ)")]
        public IWebElement iotSubMenu;

        [FindsBy(How = How.LinkText, Using = "Watson Internet of Things (CZ)")]
        public IWebElement watsoIoTSubMenu;

        public bool compareActualMenuList(IWebDriver driver, List<string> expectedMenus)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(d => profileLink.Displayed);

            profileLink.Click();
            wait.Until(d => menuLinks.All(element => element.Displayed));

            List<string> menus = new List<string>();

            foreach (IWebElement menuLink in menuLinks)
            {
                menus.Add(menuLink.Text);
            }

            return expectedMenus.SequenceEqual(menus);
        }
    }
}
