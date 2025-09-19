using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutomationFramework.PageObjectFactory.Locators;
using OpenQA.Selenium;
using AutomationFramework.WebDriverFactory.SeleniumDriver;
using AutomationFramework.WebDriverFactory.WebelementExtension;


namespace AutomationFramework.PageObjectFactory.PageObjects
{
    public class LoginPage
    {
       
        // Actions using locators from LoginLocatorsl
        public void EnterUsername(IWebDriver _driver,  string username)
        {
            if (_driver == null)
            {
                throw new Exception("Driver is empty");
            }

            var ele = LoginLocators.FindUserInput(_driver);
            ele.SendKeysWithRetry(username);
        }

        public void EnterPassword(IWebDriver _driver, string password)
        {
            var ele = LoginLocators.FindUserPassword(_driver);
            ele.SendKeysWithPollingRetryAndJsFallback(_driver,password);
        }

        public void ClickButton(IWebDriver _driver)
        {
            LoginLocators.FindLoginButton(_driver).Click();
        }

        public void ClickOkPrompt(IWebDriver _driver)
        {
            IAlert _alert = _driver.SwitchTo().Alert();
            _alert.Accept();
            Thread.Sleep(3000);
        }
    }
}
