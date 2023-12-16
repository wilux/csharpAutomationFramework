using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Collections.Generic;
using System.Configuration;

namespace csharp_cucumber_selenium_framework
{
    public class BrowserFactory
    {
        public IWebDriver browser;
        IWebDriver driver;

        public BrowserFactory(string browserName) {

            switch (browserName)
            {
                case "chrome":
                    driver = this.SetChrome();
                    break;
                case "chrome_headless":
                    driver = this.SetChromeHeadless();
                    break;
                case "firefox":
                    driver = this.SetFirefox();
                    break;
                case "edge":
                    driver = this.SetEdge();
                    break;
                case "safari":
                    driver = this.SetSafari();
                    break;
                default:
                    driver = null;
                    break;
            }
            this.browser = driver;
        }


        private ChromeDriver SetChrome()
        {
            var options = new ChromeOptions();
            options.AddArguments(new List<string>() { });
            return new ChromeDriver(options);
        }

        private ChromeDriver SetChromeHeadless()
        {
            var options = new ChromeOptions();
            options.AddArguments(new List<string>()
            {
                "--silent-launch",
                "--no-startup-window",
                "no-sandbox",
                "headless"
            });
            return new ChromeDriver(options);
        }

        private FirefoxDriver SetFirefox()
        {
            var options = new FirefoxOptions();
            options.AddArguments(new List<string>() { });
            return new FirefoxDriver(options);
        }

        private EdgeDriver SetEdge()
        {
            var options = new EdgeOptions();
            options.AddArguments(new List<string>() { });
            return new EdgeDriver(options);
        }

        private SafariDriver SetSafari()
        {
            var options = new SafariOptions();
            return new SafariDriver(options);
        }
    }
}
