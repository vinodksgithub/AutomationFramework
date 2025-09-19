using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.WebDriverFactory.WebelementExtension
{
    public static class WebElementExtensions 
    {
        // Inputs text into a textbox with retry using polling
        // maxAttempts , pollingIntervalsMs 
        public static void SendKeysWithRetry(
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
                        return;
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

        public static void SendKeysWithPollingRetryAndJsFallback(
            this IWebElement element,
            IWebDriver driver,
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
                    // Verify the text was entered
                    if (element.GetAttribute("value") == text)
                        return; // Success
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }

                System.Threading.Thread.Sleep(pollingIntervalMs);
                attempts++;
            }

            // Fallback: Use JavaScript to set value directly if all retries fail
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].value = arguments[1];", element, text);
        }

    }
}