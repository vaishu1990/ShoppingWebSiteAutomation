using AutomationPractice.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationPractice.PageObject
{
    class RegistrationPO
    {
        [FindsBy(How=How.Name,Using = "id_gender")]
        private IWebElement title = null;

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        private IWebElement firstName = null;

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        private IWebElement lastName = null;

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement password = null;

        [FindsBy(How = How.Id, Using = "days")]
        private IWebElement date = null;

        [FindsBy(How = How.Id, Using = "months")]
        private IWebElement month = null;

        [FindsBy(How = How.Id, Using = "years")]
        private IWebElement year = null;

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement mobileNum = null;

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement address = null;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement city = null;

        [FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement state = null;

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement postalCode = null;

        [FindsBy(How = How.Id, Using ="alias")]
        private IWebElement addressAlias = null;

        [FindsBy(How = How.Id, Using = "submitAccount")] 
        private IWebElement registerButton = null;
        
        public RegistrationPO(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver enterUserDetails(UserData item, Utility utility, IWebDriver driver, ExtentTest test)
        {
            try
            {
                /*Boolean verifiedText = utility.verifyText("Your personal information", driver);
                if (verifiedText)
                {
                    Console.WriteLine("Account Creation Page Loaded successfully");
                }
                else
                {
                    Console.WriteLine("Could Not Find Account Creation Page");
                }*/
                utility.verifyButtonOrLinkText(registerButton, driver);
                // Display messages....
                title.Click();
                firstName.SendKeys(item.firstName);
                lastName.SendKeys(item.lastName);
                password.SendKeys(item.password);
                date.SendKeys(item.date_DOB);
                month.SendKeys(item.month_DOB);
                year.SendKeys(item.year_DOB);
                mobileNum.SendKeys(item.mobileNumber);
                address.SendKeys(item.address);
                city.SendKeys(item.city);
                state.SendKeys(item.state);
                postalCode.SendKeys(item.postalCode);
                addressAlias.Clear();
                addressAlias.SendKeys(item.address);
                registerButton.Click();

                /*if (item.errorMessages)
                {
                   String[] errormessages = utility.getErrorMessages(errorMessages);
                   
                    for(i=0; item < errormessages.Length();i++) {
                        utility.verifyText(errormessages[i]);
                    }
                }  */            
                
            }
            catch(Exception e)
            {
                utility.takeScreenshot(driver, "TC_001");
                test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(Constants.SCREENSHOT_PATH + "TC_001.png"));
                test.Log(LogStatus.Fail, "Failed in Sign In Page");
                test.Log(LogStatus.Error, e);
                Console.WriteLine(e);
                Console.WriteLine(e);
            }

            return driver;

        }
    }
}
