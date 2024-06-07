using LexisNexisRiskNarrativeEexercise.PageObjetcs;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LexisNexisRiskNarrativeEexercise.StepDefinitions
{
    [Binding]
    public class FinancialServicesSteps
    {
        private readonly IWebDriver _driver;
        private readonly IndustryMenusPage industryMenusPage;
        
        public FinancialServicesSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["driver"] as IWebDriver;
            if (_driver == null)
            {
                throw new InvalidOperationException("WebDriver has not been initialized.");
            }
            industryMenusPage = new IndustryMenusPage(_driver);
        }

        [Given(@"Given user navigates to Lexisnexis website")]
        public void GivenGivenUserNavigatesToLexisnexisWebsite()
        { 
             industryMenusPage.ClickAcceptCookies();
        }

        [Then(@"user will arrive on the Lexisnexis home page")]
        public void ThenUserWillArriveOnTheLexisnexisHomePage()
        {
            var validateHeaderText = industryMenusPage.HomePageIsDisplayed();
            Assert.That(validateHeaderText, Is.EqualTo(true));
        }

        [When(@"user click choose your industry tab")]
        public void WhenClickChooseYourIndustryTab()
        {
             industryMenusPage.ClickYourIndustryTab();
        }

        [When(@"user select one of the industry links")]
        public void WhenUserSelectOneOfTheAnIndustryLinks()
        {
            industryMenusPage.SelectFSIndustryLink();
        }

        [When(@"user click on view financial services home")]
        public void WhenUserClickOnViewFinancialServices()
        {
             industryMenusPage.ClickToViewFinServiceHomePage();
        }

        [Then(@"user should see financial services home page displayed")]
        public void ThenUserShouldSeeFinancialServicesPageDisplayed()
        {
            var TitleTextDisplayed = industryMenusPage.IsFSTitleDisplayed();
            Assert.That(TitleTextDisplayed, Is.EqualTo(true));
        }

        [Then(@"user verify Financial Services header is displayed")]
        public void ThenScrollToTheFinancialServicesHeader()
        {
            bool titleContainsFS = _driver.Title.Contains("Financial Services");
            Assert.That(titleContainsFS, "The page title does not contain 'Financial Services'.");
            
            industryMenusPage.ScrollToElement();
        }  
    }
}
