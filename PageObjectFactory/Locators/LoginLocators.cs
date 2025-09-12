using OpenQA.Selenium;


namespace   AutomationFramework.PageObjectFactory.Locators
{
    public static class LoginLocators
    {
        // Locators stored as By objects
        public static readonly By UsernameInput = By.Id("username");
        public static readonly By PasswordInput = By.Id("password");
        public static readonly By LoginButton = By.CssSelector("button[type='submit']");
        public static readonly By RememberMeCheckbox = By.Name("remember");
    }

}