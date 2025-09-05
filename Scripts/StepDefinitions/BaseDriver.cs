using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSWebdriverFactory.SeleniumDriver;
using OpenQA.Selenium;
using NSConfigLoader;
using NSENVSettings;

namespace Scripts.StepDefinitions.Driver
{
    [Binding]
    public class BaseDriver
    {
        internal IWebDriver? driver;
        internal EnvironmentProperties? env;
        

        [BeforeScenario]
        public void BeforeScenario()
        {
            ConfigLoader loader = new ConfigLoader("environments.json");
            env = loader.LoadConfigDetails();
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
