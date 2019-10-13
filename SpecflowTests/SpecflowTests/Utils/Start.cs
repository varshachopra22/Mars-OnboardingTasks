using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
using OpenQA.Selenium;

namespace SpecflowTests.Utils
{
    [Binding]
    public class Start : Driver
    {
        //[BeforeScenario]
        [BeforeTestRun]
        public static void SetUp()
        {
            //IWebElement profiletab = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]"));
            //if (profiletab.Displayed == false)
            {
                //Launch the browser
                Initialize();
                Thread.Sleep(500);

                //Call the Login Class            
                SpecflowPages.Utils.LoginPage.LoginStep();

            }
        
        }

        //[AfterScenario]
        [AfterTestRun]
        public static void TearDown()
        {
            Thread.Sleep(500);
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            // end test. (Reports)
            CommonMethods.extent.EndTest(CommonMethods.test);

            // calling Flush writes everything to the log file (Reports)
            CommonMethods.extent.Flush();

            //Close the browser
            Close();
        }

    }
}
