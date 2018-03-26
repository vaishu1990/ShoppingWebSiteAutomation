using AutomationPractice.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObject
{
    class MyAccountPO
    {
        Utility utility = new Utility();


        [FindsBy(How = How.LinkText, Using = "Sign out")]
        private IWebElement signOutLink = null;

        public MyAccountPO(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver returnBackToAuthenticationPage(IWebDriver driver)
        {
            try
            {
                utility.verifyButtonOrLinkText(signOutLink, driver);
                signOutLink.Click();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
            return driver;
        }

        
    }
}
