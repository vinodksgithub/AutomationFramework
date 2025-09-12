using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace AutomationFramework.WebDriverFactory.SeleniumDriver
{
  
    public static class SeleniumDriver
    {
        public static IWebDriver? driver;
       
        public static void Setup()
        {
            if (driver != null) return;                 // <-- idempotent
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }


    }
}
