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
    public class EducationSteps
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Wait
            //Thread.Sleep(1500);
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            // Click on Profile tab
            //Driver.driver.FindElement(By.XPath("//*[@class='item' and text()='Profile")).Click();
            
            // Click on Education tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab ='third']")).Click();
        }

        [When(@"I add a new education")]
        public void WhenIAddANewEducation()
        {
            //click on Add new
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            //Add college/ university name
            Driver.driver.FindElement(By.XPath("//input[@name='instituteName']")).SendKeys("Mumbai University");

            //Select country of college
            SelectElement country = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='country']")));
            country.SelectByText("India");

            //Select title
            SelectElement title = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='title']")));
            title.SelectByText("B.Sc");

            //Add degree 
            Driver.driver.FindElement(By.XPath("//input[@name='degree']")).SendKeys("Maths");

            //Select year
            SelectElement year = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            year.SelectByText("2004");

            //click on add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"that education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Education");

                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string ExpectedValue = "Maths";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]")).Text;
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
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
