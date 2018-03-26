using AutomationPractice.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObject
{
    class HomePO
    {
        

        [FindsBy(How = How.LinkText, Using = "Sign in")]
        private IWebElement signInLink = null;

        public HomePO(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver navigateToAuthenticationPage(IWebDriver driver) {

               
            signInLink.Click();
            return driver;
        }

    }
}