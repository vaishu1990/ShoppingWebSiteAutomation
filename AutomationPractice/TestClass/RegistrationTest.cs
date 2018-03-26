using System;
using System.Collections.Generic;
using AutomationPractice.PageObject;
using AutomationPractice.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;

namespace AutomationPractice.TestClass
{
    [TestClass]
    public class RegistrationTest
    {
        IWebDriver driver = null;
        Utility utility = new Utility();
        HomePO home = null;
        RegistrationPO register = null;
        AuthenticationPO authenticate = null;
        MyAccountPO myAccount = null;


        [TestMethod]
        public void Registration()
        {
            ExtentReports extent = new ExtentReports(Constants.REPORT_PATH+"Registration_Tests"+ DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss") + ".html", true);

            ExtentTest test = new ExtentTest("Test Case Name", "Sample Description");

            try
            {
                driver = utility.getDriverInstance(driver);                

                List<UserData> userData = utility.GetTestData("Yes", "Register");

                foreach (UserData item in userData)
                {
                    test = extent.StartTest("Test Case 001", "Sample description");

                    test.Log(LogStatus.Info, "Application Launched Successfully !!!");

                    home = new HomePO(driver);
                    driver = home.navigateToAuthenticationPage(driver);

                    authenticate = new AuthenticationPO(driver);
                    driver = authenticate.enterEmailAddress(item, driver, test);


                    register = new RegistrationPO(driver);
                    driver = register.enterUserDetails(item, utility, driver,test);

                    myAccount = new MyAccountPO(driver);
                    driver = myAccount.returnBackToAuthenticationPage(driver);

                    extent.EndTest(test);


                }
                extent.Flush();

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            driver.Quit();

        }

    }
}
