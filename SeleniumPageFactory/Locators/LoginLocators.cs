using OpenQA.Selenium;


namespace   AutomationFramework.PageObjectFactory.Locators
{
    public static class LoginLocators
    {
        // Locators stored as By objects
        public static readonly By UsernameInput = By.ClassName("username");
        public static readonly By PasswordInput = By.ClassName("password");
        public static readonly By LoginButton = By.ClassName("LoginButton");
        


    }

}