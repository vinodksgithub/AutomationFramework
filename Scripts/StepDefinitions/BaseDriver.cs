using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSWebdriverFactory.SeleniumDriver;
using OpenQA.Selenium;
using NSConfigLoader;
using NSENVSettings;
using System.Net.Http;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

            if (!IsSiteUp(env?.url))
            {
                throw new Exception("Site is DOWN. Halting test execution.");
            }
            else
            {
                GoogleTest.Setup();
                driver = GoogleTest.driver;
            }
        }



        public bool IsSiteUp(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(env?.url).Result;
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
