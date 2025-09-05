using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace NSWebdriverFactory.SeleniumDriver
{
  
    public static class GoogleTest
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
