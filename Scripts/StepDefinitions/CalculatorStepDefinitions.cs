using OpenQA.Selenium;
using Scripts.StepDefinitions.Driver;


namespace Scripts.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions:BaseDriver
    {
        // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef

       

        [Given("the first number are {int}")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.reqnroll.net/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            Console.WriteLine("test ran");
            
            driver.Navigate().GoToUrl(env.url);
            Thread.Sleep(2000);
        }

        

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            Console.WriteLine("test");
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            Console.WriteLine("test");
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            Console.WriteLine("test");
        }
    }
}
