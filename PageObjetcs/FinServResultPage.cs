using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LexisNexisRiskNarrativeEexercise.PageObjetcs
{
    public class FinServResultPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public FinServResultPage(IWebDriver _driver)
        {
            this.driver = _driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        IWebElement acceptCookies => driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        IWebElement accordionTab => driver.FindElement(By.LinkText("Choose Your Industry"));
        IWebElement financialServicesLink => driver.FindElement(By.XPath("//div[normalize-space()='Financial Services']"));


        public void ClickAcceptCookies()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.Id("onetrust-accept-btn-handler")));
            acceptCookies.Click();
        }
       
        public void ClickAccordionTab()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("(//a[normalize-space()='Choose Your Industry'])[1]")));
            accordionTab.Click();
        }

        public void SelectFinancialServicesLink()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("//div[normalize-space()='Financial Services']")));
            financialServicesLink.Click();
        }

        public bool IsElementVisible(By by)
        {
            try
            {
                wait.Until(driver => driver.FindElement(by));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;

            }
        }







    }
}
