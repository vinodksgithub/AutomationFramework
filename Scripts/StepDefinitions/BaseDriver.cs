using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSWebdriverFactory.SeleniumDriver;
using OpenQA.Selenium;

namespace Scripts.StepDefinitions.Driver
{
    [Binding]
    public class BaseDriver
    {
        internal IWebDriver? driver;
       
            
        [BeforeScenario]
        public void BeforeScenario()
        {
            GoogleTest.Setup();
            driver = GoogleTest.driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }
    }
}
