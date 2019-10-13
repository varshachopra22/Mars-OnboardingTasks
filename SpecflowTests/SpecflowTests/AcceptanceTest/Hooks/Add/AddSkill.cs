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
    public class SpecFlowFeature2Steps
    {
        [Given(@"I clicked on the Skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Wait
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[@class='item' and text()='Profile']")).Click();
            
            // Click on Skill tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Click on Add new button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add text to skill textbox
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Calligraphy");

            //select skill level
            SelectElement skilllevel = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='level']")));
            //IWebElement skilllevel = Driver.driver.FindElements(By.XPath("//select[@name='level']"))[2];
            skilllevel.SelectByText("Intermediate");

            //click on Add
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }


        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string ExpectedValue = "Calligraphy";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[2]/tr/td[1]")).Text;
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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
