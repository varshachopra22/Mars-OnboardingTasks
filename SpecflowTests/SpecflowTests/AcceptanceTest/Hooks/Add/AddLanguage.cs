using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            //Thread.Sleep(1500);
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@class='item' and text()='Profile'] ")).Click();
        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("English");

            //Click on Language Level
            //Driver.driver.FindElement(By.XPath("//select[@name='level']")).Click();

            //Choose the language level
            SelectElement Lang = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='level']")));
            Lang.SelectByText("Fluent");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                //Thread.Sleep(1000);
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                //Thread.Sleep(1000);
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Text;
                //Thread.Sleep(500);
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
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
   


