using LexisNexisRiskNarrativeEexercise.PageObjetcs;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LexisNexisRiskNarrativeEexercise.StepDefinitions
{
    [Binding]
    public class FinServResultSteps
    {
        private readonly IWebDriver _driver;
        private readonly FinServResultPage finServResultPage;

        public FinServResultSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["driver"] as IWebDriver;
            if (_driver == null)
            {
                throw new InvalidOperationException("WebDriver has not been initialized.");
            }
            finServResultPage = new FinServResultPage(_driver);
        }

        [Given(@"User opens the home page")]
        public void GivenUserOpensTheHomePage()
        {
             finServResultPage.ClickAcceptCookies();
        }

        [Then(@"I verify the following on Home Page:")]
        public void ThenIVerifyTheFollowingOnHomePage(Table table)
        {
           
            foreach (var row in table.Rows)
            {
                    string item = row["Financial Services"];
                    Assert.That(finServResultPage.IsElementVisible(By.XPath($"//*[text()='{item}']")), Is.True, $"Home Page item '{item}' not found.");
            }
           
        }

        [When(@"I expand Choose your industry accordion")]
        public void WhenIExpandChooseYourIndustryAccordion()
        {
             finServResultPage.ClickAccordionTab();
        }

        [When(@"I click Financial Services")]
        public void WhenIClickFinancialServices()
        {
             finServResultPage.SelectFinancialServicesLink();
        }

        [Then(@"I verify the following on Financial page:")]
        public void ThenIVerifyTheFollowingOnFinancialPage(Table table)
        {
            foreach (var row in table.Rows)
            {
                string item = row["Financial Crime Compliance"];
                Assert.That(finServResultPage.IsElementVisible(By.XPath($"//*[text()='{item}']")), Is.True, $"Financial Page item '{item}' not found.");
            }
            Thread.Sleep(3000);
        } 
    }
}
