using OpenQA.Selenium;

// https://blog.testproject.io/2020/11/09/page-object-model-in-selenium-using-c-sharp-nunit-reporting/

namespace csharp_cucumber_selenium_framework.Pages
{
    public class ThankYouPage : BasePage
    {
        private readonly IWebDriver driver;

        public string URL = "/index.php?action=thankYou";

        private readonly string txtThankYou = "//h2";


        public ThankYouPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return this.GetBaseUrl() + this.URL;
        }

        public string GrabThankYouMessage()
        {
            return GrabTextFromElement(driver, txtThankYou);
        }
    }
}
