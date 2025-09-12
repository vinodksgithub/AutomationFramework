using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.PageObjectFactory.Locators;
using OpenQA.Selenium;  // <- this exact namespace
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

            IWebElement ele = _driver.FindElement(LoginLocators.UsernameInput);
            ele.SendKeysWithPollingRetry("user1");
        }

        public void EnterPassword(IWebDriver _driver, string password)
        {
            IWebElement ele = _driver.FindElement(LoginLocators.PasswordInput);
            
        }

        public void ClickButton(IWebDriver _driver)
        {
            _driver.FindElement(LoginLocators.LoginButton).Click();
        }
    }
}
