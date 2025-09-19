using System;
using AutomationFramework.WebDriverFactory.SeleniumDriver;
using OpenQA.Selenium;
using AutomationFramework.EnvConfigurations.Config;
using NSENVSettings;
using Reqnroll;
using NUnit.Framework;

namespace AutomationFramework.Scripts.StepDefinitions
{
    [Binding]
    public class BaseDriver
    {
        protected static IWebDriver? driver;
        internal EnvironmentProperties? env;


        [BeforeScenario]
        public void BeforeScenario()
        {
            ConfigLoader loader = new ConfigLoader("environments.json");
            env = loader.GetConfigDetails();
            
            if (!IsSiteUp(env.url))
            {
                throw new Exception("Site is DOWN. Halting test execution.");
            }
            else
            {
                SeleniumDriver.GetDriverInstance();
                driver = SeleniumDriver.driver;
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(env.page_load_timeout);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(env.implicit_timeout);
            }
        }



        public bool IsSiteUp(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(env?.url).Result;

                    //Print the status code of URL to console
                    TestContext.WriteLine("StatusCode: " + response.StatusCode);
                    TestContext.WriteLine("IsSuccessStatusCode: " + response.IsSuccessStatusCode);

                    return response.IsSuccessStatusCode; // true if 2xx
                }
                catch
                {
                    return false;
                }
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }

    }
}
