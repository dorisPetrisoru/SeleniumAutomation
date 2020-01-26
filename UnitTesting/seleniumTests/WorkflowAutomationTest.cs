using Exercises.Helpers;
using Exercises.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.SeleniumTests
{
    [TestClass]
    public class WorkflowAutomationTest : TestBase
    {
        static AutomationWorkFlowPage automationWorkflow;
        static PdfPage pdfPage;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            InitBase();
            automationWorkflow = new AutomationWorkFlowPage(driver);
            pdfPage = new PdfPage(driver);

            NavigateToIbmSite();
            LoginToMyAccount();
        }

        [TestMethod]
        public void TC01_NavigateToWorkflowAutomation()
        {
            home.marketplaceMenu.Click();
            home.automationSubMenu.Click();
            home.workflowAutomationSubMenu.Click();
            Assert.AreEqual("Automation - Workflow - Czech Republic | IBM", driver.Title);
        }

        [TestMethod]
        public void TC02_DownloadPdfFromSlide()
        {
            WebUtil.ScrollToElement(driver, automationWorkflow.downloadPdfButton);
            automationWorkflow.downloadPdfButton.Click();
            Assert.IsTrue(pdfPage.pdfContent.Displayed);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }
    }
}
