using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;


namespace LexisNexisRiskNarrativeEexercise.ReusableMethods
{
    public class CustomMethods
    {
        public ChromeOptions MaximizeChromeBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            return options;

        }

        public EdgeOptions MaximizeEdgeBrowser()
        {
            EdgeOptions edge = new EdgeOptions();
            edge.AddArguments("start-maximized", "InPrivate");
            return edge;

        }

        public FirefoxOptions MaximizeFirefoxBrowser()
        {
            FirefoxOptions firefox = new FirefoxOptions();
            firefox.AddArgument("--start-maximized");
            firefox.AddArgument("-private");
            return firefox;
        }
    }
}
