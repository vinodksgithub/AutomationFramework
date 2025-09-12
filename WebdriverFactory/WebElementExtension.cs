using OpenQA.Selenium;

namespace AutomationFramework.WebDriverFactory.WebelementExtension
{
    public static class WebElementExtensions
    {
        // Inputs text into a textbox with retry using polling
        public static void SendKeysWithPollingRetry(
            this IWebElement element,
            string text,
            int maxAttempts = 5,
            int pollingIntervalMs = 500)
        {
            int attempts = 0;
            Exception lastException = null;
            while (attempts < maxAttempts)
            {
                try
                {
                    element.Clear();
                    element.SendKeys(text);
                    // Optional: verify input succeeded
                    if (element.GetAttribute("value") == text)
                        return; // Success
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
                Thread.Sleep(pollingIntervalMs);
                attempts++;
            }
            throw new Exception($"Failed to input value '{text}' after {maxAttempts} attempts.", lastException);
        }
    }

}