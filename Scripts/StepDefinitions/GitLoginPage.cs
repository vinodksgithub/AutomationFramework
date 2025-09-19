using OpenQA.Selenium;
using AutomationFramework.Scripts.StepDefinitions;
using System;
using AutomationFramework.PageObjectFactory.PageObjects;
using Reqnroll;

namespace AutomationFramework.Scripts.StepDefinitions.LoginPageStepDefinition
{
    [Binding]
    public sealed class LoginPageStepDefinition:BaseDriver
    {
        // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef
        private LoginPage _loginPage = new LoginPage();

        [Given("Launch Git URL")]
        public async Task GivenLaunchGitURL()
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.reqnroll.net/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            Console.WriteLine("test ran");
            if (env?.url != null)
            {
                await Task.Run(
                    () => driver?.Navigate().GoToUrl(env.url)
                    );
                
            }
            
            Thread.Sleep(2000);
        }

        [When("User Inputs Username")]
        public void WhenUserInputsUsername()
        {             
            _loginPage.EnterUsername(driver,"user1");
        }

        [When("User Inputs Password")]
        public void WhenUserInputsPassword()
        {
            _loginPage.EnterPassword(driver,"pwd");
        }

        [When("User Clicks Login Button")]
        public void WhenUserClicksLoginButton()
        {
            _loginPage.ClickButton(driver);
            Thread.Sleep(3000);
        }

        [Then("User accepts Ok In Prompt")]
        public void ThenUserAcceptsOkInPrompt()
        {               
            _loginPage.ClickOkPrompt(driver);
        }

    }
}
