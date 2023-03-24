using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

// Example of filtering hooks using tags
// See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping
// Example of ordering the execution of hooks
// See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

// See also https://stackoverflow.com/questions/58409700/using-chromedriver-across-specflow-tests


namespace csharp_cucumber_selenium_framework
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer container;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }


        [BeforeScenario]
        public void CreateWebDriver()
        {
            // The headless option ...
            //    ChromeOptions options = new ChromeOptions();
            //
            //    options.AddArguments(new List<string>()
            //    {
            //      "--silent-launch",
            //      "--no-startup-window",
            //      "no-sandbox",
            //      "headless"
            //    });

            //    driver = new ChromeDriver(options);


            ChromeDriver driver = new ChromeDriver();

            // Make 'driver' available for DI (Dependency Injection)
            container.RegisterInstanceAs<IWebDriver>(driver);
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
