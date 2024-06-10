using Allure.Net.Commons;
using BoDi;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.IO;



namespace csharp_cucumber_selenium_framework
{
    [Binding]
    public sealed class Setup
    {
        private readonly IObjectContainer container;

        public Setup(IObjectContainer container)
        {
            this.container = container;
        }


        [BeforeScenario]
        public void CreateWebDriver()

        {
            var browserArg = Environment.GetEnvironmentVariable("browser");
            var options = Environment.GetEnvironmentVariable("options");
            string[] optionsList = new string[0];


            if (!string.IsNullOrEmpty(options))
            {
                optionsList = options.Split(',');
            }
            if (string.IsNullOrEmpty(browserArg))
            {
                browserArg = "edge";
            }

            BrowserSelector factory = new BrowserSelector(browserArg, optionsList);
            container.RegisterInstanceAs<IWebDriver>(factory.browser);

        }
        [AfterStep]
        public void AfterStep()
        {
   
            var driver = container.Resolve<IWebDriver>();
            var screenshot = ((ITakesScreenshot) driver).GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;
            using (var memoryStream = new MemoryStream(screenshotBytes))
            AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
            
        }
    
        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
