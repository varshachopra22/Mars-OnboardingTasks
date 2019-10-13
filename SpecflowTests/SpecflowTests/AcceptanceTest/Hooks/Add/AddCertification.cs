using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.Hooks
{
    [Binding]
    public class CertificationSteps
    {
        [Given(@"I clicked on the Certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //Wait
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            // Click on Profile tab
            //Driver.driver.FindElement(By.XPath("//*[@class='item' and text()='Profile")).Click();
            
            // Click on Education tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='fourth']")).Click();
        }

        [When(@"I add a new certification")]
        public void WhenIAddANewCertification()
        {
            //click on Add new
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")).Click();

            //Add college/ certificate name
            Driver.driver.FindElement(By.XPath("//input[@name='certificationName']")).SendKeys("Certificate IV in Business");

            //Enter certified from
            Driver.driver.FindElement(By.XPath("//input[@class='received-from capitalize']")).SendKeys("TAFE");

            //Select year
            SelectElement year = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']")));
            year.SelectByText("2017");

            //click on add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"that certification should be displayed on my listings")]
        public void ThenThatCertificationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Certification");

                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string ExpectedValue = "Certificate IV in Business";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[2]/tr/td[1]")).Text;
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
