using BoDi;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechTalk.SpecFlow;



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

            //BrowserSelector factory = new BrowserSelector(ConfigurationManager.AppSettings["Browser"]);
            BrowserSelector factory = new BrowserSelector(browserArg, optionsList);
            container.RegisterInstanceAs<IWebDriver>(factory.browser);

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
