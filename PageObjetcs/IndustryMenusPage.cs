using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace LexisNexisRiskNarrativeEexercise.PageObjetcs
{
    public class IndustryMenusPage
    {
        private IWebDriver driver;
        WebDriverWait wait;
         
        public IndustryMenusPage(IWebDriver _driver)
        {
            this.driver = _driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
             
        }

        IWebElement cookies =>  driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        IWebElement homePageDisplayed => driver.FindElement(By.CssSelector(".navbar-brand"));
        IWebElement yourIndustryTab => driver.FindElement(By.LinkText("Choose Your Industry"));
        IWebElement fsIndustryLink => driver.FindElement(By.XPath("//div[normalize-space()='Financial Services']"));
        IWebElement financialServicesHome => driver.FindElement(By.XPath("(//a[contains(text(),'View Financial Services')])[1]"));
        IWebElement fsTitleText => driver.FindElement(By.XPath("//*[@class='score-hero horizontal']"));

        public void ClickAcceptCookies()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.Id("onetrust-accept-btn-handler")));
            cookies.Click();

        }
        public bool HomePageIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".navbar-brand")));
            return homePageDisplayed.Displayed;
        }
        public void ClickYourIndustryTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("(//a[normalize-space()='Choose Your Industry'])[1]")));
            yourIndustryTab.Click();

        }
        public void SelectFSIndustryLink()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("//div[normalize-space()='Financial Services']")));
            fsIndustryLink.Click();

        }
        public void ClickToViewFinServiceHomePage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("(//a[contains(text(),'View Financial Services')])[1]")));
            financialServicesHome.Click();

        }
        public bool IsFSTitleDisplayed()
        {
            return fsTitleText.Displayed;
        }

        public void ScrollToElement()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(fsTitleText);
            actions.Perform();
            Thread.Sleep(3000);
        }
    }
}