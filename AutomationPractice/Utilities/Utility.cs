using Dapper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Utilities
{
    class Utility
    {
        public IWebDriver getDriverInstance(IWebDriver driver)
        {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return driver;
        }

        public Boolean verifyText(String textToBeVerified, IWebDriver driver)
        {
            String pageSource = driver.PageSource.ToString();
            Boolean result = pageSource.Contains(textToBeVerified);
            return result;
        }

        public Boolean verifyAjaxText(String locatorValue, String textToBeVerified, IWebDriver driver)
        {
            driver = waitForWebElement(locatorValue, driver);
            String pageSource = driver.PageSource.ToString();
            Boolean result = pageSource.Contains(textToBeVerified);
            return result;
        }


        public IWebDriver waitForWebElement(String locatorValue, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorValue)));
            return driver;
        }

        public IWebDriver verifyButtonOrLinkText(IWebElement element, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            return driver;
        }

        public string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public String[] splitErrorMessages(String messages)
        {
            string[] errorMessages = messages.Split(';');
            return errorMessages;
        }

        public string getErrorMessages(String key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return value;
        }

        public void takeScreenshot(IWebDriver driver, String testCaseID)
        {
            String currentTimestamp = DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("C://Reports//Screenshots//" + testCaseID + "_"+ currentTimestamp + ".png");
        }

        public List<UserData> GetTestData(string runFlag, string sheetName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                String queryBuilder = "select * from [" + sheetName + "$] where runFlag='{0}'";
                var query = string.Format(queryBuilder, runFlag);
                List<UserData> value = connection.Query<UserData>(query).AsList();
                connection.Close();
                return value;
            }
        }

        

    }   
}
