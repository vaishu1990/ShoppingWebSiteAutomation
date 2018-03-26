using AutomationPractice.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObject
{
    class AuthenticationPO
    {
        Utility utility = new Utility();


        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        private IWebElement createAccountButton = null;

        [FindsBy(How = How.Id, Using = "email_create")]
        private IWebElement email = null;

        public AuthenticationPO(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver enterEmailAddress(UserData item, IWebDriver driver, ExtentTest test)
        {
            try
            {
                test.Log(LogStatus.Info, "Entering Email Address in Sign In Page");
                test.Log(LogStatus.Info, "Email Id : " + item.email);


                utility.verifyButtonOrLinkText(createAccountButton, driver);
                email.SendKeys(item.email);
                createAccountButton.Click();

                //var errMsg = utility.getErrorMessages()
                //Boolean verifiedText = utility.verifyText("Your personal information", driver);

            }
            catch (Exception e)
            {
                // Screenshot to be attached
                utility.takeScreenshot(driver, "TC_001");
                test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(Constants.SCREENSHOT_PATH+"TC_001.png"));
                test.Log(LogStatus.Fail, "Failed in Sign In Page");
                test.Log(LogStatus.Error, e);
                Console.WriteLine(e);
            }

            return driver;
        }
    }
}
