using LexisNexisRiskNarrativeEexercise.Enums;
using LexisNexisRiskNarrativeEexercise.ReusableMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace LexisNexisRiskNarrativeEexercise.Hooks
{
    [Binding]
    public class WebHooks : BrowserTypes
    {
        public static IWebDriver? driver;
        private ReadJsonData readFromConfig;
        private readonly ScenarioContext _scenarioContext;

        public WebHooks(ScenarioContext scenarioContext, ReadJsonData readJson)
        {
            _scenarioContext = scenarioContext;
            readFromConfig = readJson;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChooseBrowser(browserType.Chrome);
            driver = NavigateToLexisSite();
            _scenarioContext["driver"] = driver;
        }

        public IWebDriver ChooseBrowser(browserType browserType)
        {
            return browserType == browserType.Chrome
                ? driver = new ChromeDriver(new CustomMethods().MaximizeChromeBrowser())
                : browserType == browserType.Edge
                ? driver = new EdgeDriver(new CustomMethods().MaximizeEdgeBrowser())
                : browserType == browserType.Firefox
                ? driver = new FirefoxDriver(new CustomMethods().MaximizeFirefoxBrowser())
                : throw new Exception("No such browser exist");
            
        }

        public IWebDriver NavigateToLexisSite()
        {
            driver?.Navigate().GoToUrl(readFromConfig.GetJsonData("env:lexisnexis"));
            return driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.ContainsKey("driver"))
            {
                var driver = _scenarioContext["driver"] as IWebDriver;
                driver?.Quit();
            }
        }
    }
}