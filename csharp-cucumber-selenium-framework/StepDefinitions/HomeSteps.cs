using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;


namespace csharp_cucumber_selenium_framework.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        private readonly IWebDriver Driver;
 


        public HomeSteps(IWebDriver driver)
        {
            this.Driver = driver;

 
        }


        [Given(@"The user opens (.*)")]
        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        [Then(@"The user sees '(.*)' title")]
        public void VerifyPageTitle(string expectedTitle)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement titleElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".post-2715 > div:nth-of-type(1) h2")));
            Assert.That(expectedTitle, Is.EqualTo(titleElement.Text));
        }

    }
}
