using Exercises.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting.seleniumTests
{
    [TestClass]
    public class LoginTest
    {

        [TestMethod]
        public void TC01_NavigateToIbmSite()
        {
            #region week 9, sesion 1
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.ibm.com/ro-en");
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@id, 'pop-frame')]")));
            #endregion

            #region hommework session 1
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(d => d.FindElement(By.ClassName("call")).Displayed);    
            driver.FindElement(By.ClassName("call")).Click();

            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.ClassName("ibm-profile-link")).Click();
            driver.FindElement(By.XPath("//li[@data-linktype='signin']/a")).Click();
            driver.FindElement(By.Id("username")).SendKeys(Constants.USERNAME);
            driver.FindElement(By.Id("continue-button")).Click();
            driver.FindElement(By.Id("password")).SendKeys(EncryptDecryptHelper.Decrypt(Constants.ENCODED_PASS));
            driver.FindElement(By.Id("signinbutton")).Click();
            #endregion

            #region week 9, session 2
            wait.Until(d => d.FindElement(By.ClassName("ibm-profile-link")).Displayed);
            
            driver.FindElement(By.ClassName("ibm-profile-link")).Click();
            wait.Until(d => d.FindElement(By.XPath("//ul[@id = 'ibm-signin-minimenu-container']/li/a")).Displayed);
            
            var subMenusLinks = driver.FindElements(By.XPath("//ul[@id = 'ibm-signin-minimenu-container']/li/a"));
            List<string> menus = new List<string>();

            foreach(IWebElement menuLink in subMenusLinks)
            {
                menus.Add(menuLink.Text);
            }

            List<string> expectedMenus = new List<string>
            {
                "My IBM", "Profile", "Billing" ,"Sign out"
            };

            Assert.IsTrue(expectedMenus.SequenceEqual(menus));
            #endregion

            #region homework session 2

            driver.FindElement(By.XPath("//li[@data-linktype = 'signout']/a")).Click();
            wait.Until(d => d.FindElement(By.ClassName("ibm-profile-link")));
            
            driver.FindElement(By.ClassName("ibm-profile-link")).Click();
            wait.Until(d => d.FindElement(By.XPath("//ul[@id = 'ibm-signin-minimenu-container']/li/a")).Displayed);
            
            var subLogoutLinks = driver.FindElements(By.XPath("//ul[@id = 'ibm-signin-minimenu-container']/li/a"));
            
            List<string> logoutMenus = new List<string>();

            foreach (IWebElement logoutMenuLink in subLogoutLinks)
            {
                logoutMenus.Add(logoutMenuLink.Text);
            }

            List<string> expectedLogoutMenus = new List<string>
            {
                "My IBM", "Log in"
            };

            Assert.IsTrue(expectedLogoutMenus.SequenceEqual(logoutMenus));
            Assert.IsTrue(driver.FindElement(By.CssSelector(".ibm-btn-pri.ibm-btn-white.sign-in-btn.ibm-ls-button-trigger")).Displayed);
            #endregion
        }
    }
}
