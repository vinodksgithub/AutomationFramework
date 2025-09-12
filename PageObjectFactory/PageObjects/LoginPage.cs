using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.PageObjectFactory.Locators;
using OpenQA.Selenium;  // <- this exact namespace
using AutomationFramework.

namespace AutomationFramework.PageObjectFactory.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        

        // Actions using locators from LoginLocators
        public void EnterUsername(string username)
        {
            _driver.FindElement(LoginLocators.UsernameInput).SendKeys("user1");
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(LoginLocators.PasswordInput).SendKeys("pwd");
        }
    }
}
