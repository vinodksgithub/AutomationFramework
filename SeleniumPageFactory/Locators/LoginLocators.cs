using OpenQA.Selenium;
using AutomationFramework.WebDriverFactory.WebelementExtension;

namespace   AutomationFramework.PageObjectFactory.Locators
{
    public  class LoginLocators
    {
        // Locators stored as By objects
        public  readonly By UsernameInput = By.ClassName("username");
        public  readonly By PasswordInput = By.XPath("//p/input[@type='password']");
        public  readonly By LoginButton = By.ClassName("LoginButton");

        public static IWebElement FindUserInput(IWebDriver driver)
        {
            return driver.FindElement(new LoginLocators().UsernameInput);
        }

        public static IWebElement FindUserPassword(IWebDriver driver)
        {
            return driver.FindElement(new LoginLocators().PasswordInput);
        }

        public static IWebElement FindLoginButton(IWebDriver driver)
        {
            return driver.FindElement(new LoginLocators().LoginButton);
        }

    }

}